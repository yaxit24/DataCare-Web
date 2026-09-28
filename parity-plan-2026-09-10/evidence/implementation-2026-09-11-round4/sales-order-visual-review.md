# Sales Order final browser visual review

Reviewed original1600×1000 viewport captures from the successful production run `parity-real-stack-round4-blank-source` (2026-09-11T05:51:33.011Z to05:52:20.433Z). The run uses real login/API/isolated database and zero mocked requests.

- `sales-order-loaded-components.png`: configured S41 and saved voucher00003 are clear. Date10/07/2024, customer, advance12.34, labour rate36.3, pre-tax total20781 and the microsecond clock are shown. Editable ordinary fields are distinct from shaded/dashed read-only settlement and Saved Net Amount fields. Read-only labels wrap legibly without overlapping controls. The item specification details are collapsed after the last reload in this viewport; the filename does not imply that its child cells are visible here.
- `sales-order-imported-manual.png`: configured S42/voucher00001, imported customer and date, saved total187.37 and labour basisP/rate10.25 are visible. This capture starts the expanded advanced parent fields near the bottom; child grid cells continue below the viewport. The actual journey separately verifies parent17/children3 and9, unchanged business snapshots, imported NULL fine/metal100/manual77.37 after Other Amt10 and exact clock preservation.

No overlapping or missing visible control was found in these viewport captures. Long text values use the normal input's horizontal editing area rather than a full multiline display, and the advanced fields require scrolling. Further grouping/naming of advanced source fields remains usability work. This is a browser layout review, not an assertion that every advanced child column was visually compared with the running desktop.

Design picker, blank-image and saved-image screenshots are reviewed in the Design/image evidence maintained by their owners. Full desktop operator, migration, financial and report acceptance remains open under the main plan.
