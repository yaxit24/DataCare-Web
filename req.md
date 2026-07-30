# Requirements Document

## Introduction

DataCareNext is a Windows jewelry/gold ERP and accounting application originally written in VB.NET, compiled to .NET Framework 4.7.2 WinForms (DevExpress v19.1, DevComponents DotNetBar2, SAP Crystal Reports, MSFlexGrid/Crystal COM interop) and backed by SQL Server (yearly databases Next23/Next24/Next25 plus a NextImage database). A comprehensive reverse-engineering effort has produced a "unified resource center" at `unified/` containing decompiled C# source (~211 files for DataCareNext plus ~205 for the NextDm variant), original VB.NET source, 255 Crystal `.rpt` report templates, a 304 KB SQL DDL schema, production third-party DLLs, `.resx` resources, configuration, fonts, images, and analysis metadata.

This spec covers two parts delivered as one phased program of work:

1. **Unified Extraction Completeness Audit** — A final, verifiable completeness pass that compares the `unified/` resource center against the raw application files in `imodule-extracted/`, extracts or collects anything still missing, and produces a documented, auditable manifest proving the unified folder holds the complete source code, business logic, workflows, data, reports, and artifacts needed to reproduce the desktop software.

2. **Web Application Rebuild** — A modern web application (the "Web Application") that reproduces the behavior of the desktop DataCareNext app — the same workflows, business logic, accounting rules, data model, and reports — derived from the extracted desktop code, database, and report templates in `unified/`. The web rebuild is organized into phases (foundation/data layer, authentication and company/year selection, master data, core transactions, accounting and reports, integrations) to allow incremental delivery, with acceptance criteria framed around behavioral parity with the desktop application.

Because this is a very large ERP (≈161 forms, ≈13,995 SQL queries, ≈8,308 methods), the requirements below define **what** parity means and **how** completeness is verified, while deferring per-form implementation breakdown to the design and task phases. The desktop application is the source of truth ("golden master") for all behavioral parity decisions.

## Glossary

- **Unified_Center**: The `unified/` directory tree that aggregates all extracted source, reports, schema, binaries, resources, configuration, and metadata for the desktop application.
- **Raw_Source**: The original/raw application artifacts under `imodule-extracted/` outside of `unified/` (loose `.rpt` files, `DataCareNext.exe`, `DataCareNext_Source/`, `DataCareSetup/`, etc.) that the audit compares against.
- **Audit_System**: The tooling, scripts, and processes that perform the completeness audit and produce the completeness manifest.
- **Completeness_Manifest**: A generated, machine-readable report enumerating every required desktop artifact, its presence/absence in the Unified_Center, and the verification result for each.
- **Desktop_App**: The DataCareNext WinForms application, treated as the behavioral golden master.
- **Web_Application**: The new web application being built to reproduce Desktop_App behavior.
- **Parity**: Behavioral equivalence between the Web_Application and the Desktop_App for a given workflow, given the same input data, measured by matching persisted data changes, computed values, and report output.
- **Company**: A top-level tenant identified by `CO_CODE` (e.g. `01`).
- **Location**: A branch/counter within a Company identified by `LC_CODE`.
- **Year**: An accounting/financial year identified by `CO_YEAR`, corresponding to a yearly database (Next23/Next24/Next25).
- **Book**: A voucher series/ledger book identified by `CO_BOOK` within a Company/Location, governing voucher numbering and posting (e.g. `SALES`).
- **Voucher**: A single transaction document (sale, purchase, receipt, payment, loan issue, manufacturing entry, etc.) with a header and detail lines.
- **Ledger_Posting**: The double-entry accounting records (debit/credit rows in `AC_DATA`) generated when a Voucher is saved.
- **Tag**: A barcode/RFID-labeled physical jewelry item tracked in `TAG_STOCK`/`TAG_MAST` with weight, touch (purity), and labour attributes.
- **Fine_Weight**: Pure-metal weight, computed from net weight and touch/purity; the core stock-valuation unit for gold/silver.
- **Touch**: Purity percentage of a metal item used to compute Fine_Weight.
- **Labour_Charge**: The making/labour amount applied to an item, computed by labour type (per-piece, per-gram, percentage, or fixed).
- **Master_Data**: Reference/setup records (accounts, items, customers, employees, rates, taxes, books, etc.) consumed by transactions.
- **GST_Engine**: The logic that computes CGST/SGST/IGST splits based on the customer's GST type and applicable tax rates.
- **E_Invoice**: The Indian government IRN (Invoice Reference Number) e-invoicing integration.
- **Report_Engine**: The component that produces formatted report/document output equivalent to the Desktop_App Crystal Reports.
- **User_Right**: A per-user permission flag (`USER_UPDATE`, `USER_DELETE`, `USER_PRINT`, and per-form/menu access) controlling allowed actions.

