'use client';
import KarigarForm from '../../../../components/KarigarForm';
export default function JobworkReceivePage() {
  // See jobwork-issue: family="jobwork" targets /mfg/jobwork-receive rather than /karigar/receive.
  return <KarigarForm mode="receive" label="Job-work" family="jobwork" />;
}
