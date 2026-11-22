# WP-21 Company → Books: frozen case list (T01 to T18)

Menu: Company → Books, desktop `MS_BOOK`, web `/masters/books`. Source study: `orchestration/work/WP-21/study.md` (13 gaps, G1 to G13 below mean gap numbers 1 to 13 of that study). Desktop match today is 0%: the web has the generic master form and no slot grid, so every case that touches a slot, a guard or a message fails today.

Supervisor decisions applied (they override the study where they differ):

- D1 Slot authority: the `MS_UPDATE.cs` templates below define each family's slots, meaning, direction and default account; the web seed is wrong where it differs (gaps 7 to 11).
- D2 The operator types the code (at most 3 characters); the web adds no code generator.
- D3 Delete follows the desktop guards and removes header and slots in one transaction.
- D4 Changing the family of a book that has vouchers is refused by the web. This is a deliberate difference from the desktop (no desktop guard exists). The message is a plain web message: `This book already has vouchers, so its Transaction Name cannot be changed.` It is listed under "Not covered" for owner confirmation.
- D5 Blank slot accounts are allowed on save; the stored Data Type for a blank is `A`.
- D6 Not ported: the Ctrl+O lock override and the A/E footer reset. Each is expected absent.
- D7 Print: without the Print right the desktop message `You Have No Print Rights.....` is shown; with it the desktop does nothing. The web CSV export stays behind the Print right (web addition).

Notation: "slot n" means the `BOOK_DETL` row with `SR_NO` n. Account codes are the desktop template codes (`00001` and so on); the test company must contain accounts with those codes (see Test data).

## Family-to-slot table the tests assert (desktop templates)

Each row: slot number / default account / description / direction (I = Inword, O = Outword), with the `MS_UPDATE.cs` line that inserts it. These are the latest source patches, not a full runtime table. MISSING: baseline `BOOK_IDTL` definitions for SALES, SALES RETURNE, PURCHASE slots 1 to 4, PURC RETURN, CASH REC/PAY, BANK REC/PAY, SALES ORDER, ORDER CANCEL, CONTRA, JOURNAL, approval, stock and other preexisting families. For those families no case asserts a default slot account; cases assert only the account the operator configured.