---

## Requirements

### Requirement 1: Extraction Completeness Inventory

**User Story:** As a maintainer, I want a verifiable inventory of every required desktop artifact and whether it exists in the Unified_Center, so that I can trust the unified folder is a complete basis for the rebuild.

#### Acceptance Criteria

1. WHEN the Audit_System runs a completeness scan, THE Audit_System SHALL enumerate every reachable `.rpt` report template in Raw_Source and record, for each, whether an identical-named template exists in `unified/reports`.
2. WHEN the Audit_System runs a completeness scan, THE Audit_System SHALL enumerate every form/module source file referenced by the Desktop_App and record whether a corresponding decompiled source file exists in `unified/src`.
3. WHEN the Audit_System runs a completeness scan, THE Audit_System SHALL enumerate every database table named in `unified/extraction_metadata/database_tables.txt` and record whether a `CREATE TABLE` definition for that table exists in `unified/database/schema/01_Schema.sql`.
4. WHEN the Audit_System runs a completeness scan, THE Audit_System SHALL enumerate every third-party DLL, `.resx` resource, font, and configuration file required by the Desktop_App and record its presence or absence in the Unified_Center.
5. WHEN the completeness scan finishes AND at least one required artifact was enumerated, THE Audit_System SHALL write a Completeness_Manifest listing each required artifact, its category, and a status value of `present` or `missing`.
6. IF a required artifact is classified as `missing`, THEN THE Audit_System SHALL record the artifact identifier and its Raw_Source location in the Completeness_Manifest.

### Requirement 2: Missing Artifact Collection

**User Story:** As a maintainer, I want anything still missing from the Unified_Center to be collected from Raw_Source, so that the unified folder becomes the single complete resource center.

#### Acceptance Criteria

1. WHEN an artifact is classified as `missing` in the Completeness_Manifest AND that artifact exists in Raw_Source, THE Audit_System SHALL copy the artifact into the corresponding Unified_Center subdirectory.
2. WHEN an artifact is copied into the Unified_Center, THE Audit_System SHALL record the source path, destination path, and a content checksum in the Completeness_Manifest.
3. WHEN a copied artifact already exists at the destination with differing content, THE Audit_System SHALL preserve both versions by recording the conflict and the checksum of each version in the Completeness_Manifest.
4. IF a required artifact is absent from both the Unified_Center and Raw_Source, THEN THE Audit_System SHALL record the artifact as an `external-blocker` in the Completeness_Manifest with an explanatory note.
5. WHEN the collection step completes, THE Audit_System SHALL re-run the completeness scan and report the count of artifacts remaining in `missing` status.

### Requirement 3: Data Model Extraction and Documentation

**User Story:** As a developer building the web version, I want the complete relational data model documented from the extracted schema and live databases, so that the Web_Application can reproduce the desktop data structures exactly.

#### Acceptance Criteria

