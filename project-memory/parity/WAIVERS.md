# Documented desktop-form waivers

These waivers prevent helper, demonstration, device, DTO, and integration classes from being counted as silently missing one-to-one business forms. They do **not** waive a unit that writes business data. Evidence paths are relative to the repository root.

Database-reference verification for the two helper screens used this source grep over both files:

```text
pattern: "\s*(SELECT\s+.+\s+FROM|INSERT\s+INTO|UPDATE\s+[A-Z_]+\s+SET|DELETE\s+FROM)\s
files: unified/src/csharp/DataCareNext/{MS_HELP,MS_TASTING}.cs
result: 0 files, 0 matches
```

## MS_HELP — shared in-memory lookup chooser

- **Desktop behavior/evidence:** A modal “DataCare Help” grid binds the caller-prepared `DC_Main.RsDg` dataset (`MS_HELP.cs:1099`), filters it through `DataView` objects (`MS_HELP.cs:1729-1942`), and returns selected cell values through `DC_Main.ColValue` (`MS_HELP.cs:2101-2215`). The quoted-SQL grep above returned zero matches.
- **Why no one-to-one form:** This is reusable lookup-dialog chrome, not a business-data owner or independently navigable workflow.
- **Web equivalent:** Accessible lookup controls such as `web/apps/web/components/LookupPicker.tsx` and scoped `/lookup/:entity` API results are embedded where needed.
- **User-visible consequence:** There is no separate desktop-style floating generic help window; lookup presentation, sizing, filtering keystrokes, and column layout differ by web field.

## MS_TASTING — static chart/UI experiment

- **Desktop behavior/evidence:** The screen creates two hard-coded series with points `(1..4)` and title `A Line Chart` (`MS_TASTING.cs:357-386`). Its load handler only resizes controls (`MS_TASTING.cs:283-330`). The quoted-SQL grep above returned zero matches.
- **Why no one-to-one form:** It is a UI/chart demonstration with no business inputs, reads, writes, or durable state.
- **Web equivalent:** None is required; production report/dashboard charts are implemented in their owning pages when supported by real data.
- **User-visible consequence:** Users cannot open this sample chart/demo screen.

## UT_WEB_CAM — local camera capture bridge

- **Desktop behavior/evidence:** The form hosts a DevExpress `CameraControl` (`UT_WEB_CAM.cs:204-219`) and saves `TakeSnapshot()` to either `MsBillImgPath` or `MsImagePath` (`UT_WEB_CAM.cs:227-240`). It contains no database persistence.
- **Why no one-to-one form:** Camera enumeration and local-path capture are device capabilities and belong to the device-bridge/browser-media workstream, not a CRUD form port.
- **Web equivalent:** Existing image upload/attachment surfaces can accept files; live camera capture requires a separately permissioned browser/device bridge.
- **User-visible consequence:** One-click live webcam capture to the desktop client’s configured filesystem path is unavailable.

## Data — authentication response DTO

- **Desktop behavior/evidence:** `Data` only stores authentication token fields (`AuthToken`, `ClientId`, `UserName`, `Sek`, `TokenExpiry`; `Data.cs:3-26`).
- **Why no one-to-one form:** It is a transport model, not a form or workflow and owns no persistence.
- **Web equivalent:** Typed/internal authentication and integration payloads in API modules.
- **User-visible consequence:** None; no desktop screen is removed.

## DcClass — e-invoice request aggregate DTO

- **Desktop behavior/evidence:** The constructor initializes transaction, document, seller, buyer, dispatch, shipping, item, value, and reference payload objects (`DcClass.cs:5-42`).
- **Why no one-to-one form:** It is an in-memory serialization graph consumed by e-invoice behavior, not a standalone form.
- **Web equivalent:** `web/apps/api/src/modules/einvoice/einvoice.ts` builds and validates the corresponding request payload server-side.
- **User-visible consequence:** None as a separate screen; users interact with the e-Invoice utility rather than a DTO editor.

## DcPrintClass — tag-print payload DTO

- **Desktop behavior/evidence:** The class contains only a `List<ClassTagList>` initialized by its constructor (`DcPrintClass.cs:5-14`).
- **Why no one-to-one form:** It is a print-data container and has no independent UI or persistence.
- **Web equivalent:** `web/apps/api/src/modules/stock/tagPrint.ts` and the `/txn/tag-print` page build print payloads directly.
- **User-visible consequence:** None; only the internal payload shape differs.

