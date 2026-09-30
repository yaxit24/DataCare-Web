export const PARITY_CONTAINMENT_CODE: 'PARITY_CONTAINMENT';
export const PARITY_CONTAINMENT_WORK_PACKAGE: 'WP-01';

export const parityContainmentOperations: readonly [
  'logical-restore',
  'production-cutover-load',
  'tag-weight-difference',
];

export type ParityContainmentOperation = (typeof parityContainmentOperations)[number];

export interface ParityContainmentRule {
  readonly operation: ParityContainmentOperation;
  readonly blocked: boolean;
  readonly title: string;
  readonly reason: string;
  readonly safeAlternative: string;
  readonly exitGate: string;
  readonly workPackage: 'WP-01';
}

export interface ParityContainmentBody {
  readonly error: 'parity-containment';
  readonly code: 'PARITY_CONTAINMENT';
  readonly operation: ParityContainmentOperation;
  readonly message: string;
  readonly reason: string;
  readonly safeAlternative: string;
  readonly exitGate: string;
  readonly workPackage: 'WP-01';
  readonly retryable: false;
}

export interface ParityContainmentProblem {
  readonly statusCode: 503;
  readonly body: ParityContainmentBody;
}

export const parityContainmentRules: Readonly<
  Record<ParityContainmentOperation, ParityContainmentRule>
>;

export function parityContainmentRule(operation: ParityContainmentOperation): ParityContainmentRule;
export function parityContainmentMessage(operation: ParityContainmentOperation): string;
export function parityContainmentProblem(
  operation: ParityContainmentOperation,
): ParityContainmentProblem | null;
