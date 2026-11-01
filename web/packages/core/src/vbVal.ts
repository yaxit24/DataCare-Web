/**
 * VB `Conversion.Val` of a text box, as the desktop reads its numeric boxes (for example MS_EMP's Amount and Day Hour,
 * MS_EMP.cs:1503-1504): blanks, tabs and line feeds anywhere are skipped, and the longest leading decimal number is
 * read, with an optional sign and an E or D exponent. Anything else ends the number: "12.5 KG" is 12.5, "1 000" is
 * 1000, "1,000" is 1, and "" or "ABC" is 0. The &H and &O radix prefixes are not read (they give 0); no desktop
 * amount box takes them.
 */
export function vbVal(value: unknown): number {
  if (typeof value === 'number') return Number.isFinite(value) ? value : 0;
  const compact = String(value ?? '').replace(/[ \t\r\n]/g, '');
  const match = /^[+-]?(?:\d+(?:\.\d*)?|\.\d+)(?:[eEdD][+-]?\d+)?/.exec(compact);
  if (!match) return 0;
  const parsed = Number(match[0].replace(/[dD]/, 'e'));
  return Number.isFinite(parsed) ? parsed : 0;
}
