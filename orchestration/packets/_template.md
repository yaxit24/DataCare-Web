# WP-00 Example menu: what this packet produces

Copy this file to `<WP>.<stage>.md`, edit the header and the brief, then run
`node orchestration/bin/orch.mjs check <file>`. Field meanings: `orchestration/PACKETS.md`.

```json
{
  "id": "WP-00.example",
  "wp": "WP-00",
  "title": "Example menu: the outcome in one line",
  "role": "study",
  "risk": "C",
  "branch": "agent/wp00-example",
  "dependsOn": [],
  "allow": ["orchestration/work/WP-00/**"],
  "outputs": ["orchestration/work/WP-00/study.md"],
  "context": ["unified/src/csharp/DataCareNext/MS_YEAR.cs"],
  "inline": [],
  "skills": ["datacare-desktop-authority"],
  "gates": [{ "type": "cite", "file": "orchestration/work/WP-00/study.md", "requireSnippets": true, "min": 20 }],
  "limits": { "minutes": 45 }
}
```

## Goal

Two to five sentences: the menu, the desktop form and its size, what exists on the web, and what the next session
will do with this packet's output.

## Facts you need

- Each fact the worker would otherwise have to search for: a line range, a web file, an example to copy.

## What to cover

1. Numbered, concrete items. Name files and line ranges.

## Out of scope

- The nearest wrong turns, one line each.

## Done when

- Each line is something a script or a reader can verify in a minute.
