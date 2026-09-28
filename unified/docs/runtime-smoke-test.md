# Runtime Smoke Test

Inputs required before runtime parity can be tested:

- Original-compatible SQL Server database
- Original connection configuration files or registry entries used by the app
- Valid login credentials
- Company/year records visible in `MS_OPNCOMP`
- Full `Report/` directory
- Real vendor DLLs and COM registrations
- Crystal Reports runtime
- MSFlexGrid and Crystal ActiveX registration
- Any hardware/license dependencies for Tagit/RFID/WhatsApp/SMS workflows

Without these inputs, startup can be tested only until the first missing configuration, database, license, COM, or hardware boundary.
