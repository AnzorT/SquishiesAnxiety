"""Checks render.mjs's room layers: composites under + base + over for each
room and phase and compares it with the room shot whole (out/*-full.png).
Prints the mean and worst pixel difference; writes out/*-diff.png where a
room differs by more than a few levels.

    python tools/crib-art/check.py
"""
import json
import pathlib

from PIL import Image, ImageChops

HERE = pathlib.Path(__file__).parent
ROOMS = HERE.parent.parent / 'assets' / 'crib' / 'rooms'
OUT = HERE / 'out'

manifest = json.loads((OUT / 'rooms.json').read_text())
bad = 0
for room, m in manifest.items():
    phases = sorted(set(m['under']) | set(m['over'])) or ['day']
    for phase in phases:
        full_path = OUT / f'{room}-{phase}-full.png'
        if not full_path.exists():
            continue
        full = Image.open(full_path).convert('RGBA')
        comp = Image.new('RGBA', full.size, (0, 0, 0, 0))
        for f in [m['under'].get(phase), m['base'], m['over'].get(phase)]:
            if f:
                comp = Image.alpha_composite(comp, Image.open(ROOMS / f).convert('RGBA').resize(full.size))
        diff = ImageChops.difference(comp.convert('RGB'), full.convert('RGB')).convert('L')
        hist = diff.histogram()
        n = sum(hist)
        mean = sum(i * c for i, c in enumerate(hist)) / n
        over = sum(hist[24:]) / n
        flag = ''
        if mean > 2 or over > 0.002:
            flag = '  <-- differs'
            bad += 1
            diff.point(lambda v: 255 if v > 24 else 0).save(OUT / f'{room}-{phase}-diff.png')
        print(f'{room:8} {phase:8} mean {mean:5.2f}  >24: {over * 100:5.2f}%{flag}')
print('all layers match' if not bad else f'{bad} differ')
