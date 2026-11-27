/** Desktop UT_BKP.cs:1258-1261: restore always uses the Print-right refusal, including the web admin boundary. */
export function utilityRefusalText(url: string, action: string): string | undefined {
  if (url === '/backup/restore') return 'You Have No Print Rights.....';
  if (
    /^(\/company-identity|\/years|\/balance-transfer|\/utilities\/data-refresh|\/utilities\/data-import)(\/|$)/.test(
      url,
    ) ||
    url === '/backup'
  )
    return action === 'print' ? 'You Have No Print Rights.....' : 'You Have No Rights.....';
  return undefined;
}
