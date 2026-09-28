"""Hash built API/Next inputs; keep runtime bytes separate from source archives."""
from pathlib import Path
import hashlib


def runtime_inputs(root: Path) -> dict[str, str]:
    paths = set()
    for name in ['web/apps/api/dist', 'web/apps/web/.next/server', 'web/apps/web/.next/static']:
        paths.update(p for p in (root / name).rglob('*') if p.is_file())
    next_root = root / 'web/apps/web/.next'
    paths.update(p for p in next_root.glob('*') if p.is_file()
                 and (p.suffix in {'.json', '.js'} or p.name == 'BUILD_ID'))
    result = {}
    for path in sorted(paths):
        assert not path.is_symlink() and path.resolve().is_relative_to(root.resolve()), path
        result[str(path.relative_to(root))] = hashlib.sha256(path.read_bytes()).hexdigest()
    return result
