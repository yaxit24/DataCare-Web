# verify_masters_rbac_gst — TENANT ver_e

## Roots

- Web: /Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/
- Desktop: /Users/yakshitsavaliya/Desktop/imodule-extracted/extracted_code/DataCareNext/DataCareNext/
- Spec: /Users/yakshitsavaliya/Desktop/imodule-extracted/web-implementation-spec/
- DB: postgresql://app_user:app@127.0.0.1:5433/datacare (PGPASSWORD=app)
- dist already built — DO NOT rebuild.

## Live inject pattern

- script in apps/api/integration/<name>.mjs imports buildApp from ../dist/app.js, withTenant from @datacare/db, hashPassword from ../dist/modules/auth/password.js
- seed LOGIN_MAST admin (tenant_id=ver_e, CO_CODE='01', LOGIN_NAME='admin', LOGIN_PWD=hashPassword('Secret#1'), LOGIN_CATG='ADMIN')
- buildApp({ prisma:new PrismaClient(), secret:'test-secret' }); POST /auth/login header x-tenant-id:ver_e
- WIPE CO_CODE='01' rows before+after; rm script.

## Checklist

- [ ] masters create/update/delete/import generic engine (28 masters), key-immutable, 404/400
- [ ] auth LOGIN_MAST verify (argon2 + plaintext migration), rightsOf admin A*, assertRight 403, USER_SET per-form, /me allowedForms, nav filter
- [ ] settings CO_SET whitelist (26 fields) round-trip + whitelist enforce (THEME rejected)
- [ ] GST split (SGST=tax-CGST), GSTR endpoints; einvoice IRN payload HSN/unit master-driven
- [ ] reports: trial-balance, day-book, stock-valuation, sales-register shapes

## Findings (per form)

(tbd)