| Family | Source patch slots: number / account / description / direction |
|---|---|
| ITEM SALES | 1 / 00003 / SALES GOLD A/C / O — MS_UPDATE.cs:7328 {{VALUES ('ITEM SALES',1,'O','00003','SALES GOLD A/C'}}; 2 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:7332 {{VALUES ('ITEM SALES',2,'O','00001','CASH ON HAND'}}; 3 / 00041 / LABOUR INCOM. A/C / O — MS_UPDATE.cs:7336 {{VALUES ('ITEM SALES',3,'O','00041','LABOUR INCOM. A/C'}}; 4 / 00057 / KASAR JAVK A/C / O — MS_UPDATE.cs:7340 {{VALUES ('ITEM SALES',4,'O','00057','KASAR JAVK A/C'}}; 5 / 00076 / DISCOUNT A/C / O — MS_UPDATE.cs:7344 {{VALUES ('ITEM SALES',5,'O','00076','DISCOUNT A/C'}}; 6 / 00020 / ORDER ADVANCE / O — MS_UPDATE.cs:7348 {{VALUES ('ITEM SALES',6,'O','00020','ORDER ADVANCE'}} |
| ITEM PURC | 1 / 00008 / PURCHASE A/C / O — MS_UPDATE.cs:7360 {{VALUES ('ITEM PURC',1,'O','00008','PURCHASE A/C'}}; 2 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:7364 {{VALUES ('ITEM PURC',2,'O','00001','CASH ON HAND'}}; 3 / 00056 / LABOUR EXP A/C / O — MS_UPDATE.cs:7368 {{VALUES ('ITEM PURC',3,'O','00056','LABOUR EXP A/C'}}; 4 / 00042 / KASAR AVAK A/C / O — MS_UPDATE.cs:7372 {{VALUES ('ITEM PURC',4,'O','00042','KASAR AVAK A/C'}}; 5 / 00076 / DISCOUNT A/C / O — MS_UPDATE.cs:7376 {{VALUES ('ITEM PURC',5,'O','00076','DISCOUNT A/C'}} |
| E INVOICE | 1 / 00003 / SALES GOLD A/C / O — MS_UPDATE.cs:18593 {{VALUES ('E INVOICE',1,'O','00003','SALES GOLD A/C'}}; 2 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:18601 {{VALUES ('E INVOICE',2,'O','00001','CASH ON HAND'}}; 3 / 00057 / KASAR JAVK A/C / O — MS_UPDATE.cs:18609 {{VALUES ('E INVOICE',3,'O','00057','KASAR JAVK A/C'}}; 4 / 00020 / ORDER ADVANCE / O — MS_UPDATE.cs:18617 {{VALUES ('E INVOICE',4,'O','00020','ORDER ADVANCE'}}; 5 / 00076 / DISCOUNT A/C / O — MS_UPDATE.cs:18625 {{VALUES ('E INVOICE',5,'O','00076','DISCOUNT A/C'}}; 6 / 00041 / LABOUR INCOM. A/C / O — MS_UPDATE.cs:18633 {{VALUES ('E INVOICE',6,'O','00041','LABOUR INCOM. A/C'}} |
| CON PUR | 1 / 00008 / PURCHASE GOLD A/C / I — MS_UPDATE.cs:21415 {{VALUES ('CON PUR',1,'I','00008','PURCHASE GOLD A/C'}}; 2 / 00001 / CASH ON HAND / I — MS_UPDATE.cs:21419 {{VALUES ('CON PUR',2,'I','00001','CASH ON HAND'}}; 3 / 00042 / KASAR AVAK A/C. / I — MS_UPDATE.cs:21423 {{VALUES ('CON PUR',3,'I','00042','KASAR AVAK A/C.'}}; 4 / 00056 / LABOUR EXP A/C / I — MS_UPDATE.cs:21427 {{VALUES ('CON PUR',4,'I','00056','LABOUR EXP A/C'}} |
| OTH EXP | 1 / 00008 / PURCHASE A/C / O — MS_UPDATE.cs:22852 {{VALUES ('OTH EXP',1,'O','00008','PURCHASE A/C'}}; 2 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:22860 {{VALUES ('OTH EXP',2,'O','00001','CASH ON HAND'}}; 3 / 00042 / KASAR AVAK A/C / O — MS_UPDATE.cs:22868 {{VALUES ('OTH EXP',3,'O','00042','KASAR AVAK A/C'}} |
| OTH INC | 1 / 00099 / SALES A/C / I — MS_UPDATE.cs:22876 {{VALUES ('OTH INC',1,'I','00099','SALES A/C'}}; 2 / 00001 / CASH ON HAND / I — MS_UPDATE.cs:22884 {{VALUES ('OTH INC',2,'I','00001','CASH ON HAND'}}; 3 / 00057 / KASAR JAVK A/C / I — MS_UPDATE.cs:22892 {{VALUES ('OTH INC',3,'I','00057','KASAR JAVK A/C'}} |
| LABOUR WORK | 8 / 00004 / SALES SILVER A/C / I — MS_UPDATE.cs:23749 {{VALUES ('LABOUR WORK',8,'I','00004','SALES SILVER A/C'}}; 9 / 00009 / PURCHASE SILVER A/C / I — MS_UPDATE.cs:23753 {{VALUES ('LABOUR WORK',9,'I','00009','PURCHASE SILVER A/C'}}; 10 / 00005 / SALES OLD GOLD A/C / I — MS_UPDATE.cs:23757 {{VALUES ('LABOUR WORK',10,'I','00005','SALES OLD GOLD A/C'}}; 11 / 00006 / SALES OLD SILVER A/C / I — MS_UPDATE.cs:23761 {{VALUES ('LABOUR WORK',11,'I','00006','SALES OLD SILVER A/C'}} |
| PURCHASE | 5 / 00076 / DISCOUNT A/C / I — MS_UPDATE.cs:25022 {{VALUES ('PURCHASE',5,'I','00076','DISCOUNT A/C'}} |
| E CRNT | 1 / 00003 / SALES GOLD A/C / I — MS_UPDATE.cs:27519 {{VALUES ('E CRNT',1,'I','00003','SALES GOLD A/C'}}; 2 / 00001 / CASH ON HAND / I — MS_UPDATE.cs:27527 {{VALUES ('E CRNT',2,'I','00001','CASH ON HAND'}}; 3 / 00042 / KASAR AVAK A/C / I — MS_UPDATE.cs:27535 {{VALUES ('E CRNT',3,'I','00042','KASAR AVAK A/C'}}; 4 / 00076 / DISCOUNT A/C / I — MS_UPDATE.cs:27543 {{VALUES ('E CRNT',4,'I','00076','DISCOUNT A/C'}} |
| OTH COMM | 1 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:27567 {{VALUES ('OTH COMM',1,'O','00001','CASH ON HAND'}}; 2 / 00044 / COMMISION INCOM A/C / O — MS_UPDATE.cs:27575 {{VALUES ('OTH COMM',2,'O','00044','COMMISION INCOM A/C'}}; 3 / 00057 / KASAR JAVK A/C / O — MS_UPDATE.cs:27583 {{VALUES ('OTH COMM',3,'O','00057','KASAR JAVK A/C'}} |
| WH RTN | 1 / 00003 / SALES GOLD A/C / I — MS_UPDATE.cs:28164 {{VALUES ('WH RTN',1,'I','00003','SALES GOLD A/C'}}; 2 / 00004 / SALES SILVER A/C / I — MS_UPDATE.cs:28168 {{VALUES ('WH RTN',2,'I','00004','SALES SILVER A/C'}}; 3 / 00001 / CASH ON HAND / I — MS_UPDATE.cs:28172 {{VALUES ('WH RTN',3,'I','00001','CASH ON HAND'}}; 4 / 00041 / LABOUR INCOM. A/C / I — MS_UPDATE.cs:28176 {{VALUES ('WH RTN',4,'I','00041','LABOUR INCOM. A/C'}}; 5 / 00042 / KASAR AVAK A/C / I — MS_UPDATE.cs:28180 {{VALUES ('WH RTN',5,'I','00042','KASAR AVAK A/C'}}; 6 / 00077 / OTHER CHARGES A/C / I — MS_UPDATE.cs:28184 {{VALUES ('WH RTN',6,'I','00077','OTHER CHARGES A/C'}}; 7 / 00098 / FINE KASAR / I — MS_UPDATE.cs:28188 {{VALUES ('WH RTN',7,'I','00098','FINE KASAR'}} |
| LD ADJUST | 1 / 00042 / KASAR AVAK A/C. / I — MS_UPDATE.cs:28472 {{VALUES ('LD ADJUST',1,'I','00042','KASAR AVAK A/C.'}}; 2 / 00057 / KASAR JAVK A/C / I — MS_UPDATE.cs:28476 {{VALUES ('LD ADJUST',2,'I','00057','KASAR JAVK A/C'}}; 3 / 00098 / FINE KASAR / I — MS_UPDATE.cs:28480 {{VALUES ('LD ADJUST',3,'I','00098','FINE KASAR'}} |
| FINE PURC | 1 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:28696 {{VALUES ('FINE PURC',1,'O','00001','CASH ON HAND'}}; 2 / 00008 / PURCHASE A/C / O — MS_UPDATE.cs:28700 {{VALUES ('FINE PURC',2,'O','00008','PURCHASE A/C'}}; 3 / 00009 / PURCHASE SILVER A/C / O — MS_UPDATE.cs:28704 {{VALUES ('FINE PURC',3,'O','00009','PURCHASE SILVER A/C'}}; 4 / 00057 / KASAR AVAK A/C / O — MS_UPDATE.cs:28708 {{VALUES ('FINE PURC',4,'O','00057','KASAR AVAK A/C'}}; 5 / 00076 / DISCOUNT A/C / O — MS_UPDATE.cs:28712 {{VALUES ('FINE PURC',5,'O','00076','DISCOUNT A/C'}}; 6 / 00056 / LABOUR EXP A/C / O — MS_UPDATE.cs:28716 {{VALUES ('FINE PURC',6,'O','00056','LABOUR EXP A/C'}} |
| FINE SALE | 1 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:28728 {{VALUES ('FINE SALE',1,'O','00001','CASH ON HAND'}}; 2 / 00003 / SALES GOLD A/C / O — MS_UPDATE.cs:28732 {{VALUES ('FINE SALE',2,'O','00003','SALES GOLD A/C'}}; 3 / 00004 / SALES SILVER A/C / O — MS_UPDATE.cs:28736 {{VALUES ('FINE SALE',3,'O','00004','SALES SILVER A/C'}}; 4 / 00057 / KASAR JAVK A/C / O — MS_UPDATE.cs:28740 {{VALUES ('FINE SALE',4,'O','00057','KASAR JAVK A/C'}}; 5 / 00076 / DISCOUNT A/C / O — MS_UPDATE.cs:28744 {{VALUES ('FINE SALE',5,'O','00076','DISCOUNT A/C'}}; 6 / 00041 / LABOUR INCOME A/C / O — MS_UPDATE.cs:28748 {{VALUES ('FINE SALE',6,'O','00041','LABOUR INCOME A/C'}} |
| TAG PURCHASE | 5 / 00076 / DISCOUNT A/C / I — MS_UPDATE.cs:30221 {{VALUES ('TAG PURCHASE',5,'I','00076','DISCOUNT A/C'}} |
| AMT IN | 1 / 00057 / KASAR JAVK A/C / I — MS_UPDATE.cs:30265 {{VALUES ('AMT IN',1,'I','00057','KASAR JAVK A/C'}} |
| AMT OUT | 1 / 00042 / KASAR AVAK A/C / O — MS_UPDATE.cs:30269 {{VALUES ('AMT OUT',1,'O','00042','KASAR AVAK A/C'}} |
| TOUR SALES | 1 / 00003 / SALES GOLD A/C / O — MS_UPDATE.cs:31433 {{VALUES ('TOUR SALES',1,'O','00003','SALES GOLD A/C'}}; 2 / 00008 / PURCHASE GOLD A/C / O — MS_UPDATE.cs:31437 {{VALUES ('TOUR SALES',2,'O','00008','PURCHASE GOLD A/C'}}; 3 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:31441 {{VALUES ('TOUR SALES',3,'O','00001','CASH ON HAND'}}; 4 / 00057 / KASAR JAVK A/C / O — MS_UPDATE.cs:31445 {{VALUES ('TOUR SALES',4,'O','00057','KASAR JAVK A/C'}}; 5 / 00042 / KASAR AVAK A/C / O — MS_UPDATE.cs:31449 {{VALUES ('TOUR SALES',5,'O','00042','KASAR AVAK A/C'}}; 6 / 00041 / LABOUR INCOME A/C / O — MS_UPDATE.cs:31453 {{VALUES ('TOUR SALES',6,'O','00041','LABOUR INCOME A/C'}}; 7 / 00056 / LABOUR EXP A/C / O — MS_UPDATE.cs:31457 {{VALUES ('TOUR SALES',7,'O','00056','LABOUR EXP A/C'}}; 8 / 00004 / SALES SILVER A/C / O — MS_UPDATE.cs:31461 {{VALUES ('TOUR SALES',8,'O','00004','SALES SILVER A/C'}}; 9 / 00009 / PURCHASE SILVER A/C / O — MS_UPDATE.cs:31465 {{VALUES ('TOUR SALES',9,'O','00009','PURCHASE SILVER A/C'}}; 10 / 00061 / INTEREST INCOME A/C / O — MS_UPDATE.cs:31469 {{VALUES ('TOUR SALES',10,'O','00061','INTEREST INCOME A/C'}}; 11 / 00077 / OTHER CHARGES A/C / O — MS_UPDATE.cs:31473 {{VALUES ('TOUR SALES',11,'O','00077','OTHER CHARGES A/C'}}; 12 / 00098 / FINE KASAR / O — MS_UPDATE.cs:31477 {{VALUES ('TOUR SALES',12,'O','00098','FINE KASAR'}} |
| TOUR ORDER | 1 / 00001 / CASH ON HAND / I — MS_UPDATE.cs:31827 {{VALUES ('TOUR ORDER',1,'I','00001','CASH ON HAND'}} |
| TAG SPLIT | 1 / 00001 / CASH ON HAND / O — MS_UPDATE.cs:32078 {{VALUES ('TAG SPLIT',1,'O','00001','CASH ON HAND'}}; 2 / 00057 / KASAR JAVK A/C / O — MS_UPDATE.cs:32082 {{VALUES ('TAG SPLIT',2,'O','00057','KASAR JAVK A/C'}}; 3 / 00042 / KASAR AVAK A/C / O — MS_UPDATE.cs:32086 {{VALUES ('TAG SPLIT',3,'O','00042','KASAR AVAK A/C'}}; 4 / 00041 / LABOUR INCOME A/C / O — MS_UPDATE.cs:32090 {{VALUES ('TAG SPLIT',4,'O','00041','LABOUR INCOME A/C'}}; 5 / 00056 / LABOUR EXP A/C / O — MS_UPDATE.cs:32094 {{VALUES ('TAG SPLIT',5,'O','00056','LABOUR EXP A/C'}}; 6 / 00003 / SALES GOLD A/C / O — MS_UPDATE.cs:32098 {{VALUES ('TAG SPLIT',6,'O','00003','SALES GOLD A/C'}}; 7 / 00008 / PURCHASE GOLD A/C / O — MS_UPDATE.cs:32102 {{VALUES ('TAG SPLIT',7,'O','00008','PURCHASE GOLD A/C'}}; 8 / 00004 / SALES SILVER A/C / O — MS_UPDATE.cs:32106 {{VALUES ('TAG SPLIT',8,'O','00004','SALES SILVER A/C'}}; 9 / 00009 / PURCHASE SILVER A/C / O — MS_UPDATE.cs:32110 {{VALUES ('TAG SPLIT',9,'O','00009','PURCHASE SILVER A/C'}} |

Reading rule used by the cases: when a case says "template of F", the grid after choosing family F in add mode holds exactly the rows of F above, sorted by slot number, with the account code, description and direction shown. The first row's direction picks the book direction: `MS_BOOK.cs:2942 {{if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["INOUT_TYPE"], (object)"I", false))}}` gives Inword, anything else Outword (`MS_BOOK.cs:2948 {{cboTranInOut.SelectedIndex = 1;}}`). The template row with `SR_NO` 0 is excluded: `MS_BOOK.cs:2936 {{AND SR_NO <> 0}}`.

## Cases

### T01 Entry/defaults

### books.entry.menu-opens   (T01 Entry/defaults)
Layer: browser
Steps: 1. Log in as a Lite user with the Books right. 2. Open Company → Books.
Expected: The Book Master screen opens directly, no intermediate dialog: MDI_FORM.cs:7443 {{MS_BOOK mS_BOOK = new MS_BOOK();}} MDI_FORM.cs:7447 {{((Control)mS_BOOK).Show();}}. Title `Book Master`: MS_BOOK.cs:1423 {{lblBook.Text = "Book Master";}}. Focus is on Book Code: MS_BOOK.cs:2465 {{((Control)tBkCode).Focus();}}. The web route `/masters/books` renders the Books screen, not the generic master form (G1, G5).
Status: executable

### books.entry.defaults   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Books. 2. Read every field without typing.
Expected: Text boxes empty (MS_BOOK.cs:2443 {{val.Text = "";}}); Cur In Use `Yes` (MS_BOOK.cs:2101 {{cboCurUse.SelectedIndex = 0;}}); Item Type `All` (MS_BOOK.cs:2105 {{cboItmTyp.SelectedIndex = 0;}}); Tran In / Out `Inword` (MS_BOOK.cs:2108 {{cboTranInOut.SelectedIndex = 0;}}); Invoice Type `Free` (MS_BOOK.cs:2112 {{cboInvoTyp.SelectedIndex = 0;}}); Transaction Name blank (MS_BOOK.cs:2450 {{cboTrnsNm.SelectedIndex = 0;}}); the slot grid has only the header row `Sr`, `Account Desc`, `AcCode`, `AcName` (MS_BOOK.cs:2154 {{mSG[0, 0] = "Sr";}} MS_BOOK.cs:2157 {{mSG[0, 1] = "Account Desc";}} MS_BOOK.cs:2160 {{mSG[0, 2] = "AcCode";}} MS_BOOK.cs:2163 {{mSG[0, 3] = "AcName";}}). Fails today: web has free-text metadata without enums (G4).
Status: executable

### books.entry.combo-options   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open each combo and list its options.
Expected: Cur In Use: Yes, No (MS_BOOK.cs:2099 {{cboCurUse.Items.Add((object)"Yes");}} MS_BOOK.cs:2100 {{cboCurUse.Items.Add((object)"No");}}). Item Type: All, Gold, Silver (MS_BOOK.cs:2102 {{cboItmTyp.Items.Add((object)"All");}} MS_BOOK.cs:2103 {{cboItmTyp.Items.Add((object)"Gold");}} MS_BOOK.cs:2104 {{cboItmTyp.Items.Add((object)"Silver");}}). Direction: Inword, Outword (MS_BOOK.cs:2106 {{cboTranInOut.Items.Add((object)"Inword");}} MS_BOOK.cs:2107 {{cboTranInOut.Items.Add((object)"Outword");}}). Invoice Type: Free, Tax Invoice, Mix (MS_BOOK.cs:2109 {{cboInvoTyp.Items.Add((object)"Free");}} MS_BOOK.cs:2110 {{cboInvoTyp.Items.Add((object)"Tax Invoice");}} MS_BOOK.cs:2111 {{cboInvoTyp.Items.Add((object)"Mix");}}). Typing a value outside the list is not accepted (G4, G12).
Status: executable

### books.entry.family-list-from-headers   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Books in a company whose current location has books of families SALES, PURCHASE and CONTRA only. 2. Open Transaction Name.
Expected: Options are a blank first entry then exactly CONTRA, PURCHASE, SALES (alphabetical, each once): MS_BOOK.cs:2119 {{GROUP BY MAIN_BOOK ORDER BY MAIN_BOOK}} MS_BOOK.cs:2123 {{cboTrnsNm.Items.Add((object)"");}}. A family with no header at that location is not offered (G12). Fails today: free text.
Status: executable

### books.entry.lite-hidden-controls   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Books as Lite. 2. Double-click the footer. 3. Look for Data Type, Reset All, Employee code and name.
Expected: None of them is visible and the footer double-click shows nothing: MS_BOOK.cs:1757 {{((Control)tDataType).Visible = false;}} MS_BOOK.cs:1805 {{((Control)btnReSet).Visible = false;}} MS_BOOK.cs:3064 {{if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))}} MS_BOOK.cs:2113 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}} (D6).
Status: executable

### books.entry.list-columns   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Books with three books present.
Expected: The book list is read-only, single-select, columns `Code`, `Name`, `Trfr`: MS_BOOK.cs:1713 {{((DataGridView)DGV).ReadOnly = true;}} MS_BOOK.cs:2405 {{((DataGridView)DGV).MultiSelect = false;}} MS_BOOK.cs:2418 {{((DataGridView)DGV).Columns[0].HeaderText = "Code";}} MS_BOOK.cs:2421 {{((DataGridView)DGV).Columns[1].HeaderText = "Name";}} MS_BOOK.cs:2424 {{((DataGridView)DGV).Columns[2].HeaderText = "Trfr";}}. Rows ordered by book code: MS_BOOK.cs:2461 {{ORDER BY CO_BOOK}}.
Status: executable

### T02 Field route

### books.field.header-route   (T02 Field route)
Layer: browser
Steps: 1. Create book code `Z01`, name `Zeta Sales`, short `ZS`, Cur In Use Yes, family SALES, Item Type Gold, Invoice Type Tax Invoice, Vch Serice `ZSR`, Reset Book `R1`, Trfr Book `T1`, Mobile Entry `Y`. 2. Save. 3. Reopen it. 4. Query BOOK_DATA.
Expected: Row has CO_BOOK `Z01`, BOOK_NAME `Zeta Sales`, BOOK_SNAME `ZS`, CUR_USE `Y`, MAIN_BOOK `SALES`, ITM_TYPE `G`, BOOK_TYPE `T`, BOOK_SR_NAME `ZSR`, RESET_BOOK `R1`, TRFR_BOOK `T1`, WITH_MOBILE_ENTRY `Y`. Code is upper-cased on typing but the name keeps its case: MS_BOOK.cs:2752 {{if (Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "tBkName", false) != 0)}}; stored text: MS_BOOK.cs:2619 {{dataRow["BOOK_NAME"] = tBkName.Text;}} MS_BOOK.cs:2620 {{dataRow["BOOK_SNAME"] = tBkShort.Text;}} MS_BOOK.cs:2626 {{dataRow["BOOK_SR_NAME"] = tVchSer.Text;}} MS_BOOK.cs:2636 {{dataRow["RESET_BOOK"] = tResetBook.Text;}} MS_BOOK.cs:2637 {{dataRow["TRFR_BOOK"] = tTrfrBook.Text;}} MS_BOOK.cs:2638 {{dataRow["WITH_MOBILE_ENTRY"] = tMobileEntry.Text;}}. Reopen shows every value. Fails today: web header metadata is untyped text and the enums are not first-character codes (G4).
Status: executable

### books.field.enum-first-char   (T02 Field route)
Layer: database
Steps: 1. Save four books covering Cur In Use Yes/No, Item Type All/Gold/Silver, Inword/Outword, Free/Tax Invoice/Mix. 2. Read BOOK_DATA and BOOK_DETL.
Expected: Stored values are the first character: `Y`/`N`, `A`/`G`/`S`, `I`/`O`, `F`/`T`/`M` in both tables: MS_BOOK.cs:2621 {{dataRow["CUR_USE"] = Strings.Mid(cboCurUse.Text, 1, 1);}} MS_BOOK.cs:2623 {{dataRow["ITM_TYPE"] = Strings.Mid(cboItmTyp.Text, 1, 1);}} MS_BOOK.cs:2624 {{dataRow["BOOK_INOUT"] = Strings.Mid(cboTranInOut.Text, 1, 1);}} MS_BOOK.cs:2625 {{dataRow["BOOK_TYPE"] = Strings.Mid(cboInvoTyp.Text, 1, 1);}} MS_BOOK.cs:2658 {{dataRow2["BOOK_TYPE"] = Strings.Mid(cboInvoTyp.Text, 1, 1);}} MS_BOOK.cs:2659 {{dataRow2["ITM_TYPE"] = Strings.Mid(cboItmTyp.Text, 1, 1);}} MS_BOOK.cs:2660 {{dataRow2["BOOK_INOUT"] = Strings.Mid(cboTranInOut.Text, 1, 1);}}. The seed's headers omit BOOK_TYPE and ITM_TYPE (G11).
Status: executable

### books.field.detail-denormalised-header   (T02 Field route)
Layer: database
Steps: 1. Save book `Z02` name `Zeta Two`, short `Z2`, family PURCHASE with two slots filled. 2. Read BOOK_DETL rows.
Expected: Every detail row carries CO_CODE, LC_CODE of the session, CO_BOOK `Z02`, BOOK_NAME `Zeta Two`, BOOK_SNAME `Z2`, MAIN_BOOK `PURCHASE`, RESET_BOOK equal to the header's: MS_BOOK.cs:2653 {{dataRow2["CO_CODE"] = DC_Main.MCo_code;}} MS_BOOK.cs:2654 {{dataRow2["LC_CODE"] = DC_Main.MLc_code;}} MS_BOOK.cs:2655 {{dataRow2["CO_BOOK"] = tBkCode.Text;}} MS_BOOK.cs:2656 {{dataRow2["BOOK_NAME"] = tBkName.Text;}} MS_BOOK.cs:2657 {{dataRow2["BOOK_SNAME"] = tBkShort.Text;}} MS_BOOK.cs:2664 {{dataRow2["MAIN_BOOK"] = RuntimeHelpers.GetObjectValue(cboTrnsNm.SelectedItem);}} MS_BOOK.cs:2673 {{dataRow2["RESET_BOOK"] = tResetBook.Text;}}.
Status: executable

### books.field.slot-account-route   (T02 Field route)
Layer: browser
Steps: 1. Create book `Z03` family ITEM SALES. 2. In slot 1 AcCode type `00004` (SALES SILVER A/C) in place of `00003`. 3. Save. 4. Reopen. 5. Query BOOK_DETL slot 1.
Expected: Slot 1 AC_CODE `00004`, AC_NAME `SALES SILVER A/C` (the name shown in the AcName column); reopen shows `00004`; the account change reaches the table, not only the screen: MS_BOOK.cs:2662 {{dataRow2["AC_CODE"] = MSG[DC_Main.i, 2];}} MS_BOOK.cs:2663 {{dataRow2["AC_NAME"] = MSG[DC_Main.i, 3];}}. Fails today: the web writes only headers (G1, G11).
Status: executable

### books.field.slot-description-editable   (T02 Field route)
Layer: browser
Steps: 1. In `Z03` select the Account Desc cell of slot 2 and type `TILL CASH`. 2. Press Enter. 3. Save and reopen.
Expected: The cell accepts the text (grid cells are writable text boxes with limits Sr 2, Account Desc 50, AcCode 8, AcName 50: MS_BOOK.cs:2216 {{((TextBoxBase)TEXT_ENTRY).ReadOnly = false;}} MS_BOOK.cs:2221 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 50;}} MS_BOOK.cs:2225 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 8;}} MS_BOOK.cs:2229 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 2;}}). The description is not a saved column: the save writes only SR_NO, AC_CODE and AC_NAME (MS_BOOK.cs:2661 {{dataRow2["SR_NO"] = Conversion.Val(MSG[DC_Main.i, 0]);}} MS_BOOK.cs:2662 {{dataRow2["AC_CODE"] = MSG[DC_Main.i, 2];}} MS_BOOK.cs:2663 {{dataRow2["AC_NAME"] = MSG[DC_Main.i, 3];}}) and reopen takes the description from the family template, so after reopen slot 2 shows the template description `CASH ON HAND`, with the saved account code. (G1)
Status: executable

### T03 Formula sequence

### books.formula.sr-no-val   (T03 Formula sequence)
Layer: database
Steps: 1. In a new PURCHASE-family book type `03` in the Sr cell of the first slot row and `00001` as its account. 2. Save. 3. Query SR_NO.
Expected: The Sr cell is formatted `3` and SR_NO is stored as number 3: MS_BOOK.cs:2256 {{MSG[mSG.Row, mSG.Col] = Strings.Format((object)TEXT_ENTRY.Text, "0");}} MS_BOOK.cs:2661 {{dataRow2["SR_NO"] = Conversion.Val(MSG[DC_Main.i, 0]);}}. No monetary formula exists on this master; the other T03 sequences are `N/A: no monetary formula: MS_BOOK.cs:2152 {{mSG[0] = (int)Math.Round(500.0 * ColCon);}} is pixel scaling`.
Status: executable

### T04 Lookup

### books.lookup.slot-account-exact   (T04 Lookup)
Layer: browser
Steps: 1. In a slot row type AcCode `00041` and press Enter with a nonempty description.
Expected: The exact company account is found and its name fills AcName (`LABOUR INCOM. A/C` in the test company) with no help dialog: MS_BOOK.cs:2314 {{AND AC_CODE =}} MS_BOOK.cs:2332 {{mSG[mSG.Row, 2] = DC_Main.ColValue[1];}} MS_BOOK.cs:2333 {{mSG[mSG.Row, 3] = DC_Main.ColValue[0];}}.
Status: executable

### books.lookup.slot-account-help   (T04 Lookup)
Layer: browser
Steps: 1. In a slot row type AcCode `99999` (absent) and press Enter. 2. Read the help list. 3. Choose `00057`. 
Expected: Help opens listing all company accounts ordered by account name, the grid does not advance, no location filter and no cash/bank restriction; choosing an account fills code and name and refocuses the cell editor: MS_BOOK.cs:2318 {{WHERE A.CO_CODE =}} MS_BOOK.cs:2318 {{ORDER BY A.AC_NAME}} MS_BOOK.cs:2326 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}} MS_BOOK.cs:2337 {{return;}} MS_BOOK.cs:2335 {{((Control)TEXT_ENTRY).Focus();}}. Cancelling the help leaves the cell unchanged.
Status: executable

### books.lookup.slot-account-any-class   (T04 Lookup)
Layer: browser
Steps: 1. In the CASH slot of a CASH REC book enter a party account code, then save.
Expected: Saved without refusal: no per-slot class restriction exists (MS_BOOK.cs:2318 {{WHERE A.CO_CODE =}}, and MS_BOOK.cs:2662 {{dataRow2["AC_CODE"] = MSG[DC_Main.i, 2];}} stores it as typed). (Decision D5 and G1.)
Status: executable

### books.lookup.book-search   (T04 Lookup)
Layer: browser
Steps: 1. With books `Z01` `Zeta Sales`, `Z02` `Zeta Two`, `Y01` `Yankee` present, type `Zet` in Search; then `Y0`; then `Zeta T`.
Expected: `Zet` lists Z01 and Z02; `Y0` lists Y01 (code prefix); `Zeta T` lists Z02 only; Backspace removes one character and re-filters; F1 focuses Search: MS_BOOK.cs:2824 {{BOOK_NAME Like}} MS_BOOK.cs:2907 {{Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));}}. A search containing an apostrophe, `Z'`, must not error or leak rows (weakness not ported: MS_BOOK.cs:2824 {{BOOK_NAME Like}}).
Status: executable

### books.lookup.dgv-reopen   (T04 Lookup)
Layer: browser
Steps: 1. Select a row in the list and press Enter; then double-click another row.
Expected: Each selected book opens; Book Name gets focus: MS_BOOK.cs:2901 {{tBkCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);}} MS_BOOK.cs:2902 {{DISPLAY_DATA();}} MS_BOOK.cs:2903 {{((Control)tBkName).Focus();}}. After choosing a second book the screen shows only the second book's slots (stale-result rejection with a delayed first response).
Status: executable

### books.lookup.family-rebuilds-slots   (T04 Lookup)
Layer: browser
Steps: 1. Add mode. 2. Choose family ITEM SALES, press Enter. 3. Change to ITEM PURC and press Enter.
Expected: After step 2 the grid holds six rows, accounts 00003, 00001, 00041, 00057, 00076, 00020; direction Outword. After step 3 the grid holds exactly five rows 00008, 00001, 00056, 00042, 00076 (grid cleared first): MS_BOOK.cs:2933 {{MSG_CLEAR();}} MS_BOOK.cs:2936 {{AND SR_NO <> 0 ORDER BY SR_NO}} MS_UPDATE.cs:7328 {{VALUES ('ITEM SALES',1,'O','00003','SALES GOLD A/C'}} MS_UPDATE.cs:7360 {{VALUES ('ITEM PURC',1,'O','00008','PURCHASE A/C'}}. Fails today: no grid (G1, G5).
Status: executable

### T05 Children

### books.children.two-books-isolated   (T05 Children)
Layer: database
Steps: 1. Create `Z04` (ITEM SALES) with slot 1 `00003` and `Z05` (ITEM SALES) with slot 1 `00004`. 2. Edit `Z04` slot 1 to `00003`→`00041`. 3. Read both.
Expected: `Z04` slot 1 `00041`, `Z05` slot 1 unchanged `00004`, six slot rows each: the detail key is company + location + book + SR_NO: MS_BOOK.cs:2608 {{WHERE CO_CODE =}} MS_BOOK.cs:2610 {{DELETE FROM BOOK_DETL}}.
Status: executable

### books.children.reopen-by-slot-identity   (T05 Children)
Layer: database
Steps: 1. Seed a book of family ITEM SALES whose saved details exist only for slots 2 and 5 (accounts `00001`→`00003`, `00076`→`00004`). 2. Reopen it in the screen.
Expected: Slot 2 shows `00003` and slot 5 shows `00004`; slots 1, 3, 4, 6 show the template defaults `00003`, `00041`, `00057`, `00020`. The desktop overlays by row position (MS_BOOK.cs:2554 {{mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["AC_CODE"], (object)""));}}), which would put `00003` in slot 1: a defect not ported; the expected result is by slot identity (task decision on the study's weakness list: "resolve by slot identity").
Status: executable

### books.children.family-enter-last-slot   (T05 Children)
Layer: browser
Steps: 1. Open an existing ITEM SALES book (six saved slots). 2. Change family to ITEM PURC and back to ITEM SALES pressing Enter each time, without saving. 3. Read slot 6.
Expected: Slot 6 shows the saved account, not blank: the desktop test `Rows.Count > i + 1` drops the last saved account (MS_BOOK.cs:2958 {{if (DC_Main.Rshlp.Rows.Count > DC_Main.i + 1)}} versus MS_BOOK.cs:2552 {{if (DC_Main.Rshlp.Rows.Count > DC_Main.i)}}); the web must not reproduce the loss.
Status: executable

### books.children.template-sr0-excluded   (T05 Children)
Layer: database
Steps: 1. Create a new CONTRA-family book with the template including an SR_NO 0 row (if the test company has one). 2. Read saved slots.
Expected: No saved slot with SR_NO 0: MS_BOOK.cs:2936 {{AND SR_NO <> 0 ORDER BY SR_NO}} and the save loop writes grid rows 1 to Rows-1 only: MS_BOOK.cs:2650 {{DC_Main.i = 1;}}.
Status: blocked: whether the installed baseline has an SR_NO 0 template row is MISSING (study open question); unblocks when the baseline BOOK_IDTL is supplied.

### T06 Required/invalid

### books.invalid.reserved-code-218   (T06 Required/invalid)
Layer: browser
Steps: 1. Add mode: code `218`, name `Reserved A`, short `RA`, family SALES. 2. Save.
Expected: Message `This Is a Reserve Code You Cant Use It...`, focus on Book Code, nothing written: MS_BOOK.cs:2591 {{if ((Operators.CompareString(tBkCode.Text, "218", false) == 0) | (Operators.CompareString(tBkCode.Text, "888", false) == 0) | (Operators.CompareString(tBkCode.Text, "999", false) == 0))}} MS_BOOK.cs:2593 {{This Is a Reserve Code You Cant Use It...}} MS_BOOK.cs:2594 {{((Control)tBkCode).Focus();}} (G3).
Status: executable

### books.invalid.reserved-code-888   (T06 Required/invalid)
Layer: browser
Steps: As above with code `888`.
Expected: Same message and focus as the 218 case (MS_BOOK.cs:2593 {{This Is a Reserve Code You Cant Use It...}}); BOOK_DATA has no `888` row (G3).
Status: executable

### books.invalid.reserved-code-999   (T06 Required/invalid)
Layer: browser
Steps: As above with code `999`.
Expected: Same message and focus (MS_BOOK.cs:2591 {{(Operators.CompareString(tBkCode.Text, "999", false) == 0)}}); no `999` row (G3).
Status: executable

### books.invalid.reserved-code-api   (T06 Required/invalid)
Layer: database
Steps: 1. POST the book `218` directly to the API with a valid session.
Expected: Refused with the same text `This Is a Reserve Code You Cant Use It...` and nothing is written (server enforces; the screen is not the only guard). Cited rule: MS_BOOK.cs:2593 {{This Is a Reserve Code You Cant Use It...}} (G3).
Status: executable

### books.invalid.blank-short   (T06 Required/invalid)
Layer: browser
Steps: 1. Code `Z06`, name `No Short`, short blank, family SALES. 2. Save.
Expected: `Please Insert Book Short Name`, focus Book Short, nothing written: MS_BOOK.cs:2597 {{if (Operators.CompareString(tBkShort.Text, "", false) == 0)}} MS_BOOK.cs:2599 {{Please Insert Book Short Name}} MS_BOOK.cs:2600 {{((Control)tBkShort).Focus();}} (G3).
Status: executable

### books.invalid.blank-code-or-name   (T06 Required/invalid)
Layer: browser
Steps: 1. Short `AB`, code blank, name `Only Name`. 2. Save. 3. Repeat with code `Z07` and name blank.
Expected: Both show `Error Found : Please Enter Book Detail First...`; nothing written, and an existing book is not deleted (the check precedes the delete): MS_BOOK.cs:2603 {{if ((Operators.CompareString(tBkCode.Text, "", false) == 0) | (Operators.CompareString(tBkName.Text, "", false) == 0))}} MS_BOOK.cs:2605 {{Error Found : Please Enter Book Detail First...}} MS_BOOK.cs:2608 {{DELETE FROM BOOK_DATA}}. Check order: edit right, reserved code, short, then code/name (MS_BOOK.cs:2586 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}, then the reserved-code, short and code/name checks at 2591, 2597, 2603): with code `218` and blank short the reserved-code text appears first.
Status: executable

### books.invalid.name-enter-blank   (T06 Required/invalid)
Layer: browser
Steps: 1. Code `Z08`, Tab to name, leave blank, press Enter.
Expected: `Error Found : Please Enter Book Name First...`, focus stays in Book Name: MS_BOOK.cs:2875 {{if (Operators.CompareString(tBkName.Text, "", false) == 0)}} MS_BOOK.cs:2877 {{Interaction.MsgBox((object)"Error Found : Please Enter Book Name First...", (MsgBoxStyle)0, (object)null);}} MS_BOOK.cs:2878 {{((Control)tBkName).Focus();}}. Pressing Enter in Book Short with a blank name shows the same message (MS_BOOK.cs:468 {{KeyEventHandler val = new KeyEventHandler(tBkName_KeyDown);}}).
Status: executable

### books.invalid.duplicate-code   (T06 Required/invalid)
Layer: browser
Steps: 1. Book `Z01` named `Zeta Sales` exists. 2. Add a new book with code `Z01` and name `Other Name`, leave the code field.
Expected: `This Book Code already Exist in  'Zeta Sales'  Book Name... Please Change Book Code...` (two spaces around the quoted name as in the source), code text selected, nothing saved: MS_BOOK.cs:2778 {{Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Book Code already Exist in  '", dataView[0]["BOOK_NAME"]), (object)"'  Book Name... Please Change Book Code..."), (MsgBoxStyle)0, (object)null);}} MS_BOOK.cs:2780 {{((TextBoxBase)tBkCode).SelectAll();}} (G3). The same book reopened (same code and same name) is not a duplicate.
Status: executable

### books.invalid.duplicate-name   (T06 Required/invalid)
Layer: browser
Steps: 1. Book `Z01` `Zeta Sales` exists. 2. Add code `Z09`, name `Zeta Sales`, leave the name field.
Expected: `This Book Name already Exist in  'Z01'  Book Code... Please Change Book Name...`, name selected, nothing saved: MS_BOOK.cs:2800 {{Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Book Name already Exist in  '", dataView[0]["CO_BOOK"]), (object)"'  Book Code... Please Change Book Name..."), (MsgBoxStyle)0, (object)null);}} MS_BOOK.cs:2802 {{((TextBoxBase)tBkName).SelectAll();}} (G3). Via the API the same text and no row.
Status: executable

### books.invalid.code-max-3   (T06 Required/invalid)
Layer: browser
Steps: 1. Type `ABCD` into Book Code. 2. Via the API post code `ABCD`.
Expected: The box holds `ABC` (limit 3); the API refuses 4 characters and writes nothing: MS_BOOK.cs:2459 {{((TextBoxBase)tBkCode).MaxLength = 3;}}. A 3-character alphabetic code such as `AB1` saves (the desktop has no digits-only check: MS_BOOK.cs:2603 {{if ((Operators.CompareString(tBkCode.Text, "", false) == 0) | (Operators.CompareString(tBkName.Text, "", false) == 0))}} is the only code test besides reserved). A 1-character code `Q` saves and is not padded (G4).
Status: executable

### books.invalid.field-limits   (T06 Required/invalid)
Layer: browser
Steps: 1. Type 51 characters in Book Name, 6 in Book Short, 16 in Vch Serice, 6 in Reset Book, 6 in Trfr Book, 2 in Mobile Entry.
Expected: Boxes hold 50, 5, 15, 5, 5 and 1 characters: MS_BOOK.cs:1435 {{((TextBoxBase)tBkName).MaxLength = 50;}} MS_BOOK.cs:1526 {{((TextBoxBase)tBkShort).MaxLength = 5;}} MS_BOOK.cs:1511 {{((TextBoxBase)tVchSer).MaxLength = 15;}} MS_BOOK.cs:1745 {{((TextBoxBase)tResetBook).MaxLength = 5;}} MS_BOOK.cs:1770 {{((TextBoxBase)tTrfrBook).MaxLength = 5;}} MS_BOOK.cs:1845 {{((TextBoxBase)tMobileEntry).MaxLength = 1;}}. API refuses longer values (G4).
Status: executable

### books.invalid.keypress-filter   (T06 Required/invalid)
Layer: browser
Steps: 1. Type `ab'c` into Book Short. 2. Type `ab'c` into Book Name.
Expected: Book Short holds `ABC`: lower case becomes upper case and the apostrophe key (code 39) is swallowed: MS_BOOK.cs:2758 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}} MS_BOOK.cs:2761 {{if (num == 0 || num == 39)}} MS_BOOK.cs:2763 {{e.Handled = true;}}. Book Name is the one exempt box (MS_BOOK.cs:2752 {{if (Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "tBkName", false) != 0)}}), so it keeps lower case: it holds `ab` followed by whatever the apostrophe produces unchanged, and the case asserts only that the letters stay lower case (`ab` and `c` are lower case). (G4)
Status: executable

### books.invalid.blank-slot-account-allowed   (T06 Required/invalid)
Layer: browser
Steps: 1. New ITEM SALES book `Z10`. 2. Clear the AcCode and AcName of slot 3 and slot 6. 3. Save. 4. Reopen. 5. Query BOOK_DETL.
Expected: Saved with `Data Are Saved.`; BOOK_DETL has six rows, slots 3 and 6 with blank AC_CODE and DATA_TYPE `A` (D5): MS_BOOK.cs:2650 {{DC_Main.i = 1;}} MS_BOOK.cs:2667 {{dataRow2["DATA_TYPE"] = "A";}}; no per-slot account check in the save loop. A voucher that needs a blank slot refuses at voucher time (see books.journey.blank-slot-voucher-refused).
Status: executable

### books.invalid.family-change-with-vouchers   (T06 Required/invalid)
Layer: browser
Steps: 1. Book `Z11` family SALES with one posted sales voucher. 2. Open it, change Transaction Name to PURCHASE, Save. 3. Repeat for a book with no vouchers.
Expected: Step 2 refused with `This book already has vouchers, so its Transaction Name cannot be changed.`, header and slots unchanged; step 3 saves. This is a deliberate web difference (D4): the desktop has no guard (study: "There is no voucher-reference guard or rejection message for changing a family in the inspected family handler/Save", MS_BOOK.cs:2608 {{DELETE FROM BOOK_DATA}}). Fails today (G12).
Status: executable

### books.invalid.no-edit-right   (T06 Required/invalid)
Layer: browser
Steps: 1. Sign in as a user with Books Edit denied. 2. Reopen a book, change the name, Save.
Expected: `You Have No Rights.....`, nothing written: MS_BOOK.cs:2586 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}} MS_BOOK.cs:2588 {{You Have No Rights.....}}. Adding a new book as the same user is not blocked by this check (no create-right test in the handler).
Status: executable

### T07 Create

### books.create.sales-footprint   (T07 Create)
Layer: database
Steps: 1. Add code `Z12`, name `Zeta Item Sales`, short `ZIS`, family ITEM SALES (Enter). 2. Accept template. 3. Save.
Expected: Message `Data Are Saved.`, screen clears with focus on Book Code (MS_BOOK.cs:2679 {{Data Are Saved.}} MS_BOOK.cs:2680 {{CLEAR_DATA();}}); BOOK_DATA has one new row (session company and location, direction `O` from the first template row, CUR_USE `Y`, MAIN_BOOK `ITEM SALES`, DATA_TYPE `A`, MAIN_USER the current user); BOOK_DETL has exactly six rows slot 1 to 6 with accounts 00003, 00001, 00041, 00057, 00076, 00020, names as the template, DATA_TYPE `A`: MS_UPDATE.cs:7328 {{VALUES ('ITEM SALES',1,'O','00003','SALES GOLD A/C'}} MS_UPDATE.cs:7348 {{VALUES ('ITEM SALES',6,'O','00020','ORDER ADVANCE'}} MS_BOOK.cs:2630 {{dataRow["DATA_TYPE"] = "A";}} MS_BOOK.cs:2639 {{dataRow["MAIN_USER"] = MainUser;}}. The book appears in the list and in the Sales voucher's book help. Header and slots appear in one commit (D3). (G1, G11)
Status: executable

### books.create.family-each   (T07 Create)
Layer: database
Steps: For each family in the table above, create a book of that family through the screen with the template untouched and read BOOK_DETL.
Expected: For each family the saved slot set equals its row in the table: slot numbers, account codes and descriptions, direction of the first row. Example counts: ITEM PURC 5, E INVOICE 6, CON PUR 4, OTH EXP 3, OTH INC 3, LABOUR WORK 4 (slots 8 to 11), PURCHASE 1 (slot 5), E CRNT 4, OTH COMM 3, WH RTN 7, LD ADJUST 3, FINE PURC 6, FINE SALE 6, TAG PURCHASE 1, AMT IN 1, AMT OUT 1, TOUR SALES 12, TOUR ORDER 1, TAG SPLIT 9. Each family is one sub-run reported separately (G7 to G10).
Status: executable

### books.create.oth-exp-oth-inc   (T07 Create)
Layer: database
Steps: Create `Z13` family OTH EXP and `Z14` family OTH INC, template untouched.
Expected: `Z13`: slot 1 `00008` PURCHASE A/C, slot 2 `00001` CASH ON HAND, slot 3 `00042` KASAR AVAK A/C, direction O. `Z14`: slot 1 `00099` SALES A/C, slot 2 `00001`, slot 3 `00057` KASAR JAVK A/C, direction I: MS_UPDATE.cs:22852 {{VALUES ('OTH EXP',1,'O','00008','PURCHASE A/C'}} MS_UPDATE.cs:22860 {{VALUES ('OTH EXP',2,'O','00001','CASH ON HAND'}} MS_UPDATE.cs:22868 {{VALUES ('OTH EXP',3,'O','00042','KASAR AVAK A/C'}} MS_UPDATE.cs:22876 {{VALUES ('OTH INC',1,'I','00099','SALES A/C'}} MS_UPDATE.cs:22884 {{VALUES ('OTH INC',2,'I','00001','CASH ON HAND'}} MS_UPDATE.cs:22892 {{VALUES ('OTH INC',3,'I','00057','KASAR JAVK A/C'}}. Fails today: web provisioned books have only slot 1 (seedCompany.ts:218,227) (G7). Also run the provisioned `OEX` and `OIN` books through reopen and assert they now show slots 2 and 3 after the repair/provisioning path the owner chooses; if no repair path exists the case checks only new books and the provisioned books are listed under Not covered.
Status: executable

### books.create.tag-split   (T07 Create)
Layer: database
Steps: Create `Z15` family TAG SPLIT, template untouched.
Expected: Nine slots: 1 `00001`, 2 `00057`, 3 `00042`, 4 `00041`, 5 `00056`, 6 `00003` SALES GOLD A/C, 7 `00008` PURCHASE GOLD A/C, 8 `00004` SALES SILVER A/C, 9 `00009` PURCHASE SILVER A/C, direction O: MS_UPDATE.cs:32078 {{VALUES ('TAG SPLIT',1,'O','00001','CASH ON HAND'}} MS_UPDATE.cs:32090 {{VALUES ('TAG SPLIT',4,'O','00041','LABOUR INCOME A/C'}} MS_UPDATE.cs:32098 {{VALUES ('TAG SPLIT',6,'O','00003','SALES GOLD A/C'}} MS_UPDATE.cs:32102 {{VALUES ('TAG SPLIT',7,'O','00008','PURCHASE GOLD A/C'}} MS_UPDATE.cs:32106 {{VALUES ('TAG SPLIT',8,'O','00004','SALES SILVER A/C'}} MS_UPDATE.cs:32110 {{VALUES ('TAG SPLIT',9,'O','00009','PURCHASE SILVER A/C'}}. Web seed has slot 6 = PURCHASE, 7 = SALES, 8 = PURCHASE, 9 = SALES and no 1 to 4 (seedCompany.ts:424-429) so the case fails today (G8).
Status: executable

### books.create.purchase-discount-slot   (T07 Create)
Layer: database
Steps: Create `Z16` family PURCHASE and `Z17` family TAG PURCHASE, template untouched.
Expected: Each has a slot 5 `00076` DISCOUNT A/C, direction I: MS_UPDATE.cs:25022 {{VALUES ('PURCHASE',5,'I','00076','DISCOUNT A/C'}} MS_UPDATE.cs:30221 {{VALUES ('TAG PURCHASE',5,'I','00076','DISCOUNT A/C'}}. Slots 1 to 4 of PURCHASE: MISSING baseline, not asserted. Fails today (G9).
Status: executable

### books.create.labour-work-silver-slots   (T07 Create)
Layer: database
Steps: Create `Z18` family LABOUR WORK, template untouched.
Expected: Slots 8 `00004` SALES SILVER A/C, 9 `00009` PURCHASE SILVER A/C, 10 `00005` SALES OLD GOLD A/C, 11 `00006` SALES OLD SILVER A/C, all I: MS_UPDATE.cs:23749 {{VALUES ('LABOUR WORK',8,'I','00004','SALES SILVER A/C'}} MS_UPDATE.cs:23753 {{VALUES ('LABOUR WORK',9,'I','00009','PURCHASE SILVER A/C'}} MS_UPDATE.cs:23757 {{VALUES ('LABOUR WORK',10,'I','00005','SALES OLD GOLD A/C'}} MS_UPDATE.cs:23761 {{VALUES ('LABOUR WORK',11,'I','00006','SALES OLD SILVER A/C'}}. Web seed has slots 1 and 6 only (G9). Fails today.
Status: executable

### books.create.fine-families   (T07 Create)
Layer: database
Steps: Create `Z19` family FINE PURC and `Z20` family FINE SALE, template untouched.
Expected: FINE PURC: six slots 00001, 00008, 00009, 00057, 00076, 00056, direction O. FINE SALE: six slots 00001, 00003, 00004, 00057, 00076, 00041, direction O: MS_UPDATE.cs:28696 {{VALUES ('FINE PURC',1,'O','00001','CASH ON HAND'}} MS_UPDATE.cs:28716 {{VALUES ('FINE PURC',6,'O','00056','LABOUR EXP A/C'}} MS_UPDATE.cs:28728 {{VALUES ('FINE SALE',1,'O','00001','CASH ON HAND'}} MS_UPDATE.cs:28748 {{VALUES ('FINE SALE',6,'O','00041','LABOUR INCOME A/C'}}. The web provisioned `FPR` book is direction I with one slot: fails today (G10).
Status: executable

### books.create.code-case-and-length   (T07 Create)
Layer: database
Steps: Create books with codes `ab1` (typed lower case) and `Q`.
Expected: Stored `AB1` and `Q` (upper-cased by key handling: MS_BOOK.cs:2758 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}); no leading-zero padding and no generated code: MS_BOOK.cs:2996 {{else if ((int)e.KeyCode == 13 && Operators.CompareString(tBkCode.Text, "", false) != 0)}}. (D2, G4)
Status: executable

### books.create.new-code-enter   (T07 Create)
Layer: browser
Steps: 1. Type new code `Z21` and press Enter.
Expected: Focus moves to the next field; no record is displayed and no code is generated: MS_BOOK.cs:3007 {{SendKeys.Send("{tab}");}}. With an existing code Enter displays that book first: MS_BOOK.cs:3002 {{DISPLAY_DATA();}}.
Status: executable

### T08 Reopen/no-op

### books.reopen.locks   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Reopen a saved book.
Expected: Code and Mobile Entry read-only, Tran In/Out and Invoice Type disabled, Transaction Name still editable: MS_BOOK.cs:2526 {{((TextBoxBase)tMobileEntry).ReadOnly = true;}} MS_BOOK.cs:2564 {{((Control)cboTranInOut).Enabled = false;}} MS_BOOK.cs:2565 {{((Control)cboInvoTyp).Enabled = false;}} MS_BOOK.cs:2566 {{((TextBoxBase)tBkCode).ReadOnly = true;}} (G5).
Status: executable

### books.reopen.save-unchanged   (T08 Reopen/no-op)
Layer: database
Steps: 1. Reopen `Z12`, change nothing, Save. 2. Compare BOOK_DATA and BOOK_DETL to before.
Expected: Every column equal, including MAIN_USER (preserved: MS_BOOK.cs:2527 {{MainUser = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["MAIN_USER"], (object)""));}}), AC_NAME and DATA_TYPE; slot count unchanged; `Data Are Saved.`.
Status: executable

### books.reopen.provisioned-books   (T08 Reopen/no-op)
Layer: database
Steps: Reopen each provisioned book (SL, PR, SRT, RCT, PAY, SOR, CON, JV) and save unchanged.
Expected: Slots and header values are preserved exactly; a book whose family has template slots absent in its saved rows shows those template slots (reopen copies template rows: MS_BOOK.cs:2541 {{ORDER BY SR_NO}}), and saving then writes them. The slot accounts of untouched slots do not change.
Status: executable

### books.reopen.mode-after-save   (T08 Reopen/no-op)
Layer: browser
Steps: 1. After a save, the screen clears. 2. Type the same code again.
Expected: Enter on an existing code opens it in edit mode: MS_BOOK.cs:2563 {{EntryMode = "E";}}; a fresh clear returns to add mode: MS_BOOK.cs:2460 {{EntryMode = "A";}}.
Status: executable

### T09 Edit

### books.edit.slot-account   (T09 Edit)
Layer: database
Steps: 1. Reopen `Z12`, change slot 2 from `00001` to `00002`, Save.
Expected: Slot 2 `00002`; header and other slots unchanged; row count six; no duplicate rows: MS_BOOK.cs:2608 {{DELETE FROM BOOK_DATA}} MS_BOOK.cs:2610 {{DELETE FROM BOOK_DETL}} (replace then insert, here in one transaction).
Status: executable

### books.edit.header-fields   (T09 Edit)
Layer: database
Steps: 1. Reopen `Z12`, change name to `Zeta Item Sales 2`, short to `ZI2`, Cur In Use to No, Item Type to Gold. 2. Save.
Expected: BOOK_DATA and every BOOK_DETL row carry the new name, short and item type G; CUR_USE `N`: MS_BOOK.cs:2619 {{dataRow["BOOK_NAME"] = tBkName.Text;}} MS_BOOK.cs:2656 {{dataRow2["BOOK_NAME"] = tBkName.Text;}} MS_BOOK.cs:2659 {{dataRow2["ITM_TYPE"] = Strings.Mid(cboItmTyp.Text, 1, 1);}}.
Status: executable

### books.edit.direction-locked   (T09 Edit)
Layer: browser
Steps: 1. Reopen `Z12`. 2. Try to change direction and invoice type; press Ctrl+O.
Expected: Both controls stay disabled after Ctrl+O (override not ported, D6): MS_BOOK.cs:2564 {{((Control)cboTranInOut).Enabled = false;}} MS_BOOK.cs:2853 {{if (((int)e.KeyCode == 79) & e.Control)}}. A direct API update of BOOK_INOUT or BOOK_TYPE on an existing book is refused and the stored values remain (G5).
Status: executable

### books.edit.family-no-vouchers   (T09 Edit)
Layer: database
Steps: 1. Reopen `Z12` (no vouchers), change family ITEM SALES → ITEM PURC (Enter). 2. Save.
Expected: MAIN_BOOK `ITEM PURC` in both tables and the grid saved as the five template rows rebuilt: slots 1 to 5 with 00008, 00001, 00056, 00042, 00076 and no stale slot 6: MS_BOOK.cs:2622 {{dataRow["MAIN_BOOK"] = RuntimeHelpers.GetObjectValue(cboTrnsNm.SelectedItem);}} MS_BOOK.cs:2933 {{MSG_CLEAR();}} MS_UPDATE.cs:7360 {{VALUES ('ITEM PURC',1,'O','00008','PURCHASE A/C'}}. Direction is not changed on an existing book (MS_BOOK.cs:2940 {{if (Operators.CompareString(EntryMode, "A", false) == 0 && DC_Main.Tbl.Rows.Count > 0)}}).
Status: executable

### books.edit.edit-right-only-in-edit-mode   (T09 Edit)
Layer: browser
Steps: 1. A user without edit right adds a new book and saves.
Expected: Saved: the right check applies to mode E only (MS_BOOK.cs:2586 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}).
Status: executable

### T10 Delete/cancel/reverse

### books.delete.unused   (T10 Delete/cancel/reverse)
Layer: database
Steps: 1. Delete `Z12` (no vouchers). 2. Answer No, then repeat answering Yes.
Expected: Prompt `Are You Sure To Delete This Book now?`; No leaves both tables untouched; Yes deletes the header and all its slots, shows `Delete Success.`, clears the screen: MS_BOOK.cs:2719 {{Are You Sure To Delete This Book now?}} MS_BOOK.cs:2721 {{DELETE FROM BOOK_DATA}} MS_BOOK.cs:2722 {{DELETE FROM BOOK_DETL}} MS_BOOK.cs:2723 {{Delete Success.}} MS_BOOK.cs:2724 {{CLEAR_DATA();}}. Detail rows for the book are gone (none orphaned); other books untouched. Fails today: web deletes the header only (G2).
Status: executable

### books.delete.refused-account-voucher   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Post a cash receipt on a book `Z22`. 2. Delete `Z22`. 3. Also post it in a second location and delete the same code in the first location.
Expected: `You Cant Delete Record This Book Code Use in Account Transection....` and nothing deleted. The account check is by company and book across all locations, so step 3 is refused too: MS_BOOK.cs:2706 {{FROM  AC_DATA}} MS_BOOK.cs:2706 {{WHERE CO_CODE =}} MS_BOOK.cs:2706 {{AND CO_BOOK =}} MS_BOOK.cs:2710 {{You Cant Delete Record This Book Code Use in Account Transection....}}. The web applies the same wider scope; this is the desktop's behaviour reproduced deliberately (study: "Preserve safety deliberately"). (G2)
Status: executable

### books.delete.refused-stock-voucher   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Create a stock-only entry (tag opening) in a book `Z23` so MAIN_STOCK has a row, no AC_DATA. 2. Delete `Z23`. 3. Delete the same-code book in another location where MAIN_STOCK has no row.
Expected: Step 2: `You Cant Delete Record This Book Code Use in Stock Transection....`, nothing deleted; step 3 is allowed (stock check includes location): MS_BOOK.cs:2713 {{FROM  MAIN_STOCK}} MS_BOOK.cs:2713 {{AND LC_CODE =}} MS_BOOK.cs:2717 {{You Cant Delete Record This Book Code Use in Stock Transection....}} (G2).
Status: executable

### books.delete.blank-code   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. In add mode with blank code press Delete.
Expected: `Please Select Product For Delete.`; nothing deleted: MS_BOOK.cs:2703 {{Please Select Product For Delete.}}.
Status: executable

### books.delete.no-right   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. As a user without delete right open `Z22` and press Delete.
Expected: `You Have No Rights.....`: MS_BOOK.cs:2696 {{if (Operators.CompareString(UserDelete, "Y", false) != 0)}} MS_BOOK.cs:2698 {{You Have No Rights.....}}. The API refuses a direct DELETE the same way (T11).
Status: executable

### books.delete.atomic   (T10 Delete/cancel/reverse)
Layer: database
Steps: 1. Force the BOOK_DETL delete to fail (test hook) while deleting `Z24`.
Expected: BOOK_DATA row still present and slots intact (D3: header and detail in one transaction; the desktop's separate executes are not ported: MS_BOOK.cs:2721 {{DELETE FROM BOOK_DATA}} MS_BOOK.cs:2722 {{DELETE FROM BOOK_DETL}}).
Status: blocked: needs a fault-injection hook in the isolated test stack (another work package: the failure harness used by T14 in other modules); unblocks when the harness exposes a per-table failpoint.

### books.cancel.clears   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Reopen `Z12`, edit the name, press Cancel.
Expected: Screen cleared, add mode, no database change: MS_BOOK.cs:2733 {{CLEAR_DATA();}}. Esc closes the screen without a dirty prompt: MS_BOOK.cs:2851 {{((Form)this).Close();}}; Exit button closes: MS_BOOK.cs:2738 {{((Form)this).Close();}}.
Status: executable

### T11 Scope/rights

### books.scope.location-isolation   (T11 Scope/rights)
Layer: database
Steps: 1. Books `Z25` exist at location 01 and `Z26` at location 02. 2. Open Books at location 01. 3. Call GET/PUT/DELETE for `Z26` at location 01.
Expected: The list shows `Z25` only; `Z26` is not returned and PUT/DELETE affect no row: MS_BOOK.cs:2608 {{WHERE CO_CODE =}} MS_BOOK.cs:2617 {{dataRow["LC_CODE"] = DC_Main.MLc_code;}}. Slot rows of `Z26` are unchanged.
Status: executable

### books.scope.company-isolation   (T11 Scope/rights)
Layer: database
Steps: 1. Using a session of the second tenant company, request book `Z25` and its slots; post a slot save for it.
Expected: Not found / no write; first company's rows unchanged. Detail writes carry the session CO_CODE and LC_CODE only (MS_BOOK.cs:2653 {{dataRow2["CO_CODE"] = DC_Main.MCo_code;}}), and a slot account that belongs to another company is refused (lookup is company-scoped: MS_BOOK.cs:2318 {{WHERE A.CO_CODE =}}).
Status: executable

### books.rights.caption-books   (T11 Scope/rights)
Layer: database
Steps: 1. Revoke the Books right for a user; call each of GET, POST, PUT, DELETE for `/masters/books`.
Expected: 403 for each; with the right restored, 200. Rights are by caption "Books". The generic master policy must not grant it through another master's right.
Status: executable

### books.rights.edit-delete-print-flags   (T11 Scope/rights)
Layer: database
Steps: 1. User with FRM_EDIT N, FRM_DELETE N, FRM_PRINT N. 2. Call PUT, DELETE and the export.
Expected: PUT and DELETE refused with `You Have No Rights.....`; export refused with `You Have No Print Rights.....`: MS_BOOK.cs:1935 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}} MS_BOOK.cs:1936 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));}} MS_BOOK.cs:1937 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}.
Status: executable

### books.scope.reused-ids   (T11 Scope/rights)
Layer: database
Steps: 1. Send a slot save naming a book code of another location with slots whose SR_NO exist in both.
Expected: Only the session location's slots are replaced.
Status: executable

### T12 Concurrency

### books.concurrency.same-code-create   (T12 Concurrency)
Layer: database
Steps: 1. Two sessions simultaneously add code `Z27` with different names.
Expected: Exactly one book `Z27` with one complete slot set; the loser gets the duplicate-code text `This Book Code already Exist in  '<winner name>'  Book Name... Please Change Book Code...` (MS_BOOK.cs:2778 {{Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Book Code already Exist in  '", dataView[0]["BOOK_NAME"]), (object)"'  Book Name... Please Change Book Code..."), (MsgBoxStyle)0, (object)null);}}); the desktop's cached check is not enough (MS_BOOK.cs:2772 {{DataView dataView = new DataView(RsMast);}}), so the server enforces it.
Status: executable

### books.concurrency.same-name-create   (T12 Concurrency)
Layer: database
Steps: 1. Two sessions simultaneously add different codes `Z28`, `Z29` with name `Race Name`.
Expected: One succeeds; the other receives `This Book Name already Exist in  '<code>'  Book Code... Please Change Book Name...` (MS_BOOK.cs:2800 {{Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Book Name already Exist in  '", dataView[0]["CO_BOOK"]), (object)"'  Book Code... Please Change Book Name..."), (MsgBoxStyle)0, (object)null);}}); one row has that name.
Status: executable

### books.concurrency.delete-vs-voucher   (T12 Concurrency)
Layer: database
Steps: 1. Session A opens the delete prompt for unused `Z30`. 2. Session B posts a voucher in `Z30`. 3. A confirms Yes.
Expected: The guard is evaluated at confirmation inside the delete transaction, so A is refused with the account-reference text (MS_BOOK.cs:2710 {{You Cant Delete Record This Book Code Use in Account Transection....}}); no voucher is left without its book.
Status: executable

### books.concurrency.edit-vs-edit   (T12 Concurrency)
Layer: database
Steps: 1. Two sessions load `Z12`; A changes slot 1, B changes slot 2; both save.
Expected: Defined result: either the later save is refused with a stale-version message, or both slot changes are present. Never a mixed set with duplicated or missing slots (six rows, one per SR_NO).
Status: executable

### T13 Retry/unknown

### books.retry.double-submit   (T13 Retry/unknown)
Layer: database
Steps: 1. Send the same create request twice (same idempotency key / double click).
Expected: One header and exactly one set of slots; the second response reports the duplicate-code text or the first result, never a second set (D3).
Status: executable

### books.retry.lost-ack   (T13 Retry/unknown)
Layer: browser
Steps: 1. Save a new book and drop the response; reload and look at the list; save again.
Expected: The book exists once; the second save is treated as an edit of the same code (same name allowed for the same code: MS_BOOK.cs:2778 {{Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Book Code already Exist in  '", dataView[0]["BOOK_NAME"]), (object)"'  Book Name... Please Change Book Code..."), (MsgBoxStyle)0, (object)null);}} fires only for a different name) with six slots.
Status: executable

### T14 Rollback

### books.rollback.detail-failure-keeps-old   (T14 Rollback)
Layer: database
Steps: 1. Reopen `Z12` (six slots). 2. Change slot 1 and make the BOOK_DETL insert fail. 3. Query.
Expected: Header and all six slots hold the pre-edit values. The desktop deletes then inserts without a transaction: MS_BOOK.cs:2609 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}} MS_BOOK.cs:2611 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}} MS_BOOK.cs:2675 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);}}; not ported.
Status: blocked: needs a fault-injection point after the header write (see books.delete.atomic); unblocks with the shared failpoint harness.

### books.rollback.invalid-account-no-partial   (T14 Rollback)
Layer: database
Steps: 1. Save with a slot AcCode that is not an account of the company (by API).
Expected: Refused as a whole by the server (the web adds this reference check because the desktop picks accounts through the lookup; blank is still allowed, D5); no header write, no slot write, previous values intact.
Status: executable

### T15 Config/history

### books.history.slot-change-old-voucher-unchanged   (T15 Config/history)
Layer: database
Steps: 1. Post a sales voucher V1 through book `Z31` (slot 2 `00001`). 2. Change slot 2 to `00002`. 3. Post V2. 4. Reopen V1.
Expected: V1's ledger rows still show `00001`; V2's show `00002`; the voucher posted value does not move: the voucher stores the posted legs, and the book master changes only future postings (D1; MS_BOOK.cs:2662 {{dataRow2["AC_CODE"] = MSG[DC_Main.i, 2];}}).
Status: executable

### books.history.cur-use-no-hides-book   (T15 Config/history)
Layer: browser
Steps: 1. Set `Z31` Cur In Use to No and save. 2. Open the Sales voucher book help.
Expected: `Z31` is not offered (help filters CUR_USE `Y`): DC_Main.cs:1503 {{AND CUR_USE = 'Y' AND MAIN_BOOK =}}. If no book of the family is left the message is `Please Creat Book From SALES....`: DC_Main.cs:1508 {{Interaction.MsgBox((object)("Please Creat Book From " + CurMainBook + "...."), (MsgBoxStyle)0, (object)null);}}. Existing vouchers of `Z31` still open and print (G12).
Status: executable

### books.history.blank-cur-use   (T15 Config/history)
Layer: database
Steps: 1. A header with CUR_USE blank (legacy import).
Expected: It is not offered by voucher book help (filter is CUR_USE = 'Y': DC_Main.cs:1503 {{AND CUR_USE = 'Y' AND MAIN_BOOK =}}); the web's `bookPolicy.ts:68` treats blank as active, which is wrong (G12).
Status: executable

### books.history.employee-book   (T15 Config/history)
Layer: database
Steps: n/a for Lite.
Expected: Employee-specific book selection applies only to edition E (DC_Main.cs:1514 {{dataView.RowFilter = "USER_EMP_CODE =  '" + MsUserEmpCode + "'";}}).
Status: N/A: employee controls and employee matching exist for edition E only (MS_BOOK.cs:2113 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}).

### books.history.branch-clone   (T15 Config/history)
Layer: database
Steps: 1. Company has books and slots at location `00`. 2. Add a new location `03` through Location Master. 3. Read BOOK_DATA and BOOK_DETL for `03`.
Expected: Location `03` has the same headers and slots as `00` (same codes, names, MAIN_BOOK, accounts, SR_NO), every pre-existing destination row deleted first; editing a location does not clone: MS_LOCT.cs:3609 {{if (Operators.CompareString(EntryMode, "A", false) == 0)}} MS_LOCT.cs:3611 {{DELETE FROM BOOK_DATA}} MS_LOCT.cs:3612 {{AND LC_CODE = '00'}} MS_LOCT.cs:3614 {{AND LC_CODE = '00'}}. Header columns copied: MS_LOCT.cs:3612 {{INSERT INTO BOOK_DATA (CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR)}}; detail columns: MS_LOCT.cs:3614 {{INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)}}. Fails today (G6).
Status: blocked: the Location Master add path in Lite is another work package (out of scope here) and its reachability in Lite is unverified; unblocks when a Location Master add is available in the test stack. If locations are not reachable in Lite, this case becomes N/A with the citation above.

### T16 Report/output

### books.output.print-no-right   (T16 Report/output)
Layer: browser
Steps: 1. User with Print denied clicks Print (or the export).
Expected: `You Have No Print Rights.....`: MS_BOOK.cs:2573 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}} MS_BOOK.cs:2575 {{You Have No Print Rights.....}} (G13).
Status: executable

### books.output.print-with-right   (T16 Report/output)
Layer: browser
Steps: 1. User with Print right clicks Print.
Expected: No report, no dialog, no message and no data change on the Print button itself (desktop does nothing: MS_BOOK.cs:2570 {{private void BtnPrint_Click(object sender, EventArgs e)}}). No Crystal-style report is expected. The web's CSV export is a web addition behind the Print right (D7): with the right it returns a CSV whose rows equal the book list (Code, Name, Trfr) and is not claimed as desktop parity. (G13)
Status: executable

### books.output.list-after-lifecycle   (T16 Report/output)
Layer: browser
Steps: 1. Create, edit the name of, and delete books; look at the list after each.
Expected: List rows equal BOOK_DATA of the session location after every step, ordered by code, with Name and Trfr columns, refreshed after save and delete: MS_BOOK.cs:2681 {{ORDER BY CO_BOOK}} MS_BOOK.cs:2683 {{DGV_FILL();}}.
Status: executable

### T17 Keyboard/usability

### books.keys.form-flow   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Using only the keyboard create `Z32`: code, Enter, name, Enter, short, Enter, Cur In Use Enter, Transaction Name (choose ITEM SALES) Enter, Item Type Enter, Direction Enter, Invoice Type Enter, Reset Book Enter, Vch Serice Enter, then grid.
Expected: Each Enter moves to the next field in tab order (MS_BOOK.cs:2917 {{SendKeys.Send("{TAB}");}}); family Enter rebuilds the grid and moves on (MS_BOOK.cs:2970 {{SendKeys.Send("{TAB}");}}); Reset/Trfr Enter focus Vch Serice (MS_BOOK.cs:3037 {{((Control)tVchSer).Focus();}}); Vch Serice Enter starts the grid at row 1, column 1 when rows exist (MS_BOOK.cs:2978 {{if ((int)e.KeyCode == 13 && MSG.Rows > 1)}} MS_BOOK.cs:2980 {{MSG.Col = 1;}} MS_BOOK.cs:2981 {{MSG.Row = 1;}}). (G5)
Status: executable

### books.keys.grid-navigation   (T17 Keyboard/usability)
Layer: browser
Steps: 1. In the six-row grid press arrows at each edge, then Enter along a row to the last row.
Expected: Left stops at column 1, Right at the last column, Up at row 1, Down at last row; Enter on AcCode/AcName moves to the next row's AcCode and on the last row enables and focuses Save: MS_BOOK.cs:2283 {{if (mSG.Col > 1)}} MS_BOOK.cs:2289 {{if (mSG.Col < mSG.Cols - 1)}} MS_BOOK.cs:2295 {{if (mSG.Row > 1)}} MS_BOOK.cs:2301 {{if (mSG.Row < mSG.Rows - 1)}} MS_BOOK.cs:2357 {{mSG.Row += 1;}} MS_BOOK.cs:2358 {{mSG.Col = 2;}} MS_BOOK.cs:2353 {{((Control)BtnSave).Focus();}}.
Status: executable

### books.keys.f1-esc-ctrl-o   (T17 Keyboard/usability)
Layer: browser
Steps: 1. F1 from the code box and from the list. 2. Esc with unsaved edits. 3. Ctrl+O on a reopened book.
Expected: F1 focuses Search (MS_BOOK.cs:2992 {{if ((int)e.KeyCode == 112)}} MS_BOOK.cs:2994 {{((Control)Text1).Focus();}}); Esc closes without a prompt (MS_BOOK.cs:2849 {{if ((int)e.KeyCode == 27)}}); Ctrl+O does nothing (D6, MS_BOOK.cs:2855 {{((Control)cboInvoTyp).Enabled = true;}} is not ported).
Status: executable

### books.keys.alt-mnemonics   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Alt+S, Alt+P, Alt+C, Alt+D, Alt+X.
Expected: Save, Print, Cancel, Delete, Exit buttons fire: MS_BOOK.cs:1663 {{BtnSave.Text = "&Save";}} MS_BOOK.cs:1676 {{BtnPrint.Text = "&Print";}} MS_BOOK.cs:1650 {{BtnCancel.Text = "&Cancel";}} MS_BOOK.cs:1636 {{BtnDelete.Text = "&Delete";}} MS_BOOK.cs:1623 {{BtnExit.Text = "E&xit";}}.
Status: executable

### books.keys.account-enter-unknown   (T17 Keyboard/usability)
Layer: browser
Steps: 1. AcCode unknown, Enter. 2. Cancel help.
Expected: Help opens, row does not advance, cursor returns to the cell editor: MS_BOOK.cs:2326 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}} MS_BOOK.cs:2337 {{return;}}.
Status: executable

### T18 Full journey

Every journey creates (or edits) its book through this screen, configures slots with these marker accounts (all must exist in the test company): M1 `90001`, M2 `90002`, M3 `90003`, M4 `90004`, M5 `90005`, and then posts the voucher on the voucher's own screen. Voucher amounts come from the voucher module's own fixture (named in each case). Slot meaning in the baseline families is MISSING from the desktop study, so the slot numbers below are those read by the web posting code (`sales/sales.ts:1011,1017,1070,1920`, `purchase/purchase.ts:790,796,802,875`, `finance/finance.ts:127,164`) and are an assumption to be confirmed against the desktop posting code when the baseline table arrives; the asserted fact is that the posted ledger rows use the configured account, whatever it is.

### books.journey.sales-slots   (T18 Full journey)
Layer: browser
Steps: 1. Create book `JS1` family SALES, Outword, slot 1 = M1, slot 2 = M2, slot 3 = M3, slot 4 = M4 (all changed from default). 2. Post a cash sale with the `salesInvoice.mjs` cash-sale fixture on book `JS1`. 3. Query AC_DATA legs of the voucher.
Expected: The sale-value credit is on M1 (not the provisioned SALES account), cash receipt debit on M2, round-off on M3, order-advance adjustment (if the fixture has one) on M4, none on the former defaults. Amount on M1 equals the voucher's sale value as printed on the voucher (read from the voucher, not recomputed); debits equal credits for the voucher. The Sales voucher offers `JS1` in its book help.
Status: executable

### books.journey.sales-edit-slot-then-repost   (T18 Full journey)
Layer: browser
Steps: 1. After the journey above change `JS1` slot 1 to M5. 2. Post a second identical sale. 3. Compare both vouchers; open the first one.
Expected: Voucher 1 legs still on M1; voucher 2 legs on M5 with the same amounts; account balances: M1 = first sale value, M5 = second sale value; opening and editing voucher 1 keeps its legs on M1 unless the voucher is re-saved (then the web uses the current slot, which the case records as the web's rule for the owner to confirm).
Status: executable

### books.journey.purchase-slots   (T18 Full journey)
Layer: browser
Steps: 1. Create book `JP1` family PURCHASE, Inword; slot 1 = M1, slot 2 = M2, slot 3 = M3, slot 4 = M4, slot 5 = `00076` (template default of the PURCHASE slot 5: MS_UPDATE.cs:25022 {{VALUES ('PURCHASE',5,'I','00076','DISCOUNT A/C'}}). 2. Post a purchase with the `purchaseInvoice.mjs` fixture that has a labour amount and a discount.
Expected: Purchase value debit on M1, cash/payment credit on M2, round-off on M3, labour (when the labour-to-slot-4 setting applies) on M4, discount on `00076`; none on the former defaults.
Status: executable

### books.journey.cashbank-slots   (T18 Full journey)
Layer: browser
Steps: 1. Create a CASH REC family book `JC1`: slot 1 = M1 (settlement account), slot 2 = M2 (kasar). 2. Post a receipt of 5,000.00 from a test party with kasar 50.00 via the `cashBank.mjs` receipt flow. 3. Query AC_DATA.
Expected: Per the existing cashBank module (cash receipt: 01 party Cr the received amount against slot 1, 02 slot-1 account Dr the received amount, 03 party Cr kasar against slot 2): M1 Dr 5,000.00, party Cr 5,000.00, M2 Dr 50.00, party Cr 50.00; the voucher's legs balance at 5,050.00 in total debits and credits; no leg on the provisioned CASH or KASAR accounts. Repeat with a BANK PAY book `JC2` (slot 2 = M2): the kasar leg lands on M2 (cashBank.mjs line 528 describes this posting: slot 2 is the kasar account). The slot roles are web-reader assumptions (see the T18 preface).
Status: executable

### books.journey.contra-slots   (T18 Full journey)
Layer: browser
Steps: 1. Create book `JK1` family CONTRA with slot 1 = M1 and slot 2 = M2. 2. Post a contra of 2,000.00 using the `contraEntry.mjs` fixture on book `JK1`.
Expected: The two ledger legs are posted against the accounts the voucher names and the book's slot accounts are used wherever the contra posting reads BOOK_DETL; no leg lands on the provisioned CON slot accounts; total debits 2,000.00 = total credits 2,000.00.
Status: executable

### books.journey.blank-slot-voucher-refused   (T18 Full journey)
Layer: browser
Steps: 1. Create book `JB1` family SALES with slot 2 blank (D5). 2. Post a cash sale on it.
Expected: The save is refused by the voucher with a message naming the missing slot, nothing is written (bookPolicy requires exactly one nonblank matching account: `bookPolicy.ts:124`). The Books screen itself accepted the blank slot.
Status: executable

### books.journey.family-change-refused-after-voucher   (T18 Full journey)
Layer: browser
Steps: 1. After a voucher is posted on `JS1` open the book and change the family. 2. Save.
Expected: The refusal text of D4; slots and voucher legs unchanged (D4; MS_BOOK.cs:2933 {{MSG_CLEAR();}} would otherwise replace the slots).
Status: executable

### books.journey.delete-after-voucher   (T18 Full journey)
Layer: browser
Steps: 1. Try to delete `JS1` (has vouchers). 2. Delete the voucher through its own screen. 3. Delete `JS1` again.
Expected: Step 1 refused: `You Cant Delete Record This Book Code Use in Account Transection....` (MS_BOOK.cs:2710 {{You Cant Delete Record This Book Code Use in Account Transection....}}); step 3 succeeds with `Delete Success.` (MS_BOOK.cs:2723 {{Delete Success.}}) and no slot rows remain.
Status: executable

### books.journey.regression-modules   (T18 Full journey)
Layer: browser
Steps: 1. After the Books page replaces the generic form, re-run the modules `salesInvoice`, `purchaseInvoice`, `cashBank`, `contraEntry`, `salesOrder`, `tagCancel` against the provisioned books.
Expected: All previously passing cases still pass; provisioned books still resolve their slots (the Books change adds no slot or removes none from a book it did not touch).
Status: executable

### books.journey.tag-split-slots   (T18 Full journey)
Layer: browser
Steps: 1. Create `JT1` TAG SPLIT with slots 6 to 9 = M1 to M4. 2. Post a tag split through its screen.
Expected: Split legs use M1 (gold sale, slot 6), M2 (gold purchase, slot 7), M3 (silver sale, slot 8), M4 (silver purchase, slot 9): MS_UPDATE.cs:32098 {{VALUES ('TAG SPLIT',6,'O','00003','SALES GOLD A/C'}} MS_UPDATE.cs:32106 {{VALUES ('TAG SPLIT',8,'O','00004','SALES SILVER A/C'}}. Roles are per the description, not the web seed's swapped roles (G8).
Status: blocked: the desktop posting code that reads Tag Split slots 6 to 9 is not in the study; unblocks when the Tag Split study (another work package) states which leg uses which slot.

## Not-applicable kinds

All eighteen kinds above have at least one case. The following parts of kinds are N/A:

- T03 beyond `books.formula.sr-no-val`: N/A, no monetary formula on this master (MS_BOOK.cs:2152 {{mSG[0] = (int)Math.Round(500.0 * ColCon);}} is pixel scaling).
- Edition A/E behaviours (Data Type, Reset All, employee fields): N/A in Lite, MS_BOOK.cs:3064 {{if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))}}; the single case that asserts they are absent is `books.entry.lite-hidden-controls`.

## Gap-to-case map

| Gap | Cases that fail today because of it |
|---|---|
| 1 slots / composite save | books.field.slot-account-route, books.create.sales-footprint, books.edit.slot-account, books.journey.sales-slots |
| 2 guards / detail cleanup | books.delete.unused, books.delete.refused-account-voucher, books.delete.refused-stock-voucher |
| 3 reserved codes, duplicates, messages | books.invalid.reserved-code-218, -888, -999, -api, books.invalid.blank-short, books.invalid.duplicate-code, books.invalid.duplicate-name |
| 4 limits / defaults | books.entry.defaults, books.invalid.code-max-3, books.invalid.field-limits |
| 5 keys / locks / grid | books.keys.form-flow, books.keys.grid-navigation, books.reopen.locks, books.edit.direction-locked |
| 6 branch clone | books.history.branch-clone (blocked) |
| 7 Other Income / Expenses | books.create.oth-exp-oth-inc |
| 8 Tag Split | books.create.tag-split, books.journey.tag-split-slots (blocked) |
| 9 purchase / labour work slots | books.create.purchase-discount-slot, books.create.labour-work-silver-slots, books.journey.purchase-slots |
| 10 fine families | books.create.fine-families |
| 11 Data Type / AC_NAME defaults | books.invalid.blank-slot-account-allowed, books.field.enum-first-char, books.create.sales-footprint |
| 12 family choices / CUR_USE | books.entry.family-list-from-headers, books.invalid.family-change-with-vouchers, books.history.cur-use-no-hides-book, books.history.blank-cur-use |
| 13 Print | books.output.print-no-right, books.output.print-with-right |

## Coverage table

| Kind | Cases | Blocked |
|---|---|---|
| T01 Entry/defaults | 6 | 0 |
| T02 Field route | 5 | 0 |
| T03 Formula sequence | 1 | 0 |
| T04 Lookup | 6 | 0 |
| T05 Children | 4 | 1 |
| T06 Required/invalid | 15 | 0 |
| T07 Create | 9 | 0 |
| T08 Reopen/no-op | 4 | 0 |
| T09 Edit | 5 | 0 |
| T10 Delete/cancel/reverse | 7 | 1 |
| T11 Scope/rights | 5 | 0 |
| T12 Concurrency | 4 | 0 |
| T13 Retry/unknown | 2 | 0 |
| T14 Rollback | 2 | 1 |
| T15 Config/history | 5 (one N/A: books.history.employee-book) | 1 |
| T16 Report/output | 3 | 0 |
| T17 Keyboard/usability | 5 | 0 |
| T18 Full journey | 10 | 1 |

Counts are by the group heading each case sits under; books.history.branch-clone is the blocked case in T15 and books.journey.tag-split-slots the blocked case in T18. `books.family-each` runs one sub-run per family in the table (about 20 sub-runs), reported separately.

## Test data

Smallest seed the cases need, described not as SQL:

- One company, location `01` (the session), a second location `02` with its own `Z26`, and a second tenant company for isolation cases.
- Accounts with the desktop template codes: `00001` CASH ON HAND, `00002` a second cash/bank account, `00003` SALES GOLD A/C, `00004` SALES SILVER A/C, `00005`, `00006`, `00008` PURCHASE A/C, `00009`, `00020` ORDER ADVANCE, `00041` LABOUR INCOM. A/C, `00042` KASAR AVAK A/C, `00056` LABOUR EXP A/C, `00057` KASAR JAVK A/C, `00061`, `00076` DISCOUNT A/C, `00077`, `00098` FINE KASAR, `00099` SALES A/C; marker accounts `90001` to `90005` (M1 to M5) and one party account.
- Users: one with all Books rights; one with Edit denied; one with Delete denied; one with Print denied; one with the Books right revoked.
- Books: the provisioned set (SL, PR, SRT, RCT, PAY, SOR, CON, JV) plus `Z01` Zeta Sales, `Z02` Zeta Two, `Y01` Yankee (search cases), a book with CUR_USE blank (legacy).
- A posted account voucher on `Z22`, a stock-only entry on `Z23`, a posted sale on `Z11` and `Z31`.
- For T18: the fixtures of the salesInvoice, purchaseInvoice, cashBank, contraEntry modules (one cash sale, one purchase with labour and discount, a receipt of 5,000.00 with kasar 50.00, a contra of 2,000.00).

## Not covered

- Family change on a book with vouchers is refused by the web (D4): a deliberate difference from the desktop, which has no guard. Cases books.invalid.family-change-with-vouchers and books.journey.family-change-refused-after-voucher assert the web message; the owner must confirm it.
- The web's CSV export behind the Print right is a web addition (D7), listed for owner confirmation; it has no desktop counterpart.
- Defaults for baseline families (SALES, SALES RETURNE, PURCHASE slots 1 to 4, PURC RETURN, CASH REC/PAY, BANK REC/PAY, SALES ORDER, ORDER CANCEL, CONTRA, JOURNAL, approval, stock): MISSING, the baseline BOOK_IDTL is not in the study; no default account is asserted for them.
- Which posting leg uses which slot in the baseline families is not desktop-proven (T18 preface); the journeys assert only that the configured account is used.
- Provisioned books already in a company that miss slots (OEX, OIN, TSP, FPR and others): no repair path is specified; only newly created books are covered.
  Since review: migration 20261122090000_book_template_slots repairs the web-seeded OEX/OIN/PR/TPR/TSP/LBR books of existing companies (exact old-seed slots only); fine families (FSL/FPR) stay open.
- Ctrl+O and the A/E reset are absent by decision (D6); only absence is asserted.
- Edition A/E and E employee controls: not Lite.
- Cases blocked for external reasons: books.children.template-sr0-excluded (baseline table), books.delete.atomic and books.rollback.detail-failure-keeps-old (failpoint harness), books.history.branch-clone (Location add), books.journey.tag-split-slots (Tag Split study).
- Desktop runtime behaviour (DataGridView painting, SendKeys timing): static source only, no runtime certification.