1. WHEN the Audit_System parses `unified/database/schema/01_Schema.sql`, THE Audit_System SHALL produce a structured catalog of every table with its columns, data types, nullability, defaults, primary keys, and constraints.
2. THE Audit_System SHALL record, for each table in the catalog, the composite key columns used for multi-tenancy (`CO_CODE`, `LC_CODE`, `CO_YEAR`, `CO_BOOK` where present).
3. WHEN parsing the schema produces a table whose columns cannot be fully resolved from the DDL, THE Audit_System SHALL supplement the catalog using column names observed in the live database backups under `unified/database` and mark the source of each supplemented column.
4. IF a table referenced by decompiled SQL queries is absent from the schema catalog, THEN THE Audit_System SHALL record the table name and the referencing source file in the Completeness_Manifest.
5. WHERE the schema catalog contains at least one resolved table, THE Audit_System SHALL output the data model catalog as a machine-readable document stored in the Unified_Center.

### Requirement 4: Business Logic and Workflow Catalog

**User Story:** As a developer, I want the desktop business logic and workflows catalogued from the decompiled source, so that the web rebuild has a documented behavioral specification per module.

#### Acceptance Criteria

1. WHEN the Audit_System analyzes the decompiled source in `unified/src`, THE Audit_System SHALL produce a catalog mapping each transaction form to the database tables it writes on save.
2. THE Audit_System SHALL record, for each transaction form in the catalog, the sequence of persistence operations performed on save (header write, detail write, ledger posting, stock posting, tax posting).
3. THE Audit_System SHALL record, for each transaction form in the catalog, the validation rules enforced before save.
4. THE Audit_System SHALL record, for each transaction form in the catalog, the reverse operations performed on delete, including stock restoration and deletion logging.
5. THE Audit_System SHALL classify every catalogued form into a module category (master data, transaction, report, utility) consistent with the categories in the Unified_Center metadata.

### Requirement 5: Web Foundation and Data Layer

**User Story:** As a developer, I want a web application foundation with a data layer that mirrors the desktop data model, so that later phases can implement workflows against an accurate schema.

#### Acceptance Criteria

1. THE Web_Application SHALL provide a relational data layer whose tables and columns correspond to the desktop schema catalog produced in Requirement 3.
2. WHERE a desktop table uses the composite multi-tenant key (`CO_CODE`, `LC_CODE`, `CO_YEAR`, `CO_BOOK`), THE Web_Application SHALL preserve those key columns and enforce them in data access.
3. WHEN the Web_Application reads or writes transactional data, THE Web_Application SHALL scope every query by the active Company, Location, and Year.
4. WHEN the Web_Application performs any persistence operation, whether single-table or multi-table, THE Web_Application SHALL execute all writes for that operation within a single database transaction that is committed only if every write succeeds.
5. IF any write within a multi-table workflow fails, THEN THE Web_Application SHALL roll back the entire transaction and leave the database unchanged.
6. THE Web_Application SHALL expose a server-side API layer that requires authentication for every data-access endpoint.

### Requirement 6: Authentication and User Rights

**User Story:** As a user, I want to log in with my company, location, and credentials and have my permissions enforced, so that access matches the desktop application's security model.

#### Acceptance Criteria

1. WHEN a user submits a Company code, Location, User ID, and password, THE Web_Application SHALL authenticate the credentials against the `LOGIN_MAST` records for that Company.
2. IF the submitted credentials do not match an active `LOGIN_MAST` record, THEN THE Web_Application SHALL reject the login and return an authentication-failure response without establishing a session.
3. WHEN authentication succeeds, THE Web_Application SHALL establish a session carrying the user's Company, Location, and resolved User_Right flags (`USER_UPDATE`, `USER_DELETE`, `USER_PRINT`).
4. WHEN a user without `USER_UPDATE` right attempts a create or update action, THE Web_Application SHALL deny the action and return an authorization-failure response.
5. WHEN a user without `USER_DELETE` right attempts a delete action, THE Web_Application SHALL deny the action and return an authorization-failure response.
6. WHEN a user without `USER_PRINT` right attempts a print or report-generation action, THE Web_Application SHALL deny the action and return an authorization-failure response.
7. WHERE a user lacks access to a specific menu or form per their stored rights, THE Web_Application SHALL omit that menu or form from the user's available navigation.

