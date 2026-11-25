# Resolve conflicts in the lineage document where both sides add new entries at the same place:
# keep main's entries first (lower ids), then this branch's, separated by a blank line before a heading.
import re, sys
p = sys.argv[1]; s = open(p).read()
pat = re.compile(r'<<<<<<< [^\n]*\n(.*?)=======\n(.*?)>>>>>>> [^\n]*\n', re.S)
def rep(m):
    ours, theirs = m.group(1), m.group(2)
    if ours.lstrip().startswith('###') and not theirs.endswith('\n\n'):
        theirs = theirs.rstrip('\n') + '\n\n'
    return theirs + ours
s, n = pat.subn(rep, s); open(p, 'w').write(s); print(f'sections resolved: {n}')