## ClsItemList — e-invoice line DTO/sample defaults

- **Desktop behavior/evidence:** The class declares invoice-line tax/value fields (`ClsItemList.cs:5-69`) and initializes sample/default values plus batch/attribute children (`ClsItemList.cs:71-105`).
- **Why no one-to-one form:** It is an e-invoice JSON line model, not an independently usable data-entry screen and performs no persistence.
- **Web equivalent:** Server-side e-invoice line mapping and validation in `web/apps/api/src/modules/einvoice/einvoice.ts`.
- **User-visible consequence:** There is no raw DTO/sample-value editor; normal transaction forms supply invoice lines.

## Translator — Google translation helper

- **Desktop behavior/evidence:** `Translate` downloads Google Translate output to a temporary file, parses text, and constructs a speech URL (`Translator.cs:31-98`).
- **Why no one-to-one form:** It is an outbound integration helper with no standalone form and no business-data persistence.
- **Web equivalent:** No general translation endpoint is currently exposed; localized labels/content should be handled by a dedicated i18n/integration design.
- **User-visible consequence:** Ad-hoc Google translation/speech generation invoked by desktop callers is unavailable in the web application.

## OlockerService — insurance-policy integration helper

- **Desktop behavior/evidence:** The class authenticates against Olocker (`OlockerService.cs:32-86`), reads scoped sale/item/customer details from `SL_DETL`, `SL_IDTL`, `AC_MAST`, and `ITEM_MAST` (`OlockerService.cs:88-119,170-215`), posts a policy request, and opens the returned URL (`OlockerService.cs:120-167`). No INSERT, UPDATE, or DELETE is present; it does not persist business data.
- **Why no one-to-one form:** Despite inheriting `Form`, it is a callable external-service adapter with an empty designer surface, not a user-entered business master/form.
- **Web equivalent:** None currently; it would require a separately secured insurance integration attached to sale workflows. The existing e-invoice integration is not treated as equivalent.
- **User-visible consequence:** Users cannot generate/open Olocker insurance policies from a sale in the web application.

## TR_PR_SL_UAE — UAE VAT sale variant

**Waiver type:** business scope decision (owner, 2026-07-28) — "for now we don't need the UAE thing".

**What the desktop units do.** `TR_PR_SL_UAE.cs` (11,067 lines) and `TR_SALE_RTN_UAE.cs` (11,445 lines)
are UAE-market variants of the retail sale and sale-return forms. They carry their own VAT treatment
and write largely the same families as the Indian forms (`AC_DATA`, `APR_DETL`, `BAR_DATA`/`BAR_DETL`/
`BAR_IDTL`, `DM_DATA`, `MAIN_STOCK`, `TAX_DATA`, `TEMP_BOOK_DATA`, plus `BILL_OS_DATA`, `SL_ORD_ADJ`,
`SL_PR_DETL`, `SRNO_MAST`, `PRINT_MAST` for the return).

**Why no web form is being built.** The deployment in scope is the Indian GST configuration. Both
units are jurisdiction-specific alternatives, not additional capability for this deployment, and each
would require its own VAT rule extraction, book configuration and certification pass.

**Web equivalent.** None. The Indian `TR_SALE` and `TR_SALE_RTN` engines are fully implemented with
open/edit/delete lifecycles and are unaffected.

**What a user loses.** A UAE-jurisdiction shop cannot bill or accept returns under UAE VAT in the web
application. Indian operation is unaffected. If UAE becomes in scope this waiver must be revoked and
both forms implemented and certified like any other transaction family; the desktop sources remain
extracted and available.

## TR_SALE_RTN_UAE — UAE VAT sale-return variant

**Waiver type:** business scope decision (owner, 2026-07-28) — "for now we don't need the UAE thing".

**What the desktop units do.** `TR_PR_SL_UAE.cs` (11,067 lines) and `TR_SALE_RTN_UAE.cs` (11,445 lines)
are UAE-market variants of the retail sale and sale-return forms. They carry their own VAT treatment
and write largely the same families as the Indian forms (`AC_DATA`, `APR_DETL`, `BAR_DATA`/`BAR_DETL`/
`BAR_IDTL`, `DM_DATA`, `MAIN_STOCK`, `TAX_DATA`, `TEMP_BOOK_DATA`, plus `BILL_OS_DATA`, `SL_ORD_ADJ`,
`SL_PR_DETL`, `SRNO_MAST`, `PRINT_MAST` for the return).