### Requirement 7: Company and Year Selection

**User Story:** As a user, I want to select a company and accounting year after login, so that all my work is scoped to the correct dataset like the desktop's MS_OPNCOMP step.

#### Acceptance Criteria

1. WHEN an authenticated user opens the company/year selection, THE Web_Application SHALL list the Companies and Years available to that user.
2. WHEN a user selects a Company and Year, THE Web_Application SHALL load the corresponding company settings and apply them to the session.
3. WHEN a Company and Year are active, THE Web_Application SHALL scope all subsequent master and transaction operations to that Company and Year.
4. IF a user selects a Year for which no dataset exists, THEN THE Web_Application SHALL reject the selection and report that the Year is unavailable.
5. WHEN the active Company and Year change, THE Web_Application SHALL reload navigation and settings to reflect the newly selected context.

### Requirement 8: Master Data Management

**User Story:** As a user, I want to manage master data (accounts, items, customers, rates, taxes, books, employees), so that transactions can reference accurate reference data as in the desktop app.

#### Acceptance Criteria

1. WHEN a user creates a Master_Data record with all required fields populated, THE Web_Application SHALL persist the record scoped to the active Company.
2. IF a user submits a Master_Data record missing a required field, THEN THE Web_Application SHALL reject the save and report which required field is missing.
3. IF a user creates a Master_Data record whose key duplicates an existing record within the same Company, THEN THE Web_Application SHALL reject the save and report the duplicate-key conflict.
4. WHEN a user updates an existing Master_Data record, THE Web_Application SHALL persist the changed fields while preserving the record's key.
5. WHEN a user deletes a Master_Data record that is not referenced by any transaction, THE Web_Application SHALL remove the record.
6. IF a user attempts to delete a Master_Data record referenced by an existing transaction, THEN THE Web_Application SHALL reject the deletion and report the referential conflict.

### Requirement 9: Voucher Numbering

**User Story:** As a user, I want voucher numbers generated per book exactly as the desktop does, so that document sequences remain consistent and unique.

#### Acceptance Criteria

1. WHEN a user starts a new Voucher in a Book, THE Web_Application SHALL assign the next sequential voucher number for that Company, Location, Year, and Book.
2. THE Web_Application SHALL ensure each generated voucher number is unique within its Company, Location, Year, and Book.
3. WHEN two users request a new voucher number for the same Book concurrently, THE Web_Application SHALL assign distinct voucher numbers to each request.
4. WHEN a Voucher is saved, THE Web_Application SHALL persist the assigned voucher number with the Voucher header.

### Requirement 10: Sales Transactions

**User Story:** As a salesperson, I want to create, edit, and delete sales bills with items, amounts, and tax exactly as the desktop, so that sales are recorded with correct accounting, stock, and tax effects.

#### Acceptance Criteria

1. WHEN a user adds a Tag-based item to a sale, THE Web_Application SHALL populate the line from the Tag's stock record (item, gross weight, net weight, labour, rate type).
2. IF a user adds a Tag that does not exist in stock for the active Company and Location, THEN THE Web_Application SHALL reject the addition and report that the Tag was not found.
3. WHEN sale line items change, THE Web_Application SHALL recompute the bill net amount, discount amount, taxable amount, tax amount, round-off, and total amount.
4. WHEN the customer's GST type is inter-state, THE Web_Application SHALL allocate the full tax amount to IGST and zero to CGST and SGST.
5. WHEN the customer's GST type is intra-state, THE Web_Application SHALL split the tax amount equally between CGST and SGST and set IGST to zero.
6. IF a user attempts to save a sale with no line items, THEN THE Web_Application SHALL reject the save and report that at least one item is required.
7. IF a user attempts to save a sale with no customer account selected, THEN THE Web_Application SHALL reject the save and report that an account is required.
8. WHEN a sale is saved, THE Web_Application SHALL write the sale header, sale detail lines, the customer Ledger_Posting, the stock-out entries, and the tax entry within a single transaction.
9. WHEN a sale is saved, THE Web_Application SHALL remove the sold Tags from available Tag stock.
10. WHEN a sale is deleted by a user with delete rights, THE Web_Application SHALL remove the sale header, detail, ledger, stock, and tax records, restore the sold Tags to stock, and write a deletion-log record.

