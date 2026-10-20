import concurrent.futures,hashlib,json,tarfile,urllib.request
from pathlib import Path
tools=Path('/workspace/.factory-tools')
items=[('gitleaks','https://github.com/gitleaks/gitleaks/releases/download/v8.30.1/gitleaks_8.30.1_linux_x64.tar.gz','551f6fc83ea457d62a0d98237cbad105af8d557003051f41f3e7ca7b3f2470eb'),('codeql','https://github.com/github/codeql-action/releases/download/codeql-bundle-v2.27.2/codeql-bundle-linux64.tar.gz','f002864be6dd8d5d7bdb123aaf7291ec8e291012bd9f70b6d2362f730db52aeb')]
def install(item):
 name,url,digest=item
 path=Path('/tmp/fact005-'+name+'.tar.gz')
 hasher=hashlib.sha256()
 with urllib.request.urlopen(url,timeout=60) as src,path.open('wb') as dst:
  while block:=src.read(1024*1024):dst.write(block);hasher.update(block)
 assert hasher.hexdigest()==digest,name+' checksum mismatch'
 out=tools/name;out.mkdir(parents=True,exist_ok=True)
 with tarfile.open(path) as archive:archive.extractall(out,filter='data')
 return {'tool':name,'archive_sha256':digest,'path':str(out),'verified':True,'bytes':path.stat().st_size}
with concurrent.futures.ThreadPoolExecutor(max_workers=2) as pool:
 for result in pool.map(install,items):print(json.dumps(result),flush=True)
