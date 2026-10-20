import argparse,datetime,hashlib,json,os,subprocess,sys
from pathlib import Path
p=argparse.ArgumentParser()
p.add_argument('check')
p.add_argument('--cwd',default='/workspace/factory-dotnet10/runtime/dotnet')
p.add_argument('command',nargs=argparse.REMAINDER)
a=p.parse_args()
command=a.command
if command and command[0]=='--':command=command[1:]
assert command
root=Path('/workspace/factory-dotnet10');ev=root/'evidence/fact-005';raw=ev/'raw';raw.mkdir(parents=True,exist_ok=True)
now=lambda:datetime.datetime.now(datetime.timezone.utc).isoformat()
sha=lambda b:hashlib.sha256(b).hexdigest()
paths=subprocess.check_output(['git','ls-files','--cached','--others','--exclude-standard','--','runtime/dotnet','.github/workflows/dotnet-ci.yml'],cwd=root,text=True).splitlines()
files=[{'path':s,'sha256':sha((root/s).read_bytes())} for s in sorted(set(paths)) if (root/s).is_file()]
source_digest=sha(json.dumps(files,sort_keys=True,separators=(',',':')).encode())
existing=list(ev.glob(a.check+'-*.json'));run_id=a.check+'-'+str(len(existing)+1).zfill(2)
log=raw/(run_id+'.txt');start=now()
env=os.environ.copy();env.update({'DOTNET_CLI_HOME':'/workspace/.factory-tools/dotnet-home','NUGET_PACKAGES':'/workspace/.factory-tools/nuget','DOTNET_CLI_TELEMETRY_OPTOUT':'1','DOTNET_NOLOGO':'1','TMPDIR':'/workspace/.factory-tools/tmp'})
env['PATH']='/workspace/.factory-tools/dotnet:/workspace/.factory-tools/gitleaks:/workspace/.factory-tools/codeql/codeql:'+env.get('PATH','')
with log.open('wb') as output:
 process=subprocess.run(command,cwd=a.cwd,env=env,stdout=output,stderr=subprocess.STDOUT)
end=now();body=log.read_bytes()
record={'task_id':'fact-005','run_id':run_id,'actor':'Codex root developer self-check','independent_reviewer':None,'repository':'amahusseingit/AI-Software-Factory-Starter-Kit','branch':'task/fact-005-integrate-dotnet-runtime','approved_base':'7ed5858e44bafbabf083022397ef97a4bb827dd2','git_head_before_check':subprocess.check_output(['git','rev-parse','HEAD'],cwd=root,text=True).strip(),'source_artifact_set_digest':source_digest,'source_files':files,'command':command,'cwd':a.cwd,'started_utc':start,'ended_utc':end,'exit_code':process.returncode,'command_state':'PASS' if process.returncode==0 else 'FAILED','interpretation':'Command exit only; semantic results must be separately inspected. Not independent acceptance.','raw_output':str(log.relative_to(root)),'raw_sha256':sha(body),'environment_id':'ccarenv_b64_Y2NhcmVudl80MDZiMzllN2RhMzQ4MTkxYjYwZGYzNzlhNWNlOTkzYw'}
(ev/(run_id+'.json')).write_text(json.dumps(record,indent=2)+'\n')
print(json.dumps({'run_id':run_id,'exit_code':process.returncode,'source_digest':source_digest,'raw_output':str(log),'tail':body.decode(errors='replace')[-2200:]}),flush=True)
sys.exit(process.returncode)