### Requirement 11: Purchase Transactions

**User Story:** As a purchaser, I want to record purchase bills with items, weights, and tax, so that inventory and supplier ledgers update with correct accounting effects.

#### Acceptance Criteria

1. WHEN a user adds an item line to a purchase, THE Web_Application SHALL compute the line Fine_Weight from net weight and Touch and the line amount from rate and labour.
2. WHEN a purchase is saved, THE Web_Application SHALL write the purchase header, purchase detail lines, the supplier Ledger_Posting, the stock-in entries, and the tax entry within a single transaction.
3. IF a user attempts to save a purchase missing a supplier account or with no line items, THEN THE Web_Application SHALL reject the save and report the missing required data.
4. WHEN a purchase is saved, THE Web_Application SHALL add the purchased items to stock for the active Company and Location.
5. WHEN a purchase is deleted by a user with delete rights, THE Web_Application SHALL reverse the stock-in entries and remove the associated header, detail, ledger, and tax records within a single transaction.

### Requirement 12: Weight, Fine, and Labour Calculations

**User Story:** As a user, I want metal weight, fine weight, and labour amounts computed exactly as the desktop, so that valuations and bill amounts match the desktop output.

#### Acceptance Criteria

1. THE Web_Application SHALL compute Fine_Weight as net weight multiplied by Touch divided by 100, rounded to the same precision as the Desktop_App.
2. WHERE the labour type is per-gram, THE Web_Application SHALL compute Labour_Charge as net weight multiplied by the labour rate.
3. WHERE the labour type is per-piece, THE Web_Application SHALL compute Labour_Charge as piece count multiplied by the labour rate.
4. WHERE the labour type is percentage, THE Web_Application SHALL compute Labour_Charge as the item metal amount multiplied by the labour percentage divided by 100.
5. WHERE the labour type is fixed, THE Web_Application SHALL set Labour_Charge to the fixed labour amount.
6. WHEN computing a line net amount, THE Web_Application SHALL sum the metal amount, the Labour_Charge, and other charges for that line.
7. THE Web_Application SHALL produce calculation results that match the Desktop_App results for the same inputs to the Desktop_App's rounding precision.

### Requirement 13: Double-Entry Accounting and Ledgers

**User Story:** As an accountant, I want every transaction to post balanced double-entry ledger records, so that ledger balances and trial balances match the desktop.

#### Acceptance Criteria

1. WHEN a transaction generates a Ledger_Posting, THE Web_Application SHALL record debit and credit entries whose totals are equal for that Voucher.
2. WHEN a user views an account ledger for a date range, THE Web_Application SHALL compute the opening balance, period debits and credits, and closing balance from the posted ledger entries.
3. THE Web_Application SHALL compute a trial balance whose total debits equal its total credits across all accounts for the active Company and Year.
4. WHEN a Voucher that produced ledger entries is deleted, THE Web_Application SHALL remove that Voucher's ledger entries so that subsequent balances exclude the deleted Voucher.
5. WHERE separate fine-weight (metal) ledgers exist alongside amount ledgers, THE Web_Application SHALL post and balance metal-weight entries independently of amount entries.

### Requirement 14: Tag and Stock Management

