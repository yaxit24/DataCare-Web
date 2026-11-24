# WP-55 result

Before the fix the Lite navigation was the web's route groups filtered by route edition: 34 items were web routes
that serve no Lite desktop menu (for example Customers, Metal Rates, Journal, GSTR-1), and the captions and groups were
the web's (Masters, Sales, Cash / Bank), not the desktop's tabs and captions. The fix gives Lite its own list
(`web/apps/web/lib/liteMenus.ts`).

After the fix `editionNavLite.test.ts` is green: 49 shown, none missing, none extra, no known gaps.