**Why no web form is being built.** The deployment in scope is the Indian GST configuration. Both
units are jurisdiction-specific alternatives, not additional capability for this deployment, and each
would require its own VAT rule extraction, book configuration and certification pass.

**Web equivalent.** None. The Indian `TR_SALE` and `TR_SALE_RTN` engines are fully implemented with
open/edit/delete lifecycles and are unaffected.

**What a user loses.** A UAE-jurisdiction shop cannot bill or accept returns under UAE VAT in the web
application. Indian operation is unaffected. If UAE becomes in scope this waiver must be revoked and
both forms implemented and certified like any other transaction family; the desktop sources remain
extracted and available.

## BTN_NAME — Desktop start-menu selection

Desktop loads `BTN_NAME` into `MsMainBtn` at `MS_OPNCOMP.cs:661`; `MDI_FORM.cs:7052,11537` uses it only to choose/filter the initially visible navigation button group. It does not calculate or persist business data. The web already has its own navigation shell, so no compatibility behavior is built; users lose only the configurable desktop landing menu.

## THEME — Desktop colour theme

Desktop loads `THEME` into `MsCoTheme` at `MS_OPNCOMP.cs:662`; consumers such as `MDI_FORM.cs:11397-11409` and transaction-form theme branches only assign colours/styles. It has no computational or persisted effect. The web theme is independently styled; users lose the company-selected WinForms palette.

## SL_ROW_CHANGE — Sale-grid row navigation

Desktop loads `SL_ROW_CHANGE` into `MsSlRowChange` at `MS_OPNCOMP.cs:673`; consumers such as `TR_SALE.cs:12720` only change which grid row receives focus after entry. No value, validation, or write changes. The web uses browser-native form/grid navigation; users lose this desktop focus preference.

## RATE_MAST_OPEN — Auto-open daily rate screen

Desktop loads `RATE_MAST_OPEN` at `MS_OPNCOMP.cs:676`; login/MDI consumers only decide whether to open the rate-master window. Rates themselves are not changed by the flag. Web users navigate to rates explicitly, so they lose only automatic screen opening.

## HELP_SERCH — Help-picker search mode

Desktop loads `HELP_SERCH` into `MsHelpSearch` at `MS_OPNCOMP.cs:683`; `MS_HELP.cs:1745-1994,2349-2382` switches lookup-grid search interaction. It does not change selected master data or persistence. The web lookup component has one search model; users lose the selectable WinForms search mode.

## REMINDER_OPEN — Auto-open reminder screen

Desktop loads `REMINDER_OPEN` at `MS_OPNCOMP.cs:692`; `MDI_FORM.cs:11504` only opens the reminder window during shell startup. No reminder record or calculation changes. Web users lose only automatic opening, not stored reminder data.

## GRID_SCROLL — Grid scrollbar/navigation preference

Desktop loads `GRID_SCROLL` at `MS_OPNCOMP.cs:698`; consumers such as `TR_SALE.cs:9069` and `TR_PURC.cs:6490,8967` alter grid scrolling/navigation. No entered values or writes differ. Browser grids use native scrolling; users lose this WinForms navigation preference.

## DUP_PRINT — Extra printed copy

Desktop loads `DUP_PRINT` into `MsSlDupPrint` at `MS_OPNCOMP.cs:703`; consumers such as `TR_SALE.cs:16442` and `TR_PURC.cs:13959` request an additional print copy only. Voucher data and totals are unchanged. The web does not auto-duplicate print jobs; users may manually choose copy count.

## LEDR_BILL_COL — Ledger bill-column visibility

Desktop loads `LEDR_BILL_COL` at `MS_OPNCOMP.cs:716`; `RP_LEDR.cs:6922` only adds/hides the Bill column. It does not alter ledger rows, balances, or grouping. The web keeps a stable report schema; users lose this column-visibility default.

## STK_RPT_VIEW — Unloaded legacy registry key

`STK_RPT_VIEW` exists in the schema/registry, but exhaustive `DataCareNext/*.cs` search finds no `MS_OPNCOMP.cs` load and no `DC_Main` consumer; the actual stock weight-source key is `STOCK_RPT_TYPE` (`MS_OPNCOMP.cs:711`, `Ac_Stock.cs:112-113`). Building behavior for this spelling would be invented. Users lose nothing because the desktop never reads it.

## SalesQuotation — partial Crystal extraction