**User Story:** As an inventory manager, I want tagged-item stock tracked through transactions, so that on-hand stock and fine-weight balances stay accurate as in the desktop.

#### Acceptance Criteria

1. WHEN a Tag is created, THE Web_Application SHALL persist the Tag with its item code, gross weight, net weight, Touch, labour attributes, and a unique Tag number within the Company and Location.
2. WHEN a transaction issues a Tag out of stock, THE Web_Application SHALL mark that Tag as unavailable for further issue.
3. WHEN a transaction returns or restores a Tag to stock, THE Web_Application SHALL make that Tag available for issue again.
4. THE Web_Application SHALL compute on-hand stock quantity, gross weight, net weight, and Fine_Weight for an item as the net of all stock-in and stock-out postings for the active Company and Location.
5. IF a sale would issue a Tag already issued out of stock, THEN THE Web_Application SHALL reject the issue and report that the Tag is not available.

### Requirement 15: Loan (Dhrn) Management

**User Story:** As a loan officer, I want to issue and receive gold loans with interest, so that loan accounts and outstanding balances match the desktop's Dhrn workflows.

#### Acceptance Criteria

1. WHEN a loan issue is saved, THE Web_Application SHALL record the loan principal, the pledged-item details, and the associated Ledger_Posting within a single transaction.
2. WHEN a loan receipt is recorded, THE Web_Application SHALL reduce the outstanding loan balance by the received principal and record received interest separately.
3. THE Web_Application SHALL compute loan interest from the principal, the applicable interest rate, and the elapsed period using the Desktop_App's interest method.
4. WHEN a user views a loan's status, THE Web_Application SHALL report the outstanding principal, accrued interest, and pledged items for that loan.

### Requirement 16: Manufacturing (Karigar/Job-Work) Management

**User Story:** As a production manager, I want to issue material to karigars and receive finished items, so that job-work balances and metal accountability match the desktop.

#### Acceptance Criteria

1. WHEN material is issued to a karigar, THE Web_Application SHALL record the issued gross weight, net weight, Fine_Weight, and piece count against that karigar within a single transaction.
2. WHEN finished items are received from a karigar, THE Web_Application SHALL record the received weights and compute the wastage and the karigar's metal balance.
3. THE Web_Application SHALL compute each karigar's outstanding metal balance as issued Fine_Weight net of received Fine_Weight for the active Company and Year.
4. WHEN a manufacturing receipt is saved, THE Web_Application SHALL add the finished items to stock within the same transaction that records the receipt.

### Requirement 17: Receipts, Payments, and Financial Vouchers

**User Story:** As a cashier, I want to record cash, card, UPI, cheque receipts and payments and contra entries, so that cash and bank ledgers reconcile as in the desktop.

#### Acceptance Criteria

1. WHEN a receipt or payment voucher is saved, THE Web_Application SHALL post balanced debit and credit Ledger_Postings for the selected accounts within a single transaction.
2. WHERE a cash transaction amount exceeds the configured cash limit, THE Web_Application SHALL require the customer's PAN before allowing the save.
3. WHEN a contra entry between two accounts is saved, THE Web_Application SHALL debit one account and credit the other for the same amount.
4. WHEN a card, UPI, or cheque receipt is recorded, THE Web_Application SHALL post the receipt to the corresponding bank or clearing account and to the customer account.

### Requirement 18: GST and E-Invoice

**User Story:** As a compliance user, I want GST computed and e-invoices generated per Indian rules, so that tax reporting and IRN generation match the desktop behavior.

#### Acceptance Criteria

