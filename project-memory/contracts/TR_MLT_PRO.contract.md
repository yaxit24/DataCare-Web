# TR_MLT_PRO — behaviour contract

Status: approved

> **Provenance note (2026-07-29).** This file was destroyed by an overly broad `rm project-memory/contracts/TR_*.contract.md`
> during a contract regeneration and has been **reconstructed**. Every citation below was re-verified
> line-by-line against `unified/src/csharp/DataCareNext/TR_MLT_PRO.cs` (5,243 lines) before being written
> back — nothing here is restored from memory alone. The workspace is not a Git repository, so no
> history was available to recover the original text; wording may differ from the original while the
> evidence is identical.

Melting / Pro (refining) voucher. This was the first form taken to `Status: approved` and remains the
reference for what an approved contract must contain: every rule cites `file:line`, and every formula
cites a golden-vector id.

## Numbering — dual sequence

| Rule | Citation | Behaviour |
|---|---|---|
| Visible voucher number | `TR_MLT_PRO.cs:3875` | `SELECT MAX(VCH_NO) AS VchNo FROM MLT_DATA WHERE CO_CODE … AND LC_CODE … AND CO_YEAR …` — the persisted maximum for the full scope, plus one. |
| Hidden book number | `TR_MLT_PRO.cs:3887` | `SELECT MAX(VCH_NO) AS VchNo FROM TEMP_BOOK_DATA WHERE CO_CODE … AND LC_CODE …` — a **second, independent** sequence. |

Both sequences advance under the same scope lock; the hidden number must survive an edit unchanged.

## Voucher type

| Rule | Citation | Behaviour |
|---|---|---|
| `VCH_TYPE` on all three row shapes | `:4207`, `:4267`, `:4339` | `dataRow["VCH_TYPE"] = FormBookSname` — the **configured book short name**, never a literal. Three separate row builders each stamp it, so all three must agree. |

## Detail semantics

| Rule | Citation | Behaviour |
|---|---|---|
| Issue / receipt direction | `:3942`, `:3964` | `MLT_DETL` is read back joined to `BOOK_DATA` for the adjusting book name; the two reads distinguish the OUT and IN legs. |
| Chol item code | `:4362` | `dataRow5["CHOL_IT_CODE"] = mSG_IDTL2[num4, 14]` — taken from the sub-detail grid, not the header. |
| Last IR type | `:4415` | `dataRow5["LAST_IR_TYPE"] = "X"` — a literal `X`, not derived. |

## Edit and delete

| Rule | Citation | Behaviour |
|---|---|---|
| Edit rewrites, without audit | `:4149`–`:4154` | `DELETE FROM MLT_DATA WHERE CO_CODE … LC_CODE … CO_YEAR …` then the write set is rebuilt, and `TEMP_BOOK_DATA` is re-read to preserve the hidden number. **No `DELETE_DATA` row is written on edit.** |
| Delete audits | `:4511` | `INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,BOOK_NAME,AC…)` — delete is audited, edit is not. |

## Computed fields

Melting has no per-line money formula of its own: weights flow through the shared fine-weight path, so
the applicable vector is the shared one.

| Value | Vector | Note |
|---|---|---|
| Fine weight | `GV-FINE-001` | `Format((netWt + ghatWt) × (touch + west) / 100, "0.000")` — format-string rounding, therefore half-up. |
| Rounding mechanism | `GV-ROUND-001/002` | `Math.Round` is half-to-even; a format string is half-up. |

## Review checklist

- [x] every rule cites `file:line` in the desktop source
- [x] the dual-numbering, `VCH_TYPE`, edit-without-audit and delete-with-audit invariants are implemented
- [x] each formula carries a golden-vector id
- [x] citations re-verified against source on reconstruction (2026-07-29)
