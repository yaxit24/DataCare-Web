import { describe, expect, it } from 'vitest';
import {
  passwordReasonText,
  rightsScreenVisible,
  typedUserName,
  userTypeOf,
} from '../lib/userCreate';

describe('User Create (MS_USER) screen rules', () => {
  it('upper-cases typed names, drops the apostrophe and keeps 15 characters (MS_USER.cs:1786-1799, :1087)', () => {
    expect(typedUserName("ram'esh")).toBe('RAMESH');
    expect(typedUserName('abcdefghijklmnopq')).toBe('ABCDEFGHIJKLMNO');
  });

  it('D36: Lite (and an ungated Lite-default stack) hides the rights grid; Basic and above show it', () => {
    expect(rightsScreenVisible({ code: 'L' })).toBe(false);
    expect(rightsScreenVisible(null)).toBe(false);
    for (const code of ['B', 'S', 'U', 'P', 'A', 'E'])
      expect(rightsScreenVisible({ code })).toBe(true);
  });

  it('maps LOGIN_CATG to the User Type box', () => {
    expect(userTypeOf('A')).toBe('Admin');
    expect(userTypeOf('ADMIN')).toBe('Admin');
    expect(userTypeOf('U')).toBe('User');
    expect(userTypeOf(null)).toBe('User');
  });

  it('explains every D34 reason', () => {
    expect(passwordReasonText(['min-8'])).toBe('Password must have at least 8 characters.');
    expect(passwordReasonText(['common-password', 'login-name'])).toContain('user name');
  });
});
