# Generic admission test barrier correction

Test-only correction after the first 67-case focused pass. Four waits now race the operation that must reach their barrier; early rejection or unexpected completion reaches the existing finally block, which releases the gate and settles all started operations. Release waits inside transaction callbacks are unchanged. No schedule, SQL, assertion, production source, deadline or frozen fixture changed. No compiler, tests or database process was run for this correction. The earlier frozen stage remains untouched.