- **Evidence:** `unified/reports/SalesQuotation.rpt` exists (237,524 bytes), but `extraction_output/rpt_xml/SalesQuotation.xml` ends malformed at line 2908 (`no element found: line 2908, column 22`). The local recovery parser preserves a valid prefix with 30 sections, 155 positioned objects, and 34 formulas; `web/apps/api/report-specs/SalesQuotation.spec.json` is explicitly marked `status: partial`.
- **Why waived:** Reconstructing the missing XML tail cannot be done from the proprietary RPT stream on macOS. A fresh extraction requires the Windows SAP Crystal .NET runtime/RptToXml toolchain.
- **Web consequence:** Quotation preview/rendering uses the recovered prefix and is contract-tested, but exact final sections, objects, suppression, and pagination remain uncertified and must not be described as pixel-exact.

## TagStkIdtlRpt — unavailable legacy Crystal extraction

- **Evidence:** `unified/reports/TagStkIdtlRpt.rpt` exists (100,323 bytes), but there is no `TagStkIdtlRpt.xml` or layout spec in `extraction_output/rpt_xml`, `project-memory/catalogs/report-layouts`, or `web/apps/api/report-specs`. Prior extraction evidence identifies it as an older Seagate Crystal OLE report unreadable by the available extractor.
- **Why waived:** Exact geometry requires a compatible Windows Crystal reader/runtime; inventing a layout or substituting `TagStkRpt` would conceal the missing report.
- **Web consequence:** No exact `TagStkIdtlRpt` preview/render exists. The matrix records an explicit waiver instead of a silent `not_started` row; the waiver must be removed when compatible extraction evidence is obtained.

## FIREBASE-SYNC — bundled FireSharp integration without a callable desktop contract

- **Desktop evidence:** `project-memory/catalogs/completeness-manifest.json:4888-4894` records `FireSharp.dll` as present but with `referencedBy: []`. `project-memory/catalogs/integrations-scan.json:11-20` finds generic `GetAsync`/`PushAsync`/`SetAsync` signals inside integration binaries, while an exhaustive extracted `DataCareNext/*.cs` search finds no `FireSharp`, `FirebaseClient`, or `FirebaseConfig` call site.
- **Decision:** Waived until a callable desktop workflow, Firebase path/schema, direction of synchronization, conflict policy, and credential owner can be evidenced. Implementing a sync from DLL method-name signals alone would invent business writes and security behavior.
- **Web consequence:** No Firebase realtime mirror is run. PostgreSQL remains authoritative; no record is silently exported to a third party.
- **Unwaive condition:** Supply the desktop caller or an owner-approved data contract, test Firebase project credentials, retention/security rules, and conflict/retry acceptance cases.

## SELENIUM-WHATSAPP — local WhatsApp Web automation fallback

- **Desktop evidence:** `extracted_code/DataCareNext/DataCareNext/Module_WhatsApp.cs:23-26` imports Selenium/Chrome; `:809-879` creates a persistent local Chrome profile and opens `https://web.whatsapp.com`; the class exposes QR/authentication states at `:34-57`.
- **Decision:** The fallback is waived because the web already uses the supported Meta Graph Cloud API for text, approved templates, and documents in `web/apps/api/src/modules/integrations/messaging.ts`. Reintroducing server-side browser automation would require interactive QR login, persistent personal browser state, ChromeDriver lifecycle, and brittle DOM selectors without adding a business-data capability.
- **Web consequence:** Shops must configure Cloud API credentials (or an SMS gateway); they cannot fall back to automating a staff member's WhatsApp Web session.
- **Unwaive condition:** An owner explicitly requires the unsupported fallback and approves its account custody, interactive authentication, driver patching, availability, and WhatsApp terms/security risks.

## 2026-07-28 — Phase D / Phase F decisions

### MENU_DATA — waived (architectural equivalence, evidence-based)
`MS_USER.cs:3486-4872` seeds `MENU_DATA` with ~200 hardcoded `INSERT` statements that define the
desktop's MDI menu tree (button group, submenu code, caption, `SM_VIEW` visibility, `SM_TYPE`,
`TILE_ITEM`). The desktop builds its menu *from that table at runtime*; the web's navigation is
defined in code and its per-form rights come from `USER_SET` (already implemented and tested), so
nothing in the web reads `MENU_DATA`. Writing 200 configuration rows no reader consumes would be
motion without value. Same class as the previously waived `TILE_DATA` and `TAG_SET`.
**Revocation condition:** if a runtime-editable menu (admin reorders/hides menu entries) is
introduced, `MENU_DATA` becomes its store and this waiver must be revoked.

