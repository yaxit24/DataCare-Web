'use client';

import React from 'react';
import { parityContainmentRule, type ParityContainmentOperation } from '@datacare/core/containment';

export function ParityContainmentNotice({
  operation,
  visible = true,
}: {
  operation: ParityContainmentOperation;
  visible?: boolean;
}) {
  const rule = parityContainmentRule(operation);
  if (!visible || !rule.blocked) return null;

  return (
    <div
      className="msg err"
      role="alert"
      data-testid={`parity-containment-${operation}`}
      data-operation={operation}
    >
      <strong>
        {rule.title} is disabled by the {rule.workPackage} parity safety gate.
      </strong>{' '}
      {rule.reason}
      <div style={{ marginTop: 4 }}>
        <strong>Safe alternative:</strong> {rule.safeAlternative}
      </div>
      <div className="muted" style={{ marginTop: 4 }}>
        Exit gate: {rule.exitGate}
      </div>
    </div>
  );
}

export function ParityContainmentFieldset({
  operation,
  active,
  children,
  ...props
}: Omit<React.FieldsetHTMLAttributes<HTMLFieldSetElement>, 'disabled'> & {
  operation: ParityContainmentOperation;
  active: boolean;
}) {
  const rule = parityContainmentRule(operation);
  return (
    <fieldset {...props} disabled={active && rule.blocked}>
      {children}
    </fieldset>
  );
}
