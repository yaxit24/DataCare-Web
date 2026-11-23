---
description: DataCare-Web dispatched worker. Started only by the orchestration dispatcher with a packet prompt; the rules below stop a session early from doing what the dispatcher's guards would reject afterwards.
mode: primary
permissions:
  - action: shell
    resource: "git push *"
    effect: deny
  - action: shell
    resource: "git commit *"
    effect: deny
  - action: shell
    resource: "git reset *"
    effect: deny
  - action: shell
    resource: "git clean *"
    effect: deny
  - action: shell
    resource: "git checkout *"
    effect: deny
  - action: shell
    resource: "git switch *"
    effect: deny
  - action: shell
    resource: "git stash *"
    effect: deny
  - action: shell
    resource: "git worktree *"
    effect: deny
  - action: shell
    resource: "gh *"
    effect: deny
  - action: read
    resource: "*.env"
    effect: deny
  - action: read
    resource: "*.env.*"
    effect: deny
  - action: read
    resource: "*.env.example"
    effect: allow
  - action: read
    resource: "*.mdf"
    effect: deny
  - action: read
    resource: "*.ldf"
    effect: deny
  - action: read
    resource: "*.bak"
    effect: deny
  - action: edit
    resource: "unified/*"
    effect: deny
  - action: edit
    resource: ".github/*"
    effect: deny
  - action: edit
    resource: "AGENTS.md"
    effect: deny
  - action: edit
    resource: "CLAUDE.md"
    effect: deny
  - action: edit
    resource: "orchestration/bin/*"
    effect: deny
  - action: edit
    resource: "orchestration/lib/*"
    effect: deny
  - action: edit
    resource: "orchestration/config/*"
    effect: deny
  - action: edit
    resource: "orchestration/roles/*"
    effect: deny
  - action: webfetch
    resource: "*"
    effect: deny
---
