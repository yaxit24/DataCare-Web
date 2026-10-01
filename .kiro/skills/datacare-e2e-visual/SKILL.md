---
name: datacare-e2e-visual
description: Verify a DataCare web screen in a real Chrome browser through the Chrome DevTools MCP — login, scope, navigation, layout against desktop keyframes, keyboard flow, calculations, network and console health, save/print/reopen, refusals and accessibility — and record evidence. Use after changing any screen, or when asked to test the web UI visually or end to end.
---

# Visual and interactive verification (Chrome DevTools MCP)

Screens: `$ARGUMENTS` (for example `/txn/receipt` or `Transaction/Cash Received`).

The full protocol is `docs/handbook/web/testing.md` §5. This skill is the operating checklist.

## 1. Stack

- Use the isolated database and production builds (`docs/handbook/web/testing.md` §2), or the demo seed on a
  throwaway database. Never a database with customer data.
- The web build fixes `API_ORIGIN`; rebuild when the API port changes.
- Note the web URL (for example `http://127.0.0.1:4411`) and a fixture login you created for this run.

## 2. Browser

1. Check Chrome: `curl -s http://127.0.0.1:9222/json/version`. If it is not running, start it with
   `~/.kiro/bin/kiro-chrome.sh` (dedicated profile on port 9222).
2. Other sessions may share this Chrome. Create your own page in an isolated context:
   `new_page` with `url` set to the login page and `isolatedContext: "datacare-<slice>"`. Record the returned page ID
   and pass `pageId` on every call. Never select, navigate or close another session's page.
3. `emulate` with `viewport: "1366x768x1"`; repeat key screens at `"1920x1080x1"`.

## 3. Per screen

1. `take_snapshot` → `fill_form` (login) → `click` → choose company, location and year.
2. Open the screen from the navigation (`click`), not by typing the URL. Check the book chooser behaves like the
   desktop (one book auto-selected, several offered, none → clear error).
3. `take_snapshot` with `filePath` → compare regions, field order, captions and grid columns with the desktop:
   find the screen in `project-memory/video-research/_kb/KB_*.md`, open its keyframe image with the image reader, and
   check `web/apps/api/form-specs/<FORM>.initcomp.json`. Decision D20: semantic parity, not pixels.
4. Keyboard: `press_key` `Enter` through the fields (desktop order), `F1` on a code field (lookup opens), grid arrows,
   and the desktop F-keys; `take_snapshot` after each to confirm focus.
5. Enter a realistic voucher with `fill`/`click`; confirm calculated fields (fine, labour, tax, totals) against the
   expected values from the desktop authority note.
6. `list_network_requests` and `get_network_request` for each mutation: only `/api` calls; no unexpected 4xx/5xx; the
   body carries no company, location or year; version and idempotency headers where implemented.
7. `list_console_messages` with `types: ["error", "warn"]`: none expected.
8. Save → `wait_for` the voucher number → print preview (`take_screenshot`): correct copies and copy labels, a
   four-digit year → reopen: every value is back.
9. Refusals: an invalid entry shows field messages (400); a second isolated page editing the same voucher gets a
   conflict, not a silent overwrite.
10. `lighthouse_audit` with `mode: "snapshot"` for accessibility on the changed screen.
11. `take_screenshot` with `filePath` for the initial screen, the filled voucher, the print preview and each refusal.

## 4. Evidence

- Files under `web/test-results/visual/<slice>/` (ignored by git). No images or snapshots containing customer data.
- In the pull request: screens and viewports checked, keyframes compared, each difference with its disposition
  (accepted under D20, or a defect recorded as a gap), console and network results, accessibility result.

## 5. Pitfalls

- Use `uid` values from the latest snapshot only; they change on every render.
- "Execution context was destroyed" after `evaluate_script` means a navigation happened: take a new snapshot.
- A controlled input that keeps its old text: click it, select all with `press_key` (`Meta+A` on macOS,
  `Control+A` elsewhere), then type.
- `wait_for` the text that proves completion instead of sleeping.
- When finished, `close_page` your page. Port 9222 gives full control of the browser to local processes; do not sign
  in to personal accounts in that profile.
