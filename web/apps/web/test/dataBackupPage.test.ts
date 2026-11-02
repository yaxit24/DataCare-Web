import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { describe, expect, it } from 'vitest';

const source = () => readFileSync(resolve(process.cwd(), 'app/(app)/backup/page.tsx'), 'utf8');

describe('Data Backup operator page source contract', () => {
  it('keeps the desktop-visible Backup-only controls and exact messages', () => {
    const text = source();
    expect(text).toContain('<h1>Backup Data</h1>');
    expect(text).toContain('Backup Path');
    expect(text).toContain('Select');
    expect(text).toContain('role="progressbar"');
    expect(text).toContain('Please Select Path and Try');
    expect(text).toContain('Backup Process Complete.');
    expect(text).toContain('aria-label="Backup recovery limitation"');
    expect(text).toContain('This integrity-checked JSON company archive does not');
    expect(text).toContain('replace the production disaster-recovery backup.');
    expect(text).toContain('DataCare Web provides no operator restore');
    expect(text).toContain('path for this archive.');
    expect(text).not.toMatch(/>\s*(Restore|Dattach)\s*</i);
    expect(text).not.toMatch(/can be restored|restorable|disaster-recovery ready/i);
    expect(text).not.toMatch(/logical-restore|server path|registry/i);
    expect(text.split('\n').length).toBeLessThan(300);
  });

  it('uses the guarded server filename and refuses before issuing a request', () => {
    const text = source();
    expect(text).toContain("getDownload('/backup')");
    expect(text).toContain('a.download = filename');
    expect(text).toContain('selectButton.current?.focus()');
    expect(text).toContain('if (!destinationSelected)');
    expect(text).toContain('useEffect(() =>');
    expect(text).toContain('}, [pathname]);');
    expect(text.indexOf('if (!destinationSelected)')).toBeLessThan(
      text.indexOf("getDownload('/backup')"),
    );
    expect(text).toContain('busyRef.current');
  });
});
