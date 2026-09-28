# Credential onboarding — what to set, and how to prove it works

Every credential-gated integration is implemented end to end against the real provider API. Nothing is
stubbed on the wire. Supplying the variables below is the whole activation step; no code change, rebuild
or redeploy of application logic is required beyond restarting the API so it re-reads the environment.

## The variables

| Integration | Required | Optional | Read by |
|---|---|---|---|
| e-Invoice (IRN) | `GSP_ASPID`, `GSP_PASSWORD`, `GSP_GSTIN`, `GSP_USER`, `GSP_EINV_PWD` | `GSP_SANDBOX=0` for production (absent or any other value ⇒ sandbox) | `irnTransportFromEnv()` |
| WhatsApp | `WA_PHONE_ID`, `WA_TOKEN` | `WA_API_VERSION` (default `v22.0`) | `senderFromEnv()` |
| SMS | `SMS_URL_TEMPLATE`, `SMS_KEY` | `SMS_SENDER` (default `JEWELL`) | `senderFromEnv()` |

`SMS_URL_TEMPLATE` carries `{key}`, `{sender}`, `{mobile}`, `{text}` placeholders, so the desktop's
gateways (tripadasmsbox, ping4sms, mobileadz) and any replacement work by configuration alone.

**These names are not restated anywhere.** `readiness.ts` imports `GSP_ENV`, `WHATSAPP_ENV` and `SMS_ENV`
from the modules that read them, and a test asserts they are the *same objects*. This closed a real
defect: the readiness report previously advertised `WHATSAPP_PHONE_ID`, `WHATSAPP_TOKEN`, `SMS_BASE_URL`
and `SMS_TOKEN` — none of which is read — so an operator following it would have set variables that did
nothing and concluded the integration was broken.

## Proving it works

1. `GET /integrations/readiness` — states each integration as `ready`, `awaiting-credentials` (naming the
   exact unset variables), `awaiting-hardware`, or `disabled-by-setting`. Presence booleans only, never
   values; the GSTIN is masked.
2. `POST /integrations/verify-credentials` — a real round-trip per provider:
   - **e-Invoice**: the GSP auth endpoint, which returns a token and has no side effect.
   - **WhatsApp**: a GET on the phone-number node, which succeeds only with a valid token.
   - **SMS**: reported **`unverifiable`**, deliberately. These gateways expose no authentication
     endpoint, so the only real test is sending a chargeable message to a live handset. Reporting `ok`
     would be a guess and sending silently would cost money and reach a real person.

Neither endpoint ever returns a credential value; a test asserts that by scanning the serialized output.

## What is already proven without credentials

`apps/api/test/integrationWireContract.test.ts` asserts the exact request each provider will receive,
using an injected `fetch`:

- GSP auth hits `/eivital/dec/v1.04/auth` on the sandbox host, with every parameter present and values
  containing spaces and slashes surviving encoding; production host only when `GSP_SANDBOX=0`.
- IRN generation POSTs the payload as JSON to `/eicore/dec/v1.03/Invoice` with `QrCodeSize=250`.
- Cancellation POSTs `{Irn, CnlRsn, CnlRem}` to `/eicore/dec/v1.03/Cancel`.
- WhatsApp POSTs to `graph.facebook.com/v22.0/<phoneNumberId>/messages` with a bearer token and
  positional text components in order.
- SMS substitutes every placeholder and preserves message spacing.

This proves the integration speaks the right protocol. It cannot prove a particular shop's credentials
are valid — that is exactly what step 2 above is for.

## Two operational behaviours that would otherwise fail on day one

**Duplicate IRN (NIC `2150`).** If a submission times out and is retried, the portal reports the document
as already registered and returns the existing IRN. That is the correct answer, not an error: treating it
as a failure would permanently strand a bill the portal considers registered. `duplicateIrnFrom()` detects
the code and returns the portal's IRN with `duplicate: true`. The code is matched exactly — a different
error that happens to contain a hex string is not read as a duplicate.

**Token reuse.** NIC auth tokens last hours and the portal rate-limits authentication, so authenticating
per call would begin failing under real load. The token is cached with a five-minute safety margin and its
`TokenExpiry` is honoured. An expired-token error triggers exactly **one** re-authentication and retry —
not an unbounded loop, because repeatedly resubmitting a document to a tax portal risks a second
registration.

## Hardware

No credentials are involved; see `DEVICE-BRIDGE.md`. The scale's serial protocol is ported from
`TR_TAG_OPBL.cs` including its port profiles and character filter, the camera captures through the same
upload path as a file, and a wedge barcode scanner needs nothing because it types into the tag cell. All
three report an honest status and stay disabled without hardware, asserted in the browser suite with
proven negative controls.
