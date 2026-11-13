"""The Crib's room-switch flash as two pictures (src/crib/Hud.js RoomFlash):
a radial white -> lavender -> sky blue glow, stretched over the screen, and a
22 dp tile of the white dots at its corners, repeated. They were an SVG, which
Android draws in software on the UI thread: full-screen, that held the Crib's
opening frame.

  python tools/crib-art/flash.py
"""
import os
from PIL import Image, ImageDraw

OUT = os.path.join(os.path.dirname(__file__), '..', '..', 'assets', 'crib')
STOPS = [(0.0, (0xff, 0xff, 0xff)), (0.55, (0xe6, 0xdc, 0xff)), (1.0, (0x8f, 0xd0, 0xff))]


def color_at(t):
    t = min(1.0, t)
    for (a, ca), (b, cb) in zip(STOPS, STOPS[1:]):
        if t <= b:
            k = (t - a) / (b - a)
            return tuple(round(x + (y - x) * k) for x, y in zip(ca, cb))
    return STOPS[-1][1]


def glow(size=160):
    # the SVG's r="71%" of the box, centred: stretched to the screen it's the
    # same ellipse
    img = Image.new('RGB', (size, size))
    px = img.load()
    for y in range(size):
        for x in range(size):
            dx = (x + 0.5) / size - 0.5
            dy = (y + 0.5) / size - 0.5
            px[x, y] = color_at((dx * dx + dy * dy) ** 0.5 / 0.71)
    img.save(os.path.join(OUT, 'flash-glow.png'))


def dots(scale):
    # a dot of r 1.5 at every corner of a 22 x 22 cell (quarter dots here),
    # drawn 4x and scaled down for smooth edges
    s, k = 22 * scale, 4
    big = Image.new('RGBA', (s * k, s * k), (255, 255, 255, 0))
    d = ImageDraw.Draw(big)
    r = 1.5 * scale * k
    for cx in (0, s * k):
        for cy in (0, s * k):
            d.ellipse([cx - r, cy - r, cx + r, cy + r], fill=(255, 255, 255, 230))
    name = 'flash-dots.png' if scale == 1 else f'flash-dots@{scale}x.png'
    big.resize((s, s), Image.LANCZOS).save(os.path.join(OUT, name))


if __name__ == '__main__':
    glow()
    for sc in (1, 2, 3):
        dots(sc)