1. WHEN computing tax on a taxable sale, THE GST_Engine SHALL apply the item's applicable GST rate to the taxable amount after discount.
2. WHEN the supply is intra-state, THE GST_Engine SHALL split the computed tax equally into CGST and SGST.
3. WHEN the supply is inter-state, THE GST_Engine SHALL assign the computed tax entirely to IGST.
4. WHEN a user requests an E_Invoice for an eligible sale, THE Web_Application SHALL submit the invoice payload to the configured IRN service and store the returned IRN and acknowledgement details with the sale.
5. IF the IRN service returns an error for an E_Invoice request, THEN THE Web_Application SHALL record the error response and leave the sale without an IRN.
6. THE Web_Application SHALL produce GST return datasets (B2B, B2CL, B2CS, HSN summary) from posted sales for a selected period.

### Requirement 19: Reports

**User Story:** As a user, I want to generate the application's reports and printable documents from web, so that I get output equivalent to the desktop Crystal Reports.

#### Acceptance Criteria

1. WHEN a user generates a report for a selected scope and date range, THE Report_Engine SHALL produce output containing the same data fields as the corresponding Desktop_App report template.
2. WHEN a user generates a sales invoice document for a Voucher, THE Report_Engine SHALL include the customer details, item lines, weights, amounts, tax breakdown, and totals present on the Desktop_App invoice.
3. WHEN a user generates an account ledger report, THE Report_Engine SHALL include opening balance, dated transaction lines, and closing balance.
4. WHERE the Desktop_App produces a report as a specific document layout, THE Report_Engine SHALL provide an exportable document (PDF) of that report.
5. IF a report is requested for a scope with no matching data, THEN THE Report_Engine SHALL produce an empty report indicating no records were found.

### Requirement 20: Integrations (WhatsApp, SMS, QR, Tag/Barcode Printing)

**User Story:** As a user, I want to send documents via WhatsApp/SMS and print tags and QR codes, so that the web version supports the same customer-facing and labeling integrations as the desktop.

#### Acceptance Criteria

1. WHEN a user sends a document via WhatsApp, THE Web_Application SHALL transmit the document to the configured WhatsApp service for the customer's mobile number.
2. WHEN a user sends an SMS notification, THE Web_Application SHALL transmit the message to the configured SMS service for the customer's mobile number.
3. IF an integration service is unreachable or returns an error, THEN THE Web_Application SHALL record the failure and report it to the user without aborting the underlying transaction.
4. WHEN a user prints tags, THE Web_Application SHALL generate tag labels encoding each Tag number as a scannable barcode.
5. WHEN a user generates a QR code for a document, THE Web_Application SHALL encode the document's identifying data into a scannable QR image.

### Requirement 21: Behavioral Parity Verification

**User Story:** As a stakeholder, I want each web workflow validated against the desktop using the same data, so that I can confirm the web rebuild reproduces desktop behavior.

#### Acceptance Criteria

1. WHEN a representative transaction is executed in the Web_Application against a dataset restored from the desktop database backups, THE Web_Application SHALL persist the same header, detail, ledger, stock, and tax records that the Desktop_App persists for the same input.
2. WHEN a computed value (fine weight, labour, tax split, totals, ledger balance) is produced for a given input, THE Web_Application SHALL match the Desktop_App's value to the Desktop_App's rounding precision.
3. WHEN a report is generated for a given scope, THE Web_Application report dataset SHALL contain the same records as the corresponding Desktop_App report for the same scope.
4. IF a parity check detects a difference between Web_Application output and Desktop_App output, THEN the verification SHALL record the differing fields and the inputs that produced them.

### Requirement 22: Phased and Incremental Delivery

**User Story:** As a project owner, I want the rebuild delivered in independently verifiable phases, so that value is delivered incrementally for this large ERP.

#### Acceptance Criteria

1. THE Web_Application SHALL be organized so that the foundation/data-layer phase can be completed and verified before transaction phases begin.
2. THE Web_Application SHALL be organized so that authentication and company/year selection are available before master-data and transaction phases are exercised.
3. WHERE a later phase is not yet implemented, THE Web_Application SHALL remain operable for the phases already delivered.
4. WHEN a phase is completed, THE phase SHALL be independently verifiable through its own acceptance criteria without requiring unimplemented phases.

