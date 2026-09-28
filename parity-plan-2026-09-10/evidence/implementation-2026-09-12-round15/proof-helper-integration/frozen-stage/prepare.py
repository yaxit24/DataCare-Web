from pathlib import Path
import hashlib,json,difflib,datetime
root=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted');plan=root/'parity-plan-2026-09-10';out=Path('/tmp/datacare-round15-proof-helpers');stage=out/'staged/parity-plan-2026-09-10'
sha=lambda b:hashlib.sha256(b).hexdigest()
oldsha='db25b3e107d6e67629f2d445cb2ee191ff9794220cb19dac8cfc7ac9edfababf';newsha='643bf89ad0ac50729c7feff06c28dfa6bf8cca7d6318e498397cd5c57bf9ebea'
assert sha((plan/'41-implementation-checkpoint-round14.json').read_bytes())==newsha
names=['capture_implementation_checkpoint_round14.py','checkpoint_recipe_round14.py','test_checkpoint_recipe_round14.py','validate_current_review.py','run_check_round15.py','round14_runtime_inputs.py','capture_implementation_checkpoint_round12_isolated.py']
refs=[]
for n in names:
 b=(plan/n).read_bytes();(out/'baseline'/n).write_bytes(b);refs.append({'path':str(plan/n),'sha256':sha(b)})
refs.append({'path':str(plan/'41-implementation-checkpoint-round14.json'),'sha256':newsha})
(out/'baseline-inputs.json').write_text(json.dumps({'capturedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'files':refs},indent=2)+'\n')
cap=(plan/names[0]).read_text().replace("'41-implementation-checkpoint-round14.json'","'43-implementation-checkpoint-round15.json'").replace("'40-implementation-progress-round14.md'","'42-implementation-progress-round15.md'")
cap=cap.replace('checkpoint_recipe_round14','checkpoint_recipe_round15').replace('capture_implementation_checkpoint_round14','capture_implementation_checkpoint_round15').replace('run_check_round14','run_check_round15').replace('test_checkpoint_recipe_round14','test_checkpoint_recipe_round15').replace('implementation-2026-09-12-round14','implementation-2026-09-12-round15').replace("'39-implementation-checkpoint-round13.json'","'41-implementation-checkpoint-round14.json'").replace(oldsha,newsha)
cap=cap.replace('from checkpoint_recipe_round15 import validate_required_runs','from checkpoint_recipe_round15 import CURRENT_CORE_COUNT, validate_required_runs')
cap=cap.replace('    args = parser.parse_args()\n','    args = parser.parse_args()\n    assert CURRENT_CORE_COUNT > 0, "Round15 core count is pending; no checkpoint validation/publication yet"\n')
(stage/'capture_implementation_checkpoint_round15.py').write_text(cap)
recipe=(plan/names[1]).read_text().replace('round14','round15').replace('Round14','Round15').replace('R14','R15').replace('ROUND14','ROUND15').replace('round15_runtime_inputs','round14_runtime_inputs').replace("'39-implementation-checkpoint-round13.json'","'41-implementation-checkpoint-round14.json'").replace(oldsha,newsha).replace('checkpoint39','checkpoint41').replace('synthetic39','synthetic41')
recipe=recipe.replace("BROWSERS = frozenset", "# Pending root's final integrated core count; zero is a synthetic placeholder only.\nCURRENT_CORE_FILES = 26\nCURRENT_CORE_COUNT = 0\nBROWSERS = frozenset",1)
recipe=recipe.replace("['Test Files  21 passed (21)', 'Tests  1059 passed (1059)']", "[f'Test Files  {CURRENT_CORE_FILES} passed ({CURRENT_CORE_FILES})', f'Tests  {CURRENT_CORE_COUNT} passed ({CURRENT_CORE_COUNT})']")
old_tests="'test/saleReturnIncomingSaveProjection.test.ts',\n                                       'test/saleReturnHeaderFloat.test.ts',\n                                       'test/saleReturnNBarCompanions.test.ts'"
new_tests="'test/saleReturnOtherAmountReplay.test.ts',\n                                       'test/saleReturnEffectContext.test.ts',\n                                       'test/saleReturnFinancialEffects.test.ts',\n                                       'test/saleReturnSaveGuards.test.ts',\n                                       'test/saleReturnSaveComposition.test.ts'"
assert old_tests in recipe;recipe=recipe.replace(old_tests,new_tests)
(stage/'checkpoint_recipe_round15.py').write_text(recipe)
test=(plan/names[2]).read_text().replace('round14','round15').replace('ROUND14','ROUND15');(stage/'test_checkpoint_recipe_round15.py').write_text(test)
validator=(plan/'validate_current_review.py').read_text().replace('checkpoint_recipe_round14','checkpoint_recipe_round15').replace("'41-implementation-checkpoint-round14.json'","'43-implementation-checkpoint-round15.json'").replace('implementation-2026-09-12-round14','implementation-2026-09-12-round15').replace("PRIOR_CHECKPOINT = '39-implementation-checkpoint-round13.json'","PRIOR_CHECKPOINT = '41-implementation-checkpoint-round14.json'").replace('PRIOR_CHECKPOINT_SHA256 = '+repr(oldsha),'PRIOR_CHECKPOINT_SHA256 = '+repr(newsha)).replace('actual Round14','actual Round15').replace('This synthetic39 tests only the historical chain; recipe-controls-final tests R14.','This synthetic43 tests only the historical chain; recipe-controls-recorded tests R15.')
needle="    (PRIOR_CHECKPOINT, PRIOR_CHECKPOINT_SHA256, 'priorCheckpointSha256'),\n"
assert validator.count(needle)==1;validator=validator.replace(needle,needle+"    ('39-implementation-checkpoint-round13.json', '"+oldsha+"', 'priorCheckpointSha256'),\n")
(stage/'validate_current_review.py').write_text(validator)
def patch(name,old,new):
 text=''.join(difflib.unified_diff(old.splitlines(True),new.splitlines(True),fromfile='a/parity-plan-2026-09-10/'+name,tofile='b/parity-plan-2026-09-10/'+name))
 return text
(out/'validate_current_review.patch').write_text(patch('validate_current_review.py',(plan/'validate_current_review.py').read_text(),validator))
runner=(plan/'run_check_round15.py').read_text();needle="    'run_check_round15.py', 'capture_implementation_checkpoint_round15.py',\n";assert needle in runner
runner=runner.replace(needle,needle+"    'checkpoint_recipe_round15.py', 'test_checkpoint_recipe_round15.py',\n")
(out/'run_check_round15-seeds.patch').write_text(patch('run_check_round15.py',(plan/'run_check_round15.py').read_text(),runner))
# Exact copies are local unit-test/runtime import dependencies, not adoption changes.
for n in ['round14_runtime_inputs.py','capture_implementation_checkpoint_round12_isolated.py']:(stage/n).write_bytes((plan/n).read_bytes())
print('prepared',len(refs),'baseline pins; active files unchanged')
