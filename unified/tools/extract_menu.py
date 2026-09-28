#!/usr/bin/env python3
"""
extract_menu.py — recover the desktop main-menu hierarchy from MDI_FORM.cs so the web nav can mirror it.
Produces project-memory/catalogs/menu-tree.json:
  items : [{name, caption, rightName, form}]   (menu item -> its caption, USER_SET right key, target form)
  tree  : {parentName: [childName,...]}         (from .Items/.DropDownItems.AddRange)
  menus : resolved parent->children with captions
macOS-only (regex over C#). Run: python3 unified/tools/extract_menu.py
"""
import json, re, os

SRC = 'extracted_code/DataCareNext/DataCareNext/MDI_FORM.cs'
OUT = 'project-memory/catalogs/menu-tree.json'
text = open(SRC, encoding='utf-8', errors='replace').read()

# 1) captions: `<name>.Text = "caption"` (with optional cast prefix)
captions = {}
for m in re.finditer(r'(\w+)\)?\.Text\s*=\s*"([^"]*)"', text):
    name, cap = m.group(1), m.group(2).strip()
    if cap and name not in captions:
        captions[name] = cap

# 2) click handlers: item name -> right key + target form
items = []
chunks = re.split(r'(?=private void \w+_Click\()', text)
for ch in chunks:
    hm = re.match(r'private void (\w+)_Click\(', ch)
    if not hm:
        continue
    handler = hm.group(1)
    body = ch[:6000]
    right = None
    rm = re.search(r'MsUserRightForm\s*=\s*"([^"]+)"', body)
    if rm:
        right = rm.group(1)
    fm = re.search(r'new ([A-Z][A-Z_0-9]{2,})\(\)', body)
    form = fm.group(1) if fm else None
    base = re.sub(r'(ToolStripMenuItem|MenuItem)$', '', handler)
    cap = captions.get(handler) or captions.get(base) or right or None
    items.append({'handler': handler, 'name': base, 'caption': cap, 'rightName': right, 'form': form})

# 3) tree: parent -> children from AddRange(new ToolStripItem[N] { ... })
tree = {}
for m in re.finditer(r'(\w+)\)?\.(?:Items|DropDownItems)\.AddRange\((?:[^{]*?)new ToolStripItem\[\d+\]\s*\{([^}]*)\}', text, re.S):
    parent = m.group(1)
    kids = [k.strip() for k in re.split(r'[,\n]', m.group(2)) if re.match(r'^\(?\w', k.strip())]
    kids = [re.sub(r'^\(?(?:ToolStripItem\)|Control\))?', '', k).strip().rstrip(')') for k in kids]
    kids = [k for k in kids if k and k not in ('object', 'new')]
    if kids:
        tree[parent] = kids

def cap_of(n):
    return captions.get(n) or captions.get(n + 'ToolStripMenuItem') or n

menus = []
for parent in tree:
    menus.append({'menu': parent, 'caption': cap_of(parent), 'children': [{'name': k, 'caption': cap_of(k)} for k in tree[parent]]})

out = {
    'source': 'MDI_FORM.cs',
    'captionCount': len(captions),
    'itemCount': len(items),
    'menuGroups': len(tree),
    'items': items,
    'tree': tree,
    'menus': menus,
}
os.makedirs(os.path.dirname(OUT), exist_ok=True)
json.dump(out, open(OUT, 'w'), indent=1)
wired = [i for i in items if i['form']]
print(f'captions={len(captions)} items={len(items)} wired-to-form={len(wired)} menuGroups={len(tree)}')
print('sample wired items:')
for i in wired[:10]:
    print(f"  {(i['caption'] or i['name'])[:34]:34} -> {i['form']:16} right={i['rightName']}")
