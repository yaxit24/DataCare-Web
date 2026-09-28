# Device bridge decision

## Decision

Use browser WebSerial/WebUSB directly when an approved browser and device expose those APIs. Where a scale requires an OS serial driver or unsupported protocol, use a separately installed local agent. A local agent is not part of this repository and must never be represented as connected unless a real authenticated handshake succeeds. Manual weight entry remains available in the web UI.

Desktop evidence: `extracted_code/DataCareNext/DataCareNext/TR_TAG_OPBL.cs:7499-7550` discovers a CH340 COM port, tries 9600/8/N/1, and falls back to the company `WEIGHT_PORT` setting at 2400/7/N/1. `TR_TAG_OPBL.cs:7552-7594` queues serial text, extracts numeric characters, and formats the result to three decimals. The web settings parser reads the active company's `CO_SET.WEIGHT_PORT`; the API endpoint returns only that server-derived value.

## Scale-read message

The untrusted device/agent message is JSON:

```json
{
  "value": "12.345",
  "unit": "g",
  "stable": true,
  "timestamp": "2026-07-28T00:00:03.000Z"
}
```

- `value` is a decimal string so precision can be validated without floating-point text loss.
- `unit` is an explicitly allowed unit (`g` or `kg`); policy controls which are accepted.
- `stable` is a boolean. An unstable reading is preserved as unstable and must not be presented as stable.
- `timestamp` is canonical ISO-8601 UTC. Policy supplies freshness and future-skew limits.
- Decimal places and plausible gram range are explicit caller/deployment policy. No shop capacity is inferred from desktop code.

`web/apps/api/src/modules/integrations/deviceBridge.ts` is the pure validation boundary. It rejects malformed values, unsupported units, excess precision, stale/future timestamps, invalid flags, and values outside the supplied range.

## Authentication model

1. WebSerial/WebUSB access is initiated by a user gesture and uses browser permission grants. Device identity and permission state are displayed; absence of support falls back to manual entry.
2. A future local agent must generate a per-installation secret during pairing and store it in OS-protected storage. The browser exchanges short-lived, origin-bound challenge responses; the long-lived secret is never placed in page source, URL parameters, logs, or repository configuration.
3. Agent messages include a nonce and timestamp and are accepted once. The web/API still validates every reading as untrusted input.
4. The company device setting endpoint is session-authenticated, rights-gated as `Utilities/Settings` read access, and derives tenant/company/location from the server session rather than request fields.

## Threat model

- **Network exposure:** any local-agent endpoint **must be loopback-bound and authenticated**. Binding to `0.0.0.0`, a LAN address, or an unauthenticated localhost port is prohibited.
- **Cross-origin request abuse:** require an allowlist of deployed web origins, validate `Origin`, reject ambient unauthenticated requests, and do not rely on CORS alone.
- **Replay/spoofing:** sign challenge/response messages, expire timestamps, enforce nonces, and never trust a browser-supplied company or tenant.
- **Malicious/buggy hardware:** enforce unit, precision, range, stability, and freshness checks. Do not auto-submit unstable readings.
- **Compromised browser extension/page:** expose the minimum device operation (read only), never return secrets, and retain a visible manual-entry path.
- **Availability:** device absence, revoked permission, unsupported APIs, and agent downtime must not block the operator; no fake reading or fake connected state is permitted.

## Certification boundary

Locally provable: protocol validation, server-derived configured port, RBAC mapping, browser API capability reporting, and manual fallback. Real scale framing, driver compatibility, browser permissions, agent pairing, USB identifiers, camera permissions, and physical accuracy require representative hardware and site UAT.

## 2026-07-29 — protocol replication implemented

The bridge is no longer a design document plus a capability probe. The desktop's own serial protocol is
now ported, so a real scale produces the same number the desktop would from the same bytes.

### Weighing scale — `TR_TAG_OPBL.cs` ported line by line

| Desktop behaviour | Where it now lives |
|---|---|
| Disabled when `MsWeightPort = "0"` | `scaleCaptureEnabled()`; readiness reports `disabled-by-setting` |
| Port discovery by friendly name `CH340` | `SCALE_PORT_FRIENDLY_NAME`, surfaced to the browser |
| Primary 9600 / 8 / N / 1 | `SCALE_PORT_PROFILES.primary` |
| Fallback 2400 / **7** / N / 1 on open failure | `SCALE_PORT_PROFILES.fallback`, tried in the same order |
| Keep digits and `.`; drop `+` and CR; first 20 chars | `parseScaleFrame()` |
| `Format(Val(text), "0.000")` | three-decimal output, format-string rounding |
| Read only while the net-weight cell is current (`MSG.Col != 14`) | focus tracking on the tag-opening grid |

**A minus sign is dropped.** The desktop's keep-set is numeric-or-dot, so a tare-negative reading arrives
positive — `-1.234` becomes `1.234`. That is reproduced deliberately and flagged (`signDropped`), because
silently "fixing" it would make the web disagree with the desktop on the same scale.

Endpoints: `GET /integrations/device-settings` publishes the profiles and filter parameters so the browser
never guesses them; `POST /integrations/scale-reading` parses a raw frame server-side with the same
extractor. Ten protocol tests cover real frame shapes (`+  12.345\r`, `ST,GS,+ 1.234 g`, the 20-character
window, a second decimal point, and the empty-frame case that must not be read as 0.000).

### Barcode scanner — nothing to build

The desktop has no scanner driver: a wedge scanner types the tag and presses Enter. The web grids already
accept exactly that, with the same Enter-advances-cell behaviour, so readiness reports this `ready`.

### Camera — `UT_WEB_CAM` equivalent

`components/CameraCapture.tsx` opens `getUserMedia`, previews, and captures a JPEG `File` that goes through
the **same** upload endpoint as an attached file, so there is one storage path and one set of size and type
checks. The desktop wrote to a LAN share; the web stores bytes in the database, which is why the desktop's
share-unreachable error has no web equivalent (waived with evidence).

### Honesty rules, enforced by tests

1. Nothing is ever fabricated — no placeholder weight, no synthetic image.
2. With no hardware the controls report `idle` / `unsupported` / `disabled` and stay disabled. The browser
   suite asserts the status never reads `reading` or `live` without a granted device, and both assertions
   were proven to fail when inverted.
3. `GET /integrations/readiness` reports variable **presence** only, never values, masks the GSTIN, and
   never marks an integration `ready` while a credential is missing — a fake transport succeeding proves
   nothing about a real one.
