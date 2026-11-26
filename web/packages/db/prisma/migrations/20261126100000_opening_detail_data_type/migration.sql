-- Web-only ownership column for the opening detail rows (PR #292 review round 3). The desktop deletes and lists OP_DETL
-- by account alone (TR_AC_OPBL.cs:2584, :2696, :2877) and DM_DATA by book and type letter (TR_ITM_OPBL.cs:1456, :1511),
-- which lets one data type destroy the other's rows. Every existing row belongs to type A (blank or NULL is read as A).
ALTER TABLE "OP_DETL" ADD COLUMN "DATA_TYPE" varchar(1) DEFAULT 'A';
ALTER TABLE "DM_DATA" ADD COLUMN "DATA_TYPE" varchar(1) DEFAULT 'A';
