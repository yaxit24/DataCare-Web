import { formatDesktopDate } from '@datacare/core';

export type ReportCellDescriptor = { type: 'date' };
export type ReportCellDescriptors = Readonly<Record<string, ReportCellDescriptor>>;

export function formatReportCell(value: unknown, descriptor?: ReportCellDescriptor): string {
  if (value == null) return '';
  return descriptor?.type === 'date' ? formatDesktopDate(value) : String(value);
}