### DESIGN_DETL — open, not waived
`MS_DESIGN_BOOK.cs:5790` writes 34 columns of design-book detail. This is a master **form** the web
has not ported (design book with page/die/size/weight/labour columns), not a column top-up on an
existing writer. Recorded as open Phase F work rather than skipped.

### TR_PHYSTK tag re-issue — open, not waived
`TR_PHYSTK.cs:3903-3905` re-tags stock by copying a `BAR_DETL` + `BAR_IDTL` row into a new voucher
(96 and 50 columns respectively). The web's physical stock **reconciles only and never writes tag
rows**, which is a deliberate invariant. The residual `BAR_DETL` (4) and `BAR_IDTL` (9) columns
belong to that unported feature, so they are not column gaps on an existing writer.

### Company provisioning — implemented
`MS_YEAR.cs:1511-1553` clones 17 master/configuration tables when a company is provisioned. Now
implemented as `masters/companyClone.ts` with the column list of every table extracted from the
desktop statement (each entry records its source line), wired into year creation and covered by
`companySettings.db.test.ts`. Non-destructive by default so opening a new year cannot wipe live
masters; `replace: true` reproduces the desktop copy-company behaviour.

## 2026-07-29 — Phase E validation waivers (condition-based, not convenience)

Each of these was waived only after reading the desktop's own condition; the wording alone would have
led to the wrong decision.

### `Please Insert Cr Days And Try...` — waived, per-installation customisation
`TR_SALE.cs` condition: `(DC_Main.SSRegSrNo = 'VK217NEVK' OR DC_Main.SSRegSrNo = 'VS233NEBU') AND …`
The rule is gated on two specific **licence serial numbers**, i.e. it only ever fires for two named
customer installations. Enforcing it universally would block credit sales for every other shop.
**Revocation condition:** if either installation is migrated, the rule must be re-introduced behind an
equivalent per-tenant switch.

### `This Function Not Working in Your Software Virson Please Upgrad Advance or Enterprise Then Try` — waived
An edition/licence gate for the desktop product tiers (Advance / Enterprise). The web deployment has no
edition tiering, so there is no condition under which it could fire.

### `New Report is Insert ok...Please This Form Close And Reopen...` — waived
A post-action notice from the desktop's report designer telling the operator to reopen the MDI form so
a newly registered report appears. The web has no MDI form lifecycle; report specs are loaded per
request. Classified `notice` by `validation_audit.py` in any case.

### `Please Save This Voucher Then Effect....` / `Please First Save Voucher and Reopen Voucher and try...`
**Open, UI-level.** These fire when the operator presses an action button that needs a persisted
voucher (print, e-invoice, adjust). They belong on the pages, not the API — the API cannot be reached
without a voucher number. Recorded as open Phase D/E UI work rather than waived, because the guard is
real: the web should block the same actions with the same wording instead of failing later.

## 2026-07-29 — `Please Check Len Connection...You Cant Save Image...` waived (16 forms)

The largest remaining unmatched cluster, and not a precondition guard at all. In `MS_ACCT.cs` and its
siblings the message sits in a **decompiled error handler** (`case 556` of the `On Error` switch) wrapping

```
PicImage.Image.Save(DC_Main.MSImageSavePath + "\" + DC_Main.MsImageType + "\" + DC_Main.MsImageNo + ".jpg")
```

i.e. it fires when writing the JPEG to the shop's **LAN file share** fails. `MSImageSavePath` is a UNC
path, which is why the wording talks about a "Len" (LAN) connection.

The web does not write images to a file share: party photos are stored **in the database** as
`AC_IMAGE.AC_IMAGE` (bytea, keyed `CO_CODE + AC_CODE`, `masters/party.ts`), and repair images likewise go
through `repair/repairImage.ts`. A storage failure therefore surfaces as a transaction error on the same
connection that is already required for the request to exist at all — there is no separate share whose
reachability could be reported.

**Revocation condition:** if image storage is ever moved to an external object store or file share, the
failure path must report this message so operators recognise it.

### Also waived here
- `Please check your internet connection` (2 forms) — same shape: a network error handler around the
  messaging provider call. The web's `notifyWithAttemptLog` already records provider failures per attempt
  with an idempotency key, which is strictly more information than the desktop's modal.

## 2026-07-29 (second batch) — three more licence-serial gated rules waived

