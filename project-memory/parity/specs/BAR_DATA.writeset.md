# Desktop write set — BAR_DATA

Source: `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs` — lines 9269-9283 (`dataRow2`); each row variable verified against its own `SELECT ... FROM BAR_DATA`.

- Assigned columns: **13** (13 in the desktop production schema)
- Already persisted: **9** | **MISSING: 4**

`mSG[i,c]` = tag grid, `tXxx.Text` = header field. Implement each MISSING column from its
cited expression; never invent a value.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `CO_BOOK` | 9273 | `DC_Main.MCo_Book` | **MISSING** |
| `CO_CODE` | 9270 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 9272 | `DC_Main.MCo_year` | **MISSING** |
| `DATA_TRFR` | 9281 | `"N"` | web |
| `EMP_CODE` | 9279 | `tEmpCode.Text` | web |
| `HD_VCH_NO` | 9277 | `tHdVchNo.Text` | web |
| `LC_CODE` | 9271 | `DC_Main.MLc_code` | **MISSING** |
| `MAIN_USER` | 9282 | `MainUser` | web |
| `STK_IT_CODE` | 9276 | `tItCode.Text` | web |
| `VCH_DATE` | 9275 | `mVchDate.Text` | web |
| `VCH_DESC` | 9280 | `tVchDesc.Text` | web |
| `VCH_NO` | 9274 | `tVchNo.Text` | **MISSING** |
| `VCH_TIME` | 9278 | `mVchDate.Text + " " + mTime.Text` | web |
