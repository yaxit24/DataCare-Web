/**
 * User Create (desktop MS_USER) screen rules shared by the page and its unit test.
 */

/** The desktop's message texts, verbatim (MS_USER.cs :1816, :1942, :1950, :1965, :2080-2088, :2141, :2211, :2235, :2241). */
export const USER_TEXT = Object.freeze({
  CREATED: 'User Are Created.',
  NAME_REQUIRED: 'Please Enter User Name.',
  NAME_EXISTS: 'This User Name already Exist.Please Change User Name...',
  PASSWORD_MISMATCH: 'Password Not Match',
  OLD_PASSWORD_REQUIRED: 'Please Insert Old Password',
  OLD_PASSWORD_WRONG: "Old Password Doesn't Match",
  SELECT_FOR_DELETE: 'Please Select User For Delete.',
  DELETE_CONFIRM: 'Are You Sure To Delete This User now?',
  DELETED: 'Delete Success.',
  NO_RIGHTS: 'You Have No Rights.....',
  NO_PRINT_RIGHTS: 'You Have No Print Rights.....',
});

/** tUserName.MaxLength = 15 (MS_USER.cs:1087). */
export const USER_NAME_MAX = 15;

/** MS_USER_KeyPress (:1786-1799): every typed key upper-cased, the apostrophe refused; the box holds 15. */
export function typedUserName(value: string): string {
  return value.toUpperCase().replace(/'/g, '').slice(0, USER_NAME_MAX);
}

/**
 * D36: the Lite edition hides the rights grid and the Update User Right button (MsSoftType = 'L', MS_USER.cs:1489-1495).
 * A deployment without an edition gate is a development or test stack of the Lite default (D33), so it hides them too;
 * Basic and every higher edition show them.
 */
export function rightsScreenVisible(edition: { code?: string | null } | null | undefined): boolean {
  const code = String(edition?.code ?? '').toUpperCase();
  return code !== '' && code !== 'L';
}

/** Web texts for the D34 password rule (the desktop accepts any password, so it has none). */
const REASON_TEXT: Record<string, string> = {
  'min-8': 'Password must have at least 8 characters.',
  'max-128': 'Password may have at most 128 characters.',
  'common-password': 'This password is too common. Please choose another.',
  'login-name': 'Password may not be made from the user name.',
  'company-code': 'Password may not be made from the company code.',
};

export function passwordReasonText(reasons: readonly string[] | undefined): string {
  const texts = (reasons ?? []).map((reason) => REASON_TEXT[reason] ?? reason);
  return texts.length ? texts.join(' ') : 'Password does not meet the password rule.';
}

/** The User Type box: "User" and "Admin" (:1497-1499); LOGIN_CATG keeps the first letter, an admin's starts with A. */
export const USER_TYPES = ['User', 'Admin'] as const;
export type UserType = (typeof USER_TYPES)[number];
export const userTypeOf = (loginCatg: string | null | undefined): UserType =>
  String(loginCatg ?? '')
    .toUpperCase()
    .startsWith('A')
    ? 'Admin'
    : 'User';
