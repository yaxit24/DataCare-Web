# X23 final lot screen visual review — round 3

Reviewed both 1600×1000 viewport screenshots from the passed real production browser run, started 2026-09-11T04:09:46.509Z, against disposable localhost:55433 with app_user and zero mocked requests. These screenshots capture the lower saved component and source-inspection regions; they do not constitute a full-page, mobile or desktop-executable visual comparison.

- Issue: component row 17/9 shows STONE, CH-DIAM and 0.123 gross. The component account and item codes retain separate current-name text. Stock LOT-READ displays GOLD, gross 10.500, net 10.000, pieces 10.000 and gross-weight availability. Its expanded source identity and one collapsed contributor are visible.
- Receipt: the saved component and current names remain readable. Explicit source book LSI and karigar TOURAC are visible. The material table shows 2023-2024 / LSI / 00077 / 42, remaining 4.000 pieces, 4.100 gross and 3.900 net with pieces-based availability. Expanded source identity and two separate contributor entries are visible.
- Both: the company/branch/year bar remains visible; source controls, exact values and Inspect source action fit in the main panel. No clipped action or blocking layout defect was observed in these captures. The explanatory text correctly says inspection does not reserve or consume material.

The source table headings are dense, and additional imported columns such as DM_PCS_GHT still use preserved database-key labels. These remain presentation refinements. Other viewport sizes and complete keyboard/accessibility acceptance remain to be measured. No manufacturing mutation or executable desktop acceptance is claimed.
