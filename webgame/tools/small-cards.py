"""Small copies of the creature cards' pictures, for the menu's Characters row and its loading screen's deal, where a
card is 56-92 CSS px wide (158-260 px on a 2.8x phone). The originals are 3-10x that: a frame 600 x 894, a background
400 x 400, a name 760 x 196, a look 384 x 384. On the Galaxy A16 the first open of Characters after a launch decoded and
uploaded ~70 of them at full size (~1 s of the WebView's GPU thread, every frame blocked meanwhile). (PERF 2026-11-20)

    python -m pip install --user pillow   # once
    node webgame/build.mjs                 # the cards come from the prototype's export/cards4 (copied by the build)
    python webgame/tools/small-cards.py

Writes webgame/app/sm/cards4/{frame-*,bg-*,names/*}.webp (shipped by the build as app/sm/...) and
android/app/src/main/assets/looks-sm/<n>/<key>.webp (next to looks/). app/menu.js uses them for those cards only, and
falls back to the original if one is missing.
"""
import pathlib

from PIL import Image

ROOT = pathlib.Path(__file__).resolve().parent.parent.parent
ASSETS = ROOT / 'android' / 'app' / 'src' / 'main' / 'assets'
CARDS = ASSETS / 'webgame' / 'export' / 'cards4'
OUT_CARDS = ROOT / 'webgame' / 'app' / 'sm' / 'cards4'
LOOKS = ASSETS / 'looks'
OUT_LOOKS = ASSETS / 'looks-sm'

# width each kind is cut to: the loading screen's dealt card (92 CSS px) at up to 3.3x, with a little to spare
WIDTH = {'frame': 340, 'bg': 220, 'names': 240, 'look': 200}


def shrink(src, dst, width):
    im = Image.open(src)
    im.load()
    if im.width <= width:
        out = im
    else:
        out = im.resize((width, round(im.height * width / im.width)), Image.LANCZOS)
    dst.parent.mkdir(parents=True, exist_ok=True)
    out.save(dst, 'WEBP', quality=90, method=6)
    return dst.stat().st_size


if not CARDS.is_dir():
    raise SystemExit('no ' + str(CARDS) + ': run node webgame/build.mjs first')
total = n = 0
for f in sorted(CARDS.glob('frame-*.webp')):
    total += shrink(f, OUT_CARDS / f.name, WIDTH['frame']); n += 1
for f in sorted(CARDS.glob('bg-*.webp')):
    total += shrink(f, OUT_CARDS / f.name, WIDTH['bg']); n += 1
for f in sorted((CARDS / 'names').glob('*.webp')):
    total += shrink(f, OUT_CARDS / 'names' / f.name, WIDTH['names']); n += 1
for f in sorted(LOOKS.glob('*/*.webp')):
    total += shrink(f, OUT_LOOKS / f.parent.name / f.name, WIDTH['look']); n += 1
print(n, 'pictures,', round(total / 1024), 'KB')
