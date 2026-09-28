# Security Notice — Restricted Plaintext Snapshot

This repository intentionally preserves the complete owner-authorized DataCareNext engineering snapshot in plaintext. Private visibility is a required control, not a suggestion.

## Sensitive material intentionally present

- SQL Server `.mdf`, `.ldf`, and `.bak` datasets containing realistic names, mobile numbers, accounting records, and transactions.
- Raw desktop/web parity capture and diff JSON files containing voucher-level records.
- Original and archived Windows executables with legacy remote SQL Server administrator connection strings embedded in the compiled assemblies.
- Decompiled source, extraction dumps, and configuration evidence that reproduce those embedded connection strings and other integration behavior.
- Local web/parity `.env` snapshots containing database passwords and JWT/parity secrets.
- The complete dated RAR deployment archive, which contains databases, executables, dependencies, and configuration.
- Proprietary application code, third-party runtime libraries, reports, images, and business data.

The owner has stated that the database content is a fake/test dataset and explicitly authorized retaining all of the above in the private GitHub repository. Nevertheless, treat every included credential as compromised and every realistic record as restricted data.

## Required controls

1. Keep GitHub repository visibility **private** and grant least-privilege access only to project maintainers.
2. Do not fork to a personal/public namespace, attach repository files to public issues, or copy LFS objects to public storage.
3. Never reuse the embedded database, JWT, integration, or administrator credentials for production systems. Rotate any endpoint that still accepts them.
4. Do not run legacy executables against untrusted or production infrastructure without isolating and reviewing their configured endpoints.
5. Do not paste source, database rows, environment files, or parity captures into third-party AI/services unless separately authorized.
6. Keep Git LFS access aligned with repository access; deleting a pointer from a later commit does not purge the uploaded LFS object.

## Before any visibility change or external distribution

A normal deletion commit is insufficient. Create a sanitized derivative repository and verify it independently. At minimum:

- remove all database, parity-capture, environment, archive, executable, and extraction-dump artifacts;
- redact legacy credentials and personal/business records from text and generated evidence;
- rewrite Git history or start from a clean sanitized export;
- remove/purge restricted Git LFS objects through GitHub support/administration as applicable;
- rotate every credential found in any historical commit or binary;
- run secret and PII scanning over the resulting full history; and
- obtain owner/security approval before publication.

Report accidental exposure immediately to the repository owner and rotate affected credentials before relying on access revocation alone.
