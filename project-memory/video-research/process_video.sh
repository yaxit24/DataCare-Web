#!/usr/bin/env bash
# process_video.sh <playlist_key> <video_id> <title...>
# Space-conscious: downloads subtitles + a <=720p stream, extracts scene-change keyframes (storyboard),
# writes a transcript, then DELETES the video file to respect the disk budget. Idempotent-ish.
set -uo pipefail
KEY="$1"; VID="$2"; shift 2; TITLE="$*"
ROOT="/Users/yakshitsavaliya/Desktop/imodule-extracted/project-memory/video-research"
OUT="$ROOT/$KEY/$VID"
mkdir -p "$OUT/keyframes"
URL="https://www.youtube.com/watch?v=$VID"
echo "[$KEY/$VID] $TITLE"

# 1) subtitles (manual + auto, Hindi + any English/auto-translated), as srt — tiny.
yt-dlp -q --no-warnings --ignore-errors --skip-download \
  --write-subs --write-auto-subs --sub-langs "hi.*,en.*" --convert-subs srt \
  -o "$OUT/subs.%(ext)s" "$URL" 2>/dev/null
# flatten the first available srt into a clean transcript (strip indices + timestamps + dedupe blanks)
SRT=$(ls "$OUT"/subs*.srt 2>/dev/null | head -1)
if [ -n "${SRT:-}" ]; then
  grep -vE '^[0-9]+$|-->|^\s*$' "$SRT" | sed 's/<[^>]*>//g' | awk '!seen[$0]++' > "$OUT/transcript.txt"
  echo "  subs: $(basename "$SRT") -> transcript.txt ($(wc -l < "$OUT/transcript.txt" | tr -d ' ') lines)"
else
  echo "  subs: NONE" ; echo "(no captions available)" > "$OUT/transcript.txt"
fi

# 2) low-res video (<=720p; readable ERP text, small) into a temp file.
yt-dlp -q --no-warnings --ignore-errors \
  -f "bv*[height<=720]+ba/b[height<=720]/best[height<=720]/worst" \
  -o "$OUT/_video.%(ext)s" "$URL" 2>/dev/null
VF=$(ls "$OUT"/_video.* 2>/dev/null | head -1)
if [ -z "${VF:-}" ]; then echo "  VIDEO DOWNLOAD FAILED"; exit 2; fi
SZ=$(du -h "$VF" | cut -f1); echo "  video: $(basename "$VF") ($SZ)"

# 3) scene-change keyframes (distinct screens/effects) scaled to 1280w; capture pts_time in a log.
ffmpeg -hide_banner -loglevel error -i "$VF" \
  -vf "select='gt(scene,0.20)',showinfo,scale=1280:-2" -vsync vfr "$OUT/keyframes/kf_%03d.jpg" \
  2> "$OUT/scene.log" || true
NF=$(ls "$OUT/keyframes"/*.jpg 2>/dev/null | wc -l | tr -d ' ')
# fallback: if too few scene frames, sample every 5s
if [ "${NF:-0}" -lt 6 ]; then
  rm -f "$OUT/keyframes"/*.jpg
  ffmpeg -hide_banner -loglevel error -i "$VF" -vf "fps=1/5,scale=1280:-2" "$OUT/keyframes/kf_%03d.jpg" 2>/dev/null || true
  NF=$(ls "$OUT/keyframes"/*.jpg 2>/dev/null | wc -l | tr -d ' ')
  echo "  keyframes: $NF (interval 5s fallback)"
else
  echo "  keyframes: $NF (scene-change)"
fi
# pts_time list (rough timeline) from showinfo
grep -oE 'pts_time:[0-9.]+' "$OUT/scene.log" 2>/dev/null | sed 's/pts_time://' | head -200 > "$OUT/keyframe_times.txt" || true

# 4) DELETE the video to reclaim disk; keep only subs + transcript + keyframes.
rm -f "$VF"
echo "  done — video deleted; kept transcript + $NF keyframes. dir: $OUT"
