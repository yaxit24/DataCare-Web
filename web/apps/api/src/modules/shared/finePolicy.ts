/**
 * The desktop's per-workflow fine-weight policies now live in @datacare/core.
 *
 * WHY THIS FILE IS NOW A RE-EXPORT: the web's per-cell recalculation kernel needs the SAME policies,
 * and the first version of that kernel reimplemented them — getting `sale` wrong twice over (it
 * dropped ghat from the base and lost the `pct === 0 -> net + ght` fallback). A live voucher exposed
 * it: a sale return posted ITM_FINE 5.065 where the client preview predicted 4.605.
 *
 * Keeping one implementation in a package both sides import is the only way client and server cannot
 * disagree. Every desktop citation is preserved in the moved file.
 */
export {
  fineFor,
  round3,
  DEFAULT_FINE_WORKFLOW,
  type FineWorkflow,
  type FineLine,
} from '@datacare/core';