The same pattern as `Please Insert Cr Days And Try...`: the rule exists only for one named installation,
identified by `DC_Main.SSRegSrNo`. Enforcing any of them for every tenant would break shops that never
had the rule.

| Message | Form | Gating serial |
|---|---|---|
| `Please Insert Ref No Then Try....` | `TR_TOUR_SALE` | `HM037NEKU` |
| `Please Select Delevery Date and Try......` | `TR_SALE_ORD` | `VK115NEVK` |
| `Please Insert City and Mobile no Then Try....` | `MS_ACCT` | `SSRegSrNo` comparison |

**Revocation condition (all three):** if one of these installations is migrated, re-introduce the rule
behind an equivalent per-tenant switch rather than globally.

This makes **four** licence-gated rules found so far. Worth stating as a pattern: a message's wording
never reveals this — only reading `when` does. Any future rule that looks oddly specific should be
checked for an `SSRegSrNo` comparison before being implemented.

## 2026-07-29 (third batch) — fifth licence-serial gated rule

`TR_SALE.cs` old-gold grid: one branch of `cUrConWt` (conversion weight) is gated on
`DC_Main.SSRegSrNo = "KJ001NEKJ"`, computing `netWt * Con% / 100` without rounding instead of the general
`Math.Round(fine * Con% / 100, 3)`. Per-installation customisation; not implemented.

**Revocation condition:** if that installation is migrated, add the branch behind a per-tenant switch.

Running total of licence-serial gated rules found: **five**. The pattern is now expected rather than
surprising — check `when` for an `SSRegSrNo` comparison before implementing any oddly specific rule.

## 2026-07-29 (fourth batch) — sixth licence-serial gated rule

`ThenPlease Insert Fine In Party Fine.....` (`TR_PURC.cs`) is gated on **two** conditions:
`FormMainBook = 'OLD ITEM SALES'` **and** `DC_Main.SSRegSrNo = 'HM285NEKU'`. Per-installation.

**Revocation condition:** if that installation is migrated, add it behind a per-tenant switch.

Running total of licence-serial gated rules: **six** (`VK217NEVK`/`VS233NEBU`, `HM037NEKU`, `VK115NEVK`,
MS_ACCT city+mobile, `KJ001NEKJ`, `HM285NEKU`).

## 2026-07-29 — the final three unwritten tables (42 columns), column depth at 98.9%

Every other desktop-written column is now written by the web. These three are the residue, and each is
waived on evidence rather than effort.

### `TAG_STOCK` (25 columns) — absent from the desktop's own schema
`MS_PRODUCT.cs` writes `INSERT INTO TAG_STOCK(...)`, but **`TAG_STOCK` does not exist in the extracted
desktop production schema** (`realdb-schema-full.json` contains `TAG_STOCK_PRINT` and no `TAG_STOCK`). The
desktop therefore targets a table its own database lacks — the same class as the 22 stale Crystal alias
tables and the `MAIL_API` column already documented.

The web nevertheless *does* write it (`stock.ts` `insertTagTx`, now governed by an explicit
`TAG_STOCK_COLUMNS` set matching the desktop's 25 names exactly). The audit cannot credit those columns
because crediting requires the table to be present in the desktop schema catalog, which is the correct
conservative rule — loosening it would let any invented table claim coverage.

**Revocation condition:** if a desktop schema snapshot containing `TAG_STOCK` is supplied, this becomes a
measured 25/25 with no code change.

### `MENU_DATA` (9 columns) — waived 2026-07-28, also absent from the desktop schema
The desktop seeds ~200 hardcoded rows for its MDI runtime menu. Web navigation is code-defined and rights
come from `USER_SET`; nothing reads it. It is *also* missing from the desktop schema snapshot.

### `TAG_SET` (8 columns) — waived, picker cache
A grid-picker cache the desktop repopulates per session. The web's pickers query live data.

### Not counted at all
`APP_CHATMESSAGES` and `WEBHOOKINBOX` have **zero desktop-written columns** — the desktop references them
with no column list, so there is nothing to write and nothing to measure.

### Position on the 99% target
Column depth stands at **98.9%** (3,627 of 3,669). Excluding the two provably-stale tables (`TAG_STOCK`,
`MENU_DATA` = 34 columns), the reachable denominator is 3,635 and coverage against it is **99.8%**. The
published figure stays 98.9% because the audit's denominator is the desktop's write set as extracted, and
lowering a denominator to improve a percentage is exactly the manipulation this project has avoided
throughout.
