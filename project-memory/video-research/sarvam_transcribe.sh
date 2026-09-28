#!/usr/bin/env bash
# sarvam_transcribe.sh <playlist_key>
# Per video under $ROOT/<key>/*/keyframes: download audio (chrome cookies → bypass bot-block) → 28s
# chunks (<30s Sarvam limit) → Sarvam saarika:v2.5 (hi-IN) → clean transcript.sarvam.txt. Retry only on
# throttle (429/503/timeout). Idempotent via .sarvam_done marker.
set -uo pipefail
KEY="${1:?playlist key required}"
ROOT="/Users/yakshitsavaliya/Desktop/imodule-extracted/project-memory/video-research"
: "${SARVAM_KEY:?SARVAM_KEY env required}"
STT="https://api.sarvam.ai/speech-to-text"

transcribe_chunk() { # $1=wav → prints transcript; retries only on throttle
  local wav="$1" try=0 body code json
  while [ "$try" -lt 5 ]; do
    body=$(curl -s -m 120 -w '\n%{http_code}' -X POST "$STT" -H "api-subscription-key: $SARVAM_KEY" \
      -F "model=saarika:v2.5" -F "language_code=hi-IN" -F "file=@$wav;type=audio/wav" 2>/dev/null)
    code=$(printf '%s' "$body" | tail -1); json=$(printf '%s' "$body" | sed '$d')
    case "$code" in
      200) printf '%s' "$(printf '%s' "$json" | jq -r '.transcript // ""' 2>/dev/null)"; return 0;;
      429|503|000|502|504) try=$((try+1)); sleep $((try*3));;  # throttle/transient → backoff
      *) return 1;;  # 400/401/etc → non-retryable
    esac
  done
  return 1
}

for VDIR in "$ROOT/$KEY"/*/; do
  [ -d "$VDIR/keyframes" ] || continue
  VID=$(basename "$VDIR")
  [ -f "$VDIR/.sarvam_done" ] && { echo "skip $KEY/$VID (done)"; continue; }
  OUT="$VDIR/transcript.sarvam.txt"; TMP=$(mktemp -d)
  yt-dlp -q --no-warnings --cookies /tmp/yt_cookies.txt -f 'ba/bestaudio/worst' -o "$TMP/src.%(ext)s" "https://www.youtube.com/watch?v=$VID" 2>/dev/null
  SRC=$(ls "$TMP"/src.* 2>/dev/null | head -1)
  if [ -z "${SRC:-}" ]; then echo "FAIL download $KEY/$VID"; rm -rf "$TMP"; sleep 2; continue; fi
  ffmpeg -hide_banner -loglevel error -i "$SRC" -ar 16000 -ac 1 -f segment -segment_time 28 "$TMP/c_%03d.wav" 2>/dev/null
  : > "$OUT"; nchunks=0; ok=0
  for c in "$TMP"/c_*.wav; do
    [ -f "$c" ] || continue; nchunks=$((nchunks+1))
    if t=$(transcribe_chunk "$c"); then ok=$((ok+1)); printf '%s ' "$t" >> "$OUT"; fi
    sleep 1
  done
  printf '\n' >> "$OUT"
  [ "$ok" -eq "$nchunks" ] && [ "$nchunks" -gt 0 ] && touch "$VDIR/.sarvam_done"
  echo "done $KEY/$VID — $ok/$nchunks chunks, $(wc -c < "$OUT" | tr -d ' ') chars$([ "$ok" -eq "$nchunks" ] && echo ' ✓' || echo ' (partial)')"
  rm -rf "$TMP"; sleep 1
done
echo "PLAYLIST_DONE $KEY"
