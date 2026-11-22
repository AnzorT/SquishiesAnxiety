"""The outline colours of the creatures' border looks, for the live rigs (2026-11-16, the user: the character itself,
e.g. the one in front of the house, should show the look picked in Firestore config/roster, not only its pictures).

webgame/app/rig-look.js draws a look's outline round a live rig; this measures the line in the look pictures
(android/app/src/main/assets/looks/<n>/<key>.webp, tools/looks/encode.py) so the rig's line matches them:
    look 3 (bold ink line)    a dark ink, tinted a little by the creature (look 2, the thin ink line, uses it too)
    look 4 (bold colour line) a dark shade of the creature's own colour
The colour is the middle of the line: the second ring of pixels in from the picture's outer edge (the first is the
edge's anti-aliasing). Measured across all the pictures, the line is ~3 px of 384 in looks 3 and 4 and ~2 px in
look 2, about the same for every creature: rig-look.js WIDTH.
Writes webgame/app/look-lines.js (window.SQ_LOOK_LINES = { key: [look 3 colour, look 4 colour] }).

    python tools/looks/lines.py
"""
import json
import pathlib

import numpy as np
from PIL import Image, ImageFilter

ROOT = pathlib.Path(__file__).resolve().parent.parent.parent
LOOKS = ROOT / 'android' / 'app' / 'src' / 'main' / 'assets' / 'looks'
OUT = ROOT / 'webgame' / 'app' / 'look-lines.js'


def line_colour(path):
    im = Image.open(path).convert('RGBA')
    solid = im.split()[3].point(lambda v: 255 if v > 200 else 0)
    in1 = solid.filter(ImageFilter.MinFilter(3))
    in2 = in1.filter(ImageFilter.MinFilter(3))
    ring = (np.asarray(in1) > 0) & ~(np.asarray(in2) > 0)
    px = np.asarray(im)[..., :3][ring]
    if not len(px):
        return None
    r, g, b = (int(v) for v in np.median(px, axis=0))
    return '#%02x%02x%02x' % (r, g, b)


keys = sorted(p.stem for p in (LOOKS / '3').glob('*.webp'))
lines = {}
for key in keys:
    c3, c4 = line_colour(LOOKS / '3' / f'{key}.webp'), line_colour(LOOKS / '4' / f'{key}.webp')
    if c3 and c4:
        lines[key] = [c3, c4]

OUT.write_text(
    '// Written by tools/looks/lines.py from the look pictures: each creature\'s outline colour in look 3 (bold ink line;\n'
    '// look 2 uses it too) and look 4 (bold colour line), for the live rigs (app/rig-look.js).\n'
    'window.SQ_LOOK_LINES = ' + json.dumps(lines, separators=(',', ':')) + ';\n',
    encoding='utf-8', newline='\n')
print(f'{len(lines)} creatures -> {OUT.relative_to(ROOT)}')
