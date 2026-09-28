from pathlib import Path
import ast,copy,difflib,json,hashlib,importlib.util
p=Path('/tmp/datacare-round15-proof-helpers');s=p/'staged/parity-plan-2026-09-10';b=p/'baseline'
class Strings(ast.NodeTransformer):
 def visit_Constant(self,node):
  return ast.copy_location(ast.Constant('<text>'),node) if isinstance(node.value,str) else node

def functions(path,remove_pending=False):
 tree=ast.parse(path.read_text());out={}
 for n in tree.body:
  if isinstance(n,(ast.FunctionDef,ast.ClassDef)):
   if remove_pending and n.name=='main':
    n.body=[x for x in n.body if not (isinstance(x,ast.Assert) and isinstance(x.test,ast.Compare) and isinstance(x.test.left,ast.Name) and x.test.left.id=='CURRENT_CORE_COUNT')]
   out[n.name]=ast.dump(Strings().visit(n),include_attributes=False)
 return out
pairs=[('capture_implementation_checkpoint_round14.py','capture_implementation_checkpoint_round15.py'),('checkpoint_recipe_round14.py','checkpoint_recipe_round15.py'),('test_checkpoint_recipe_round14.py','test_checkpoint_recipe_round15.py'),('validate_current_review.py','validate_current_review.py')]
checks=[]
for before,after in pairs:
 old=functions(b/before);new=functions(s/after,remove_pending=True);assert old==new,(before,[k for k in old if old[k]!=new.get(k)])
 checks.append({'baseline':before,'derivative':after,'sameFunctionControlStructureIgnoringStringLiterals':True,'count':len(old),'qualification':'Capture adds one explicit pending-core-count publication refusal; exact string changes are separately shown in patch. Global proof literals/strict file list intentionally change.'})
 (p/(after+'.diff')).write_text(''.join(difflib.unified_diff((b/before).read_text().splitlines(True),(s/after).read_text().splitlines(True),fromfile=before,tofile=after)))
def load(name,path):
 spec=importlib.util.spec_from_file_location(name,path);m=importlib.util.module_from_spec(spec);spec.loader.exec_module(m);return m
old=load('_old_recipe',b/'checkpoint_recipe_round14.py');new=load('_new_recipe',s/'checkpoint_recipe_round15.py')
assert list(old.MINIMUM_PREFIXES)==list(new.MINIMUM_PREFIXES)
allowed={'core-final','core-final-test-types','browser-bound','browser-context-bound','browser-labour-bound','recipe-controls-recorded'}
for label,v in old.EXPECTED_PROOFS.items():
 if label not in allowed:assert v==new.EXPECTED_PROOFS[label],label
for label,v in old.MINIMUM_PREFIXES.items():
 assert tuple(x.replace('checkpoint_recipe_round14','checkpoint_recipe_round15').replace('test_checkpoint_recipe_round14','test_checkpoint_recipe_round15') for x in v)==new.MINIMUM_PREFIXES[label],label
assert new.CURRENT_CORE_COUNT==0 and new.CURRENT_CORE_FILES==26
(p/'derivative-audit.json').write_text(json.dumps({'functions':checks,'exact18LabelOrderPreserved':list(new.MINIMUM_PREFIXES),'unchangedProofs':sorted(set(old.EXPECTED_PROOFS)-allowed),'intentionalChangedProofs':sorted(allowed),'allMinimumPrefixMembershipPreservedExceptRound15RecipeFilenames':True,'runtimeHelperByteIdentical':(s/'round14_runtime_inputs.py').read_bytes()==(b/'round14_runtime_inputs.py').read_bytes()},indent=2)+'\n')
print('Function structure,18 labels, minimum prefix sets and unmodified proof commands/literals verified.')
