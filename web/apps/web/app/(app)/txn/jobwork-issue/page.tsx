'use client';
import KarigarForm from '../../../../components/KarigarForm';
export default function JobworkIssuePage() {
  // family="jobwork" is what routes this to /mfg/jobwork-issue. Without it the form posted /karigar/issue
  // and silently wrote a karigar voucher (desktop TR_JDT_REC writes MFG_DATA/MFG_DETL, not KR_*).
  return <KarigarForm mode="issue" label="Job-work" family="jobwork" />;
}
