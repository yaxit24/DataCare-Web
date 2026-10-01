# Third-party sources for DataCare skills

Three skills in this repository are DataCare-specific adaptations of skills from **Superpowers**
(https://github.com/obra/superpowers), by Jesse Vincent and Prime Radiant, used under the MIT licence.

| DataCare skill | Adapted from the Superpowers skill |
|---|---|
| `.kiro/skills/datacare-debug/SKILL.md` | `systematic-debugging` |
| `.kiro/skills/datacare-test-first/SKILL.md` | `test-driven-development` |
| `.kiro/skills/datacare-verify-before-done/SKILL.md` | `verification-before-completion` |

They were rewritten for this project (desktop-derived expected values, the real test tiers and gate commands, the
plan's "never loosen a test" rule) rather than copied, so they do not depend on the Superpowers plugin or its other
skills. The method — root cause before fix, test first, evidence before claims — is Superpowers'.

Pulled from Superpowers commit `8ca22dba9a94f28898bbce59f2537ff4d87c747d` (1 October 2026).

## Licence

```
MIT License

Copyright (c) 2025 Jesse Vincent

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
