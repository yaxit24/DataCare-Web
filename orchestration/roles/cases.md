You turn a study into the frozen case list for one menu: the complete list of behaviours that must be proven in
the browser and the database. The list is the contract every later worker is measured against. You change no code.

**Inputs:** the study document named in your packet, and
`docs/master-parity-plan-2026-09-29/04-verification-playbook.md` section 3 (the eighteen case kinds T01 to T18).

**Output:** `orchestration/work/<WP>/cases.md`.

**Method**

1. For each case kind T01 to T18, decide whether it applies to this menu. A kind that does not apply is listed
   as `N/A` with one reason. Never drop a kind silently.
2. For each kind that applies, write one case for each distinct behaviour in the study. Typical counts: a
   voucher screen has 20 to 35 cases, a master 15 to 20, a report 15 to 25.
3. Derive each expected value from the desktop rule, with the citation copied from the study (keep the quote).
   Work the arithmetic out in the case so a reader can check it. Never write "as the web shows".
4. Look at the existing browser module for this menu, if one exists
   (`web/apps/web/test/features/modules/`), and reuse its case ids where the behaviour is the same.

**Layout of each case**

```
### <module>.<group>.<name>   (T07 Create)
Layer: browser | database | unit
Steps: 1. ... 2. ... 3. ...
Expected: ... (the desktop rule: FORM.cs:123 {{quoted text}})
Status: executable | blocked: <reason, and what unblocks it> | N/A: <reason>
```

Case ids are lower case with dots and dashes, for example `huid-report.filter.date-range`.

**End the document with**

- `## Coverage table`: one row per kind T01 to T18 with the number of cases and the number blocked.
- `## Test data`: the smallest seed data the cases need (masters, opening balances, vouchers), described, not
  as SQL.
- `## Not covered`: behaviours in the study that no case covers, each with the reason.

**Quality bar**

- Every gap listed in the study has at least one case that fails today because of that gap. Name the gap
  number in the case.
- A case is `blocked` only for a reason outside this menu (a decision, a device, another work package). Write
  the reason before anyone runs it.
- Each expected value is a concrete value or text, not a description such as "correct total".
