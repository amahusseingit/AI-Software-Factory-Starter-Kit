import ast,re,subprocess
from pathlib import Path
import yaml
p=Path('.github/workflows/dotnet-ci.yml')
d=yaml.load(p.read_text(),Loader=yaml.BaseLoader)
shells=0
python_blocks=0
for name,job in d['jobs'].items():
 for step in job['steps']:
  if 'run' not in step:continue
  script=step['run']
  result=subprocess.run(['bash','-n'],input=script,text=True,capture_output=True)
  if result.returncode:raise RuntimeError(name+': '+result.stderr)
  shells+=1
  for match in re.finditer(r"python3 - <<'PY'\n(.*?)\nPY(?:\n|$)",script,re.S):
   ast.parse(match.group(1));python_blocks+=1
print(f'Parsed YAML; checked {shells} shell scripts and {python_blocks} embedded Python blocks; no workflow executed')
