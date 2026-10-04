"""Builds every app icon from the user's app-icon-1024.png (repo root).

The source art may come with its own rounded corners (transparent outside a
squircle). Launchers and the Play Store apply their own mask, so the square
versions get those corners filled by smearing the nearby edge colours outward.

Writes:
  assets/icons/app_icon.png             1024 square, no alpha (app.json icon)
  assets/icons/app_icon_foreground.png  1024 adaptive foreground layer
  android/app/src/main/res/mipmap-*/ic_launcher{,_round,_foreground}.png
and prints the background colour for iconBackground / adaptiveIcon.

Run from the repo root: python tools/icon/makeIcons.py
"""
import numpy as np
from PIL import Image, ImageDraw

SRC = 'app-icon-1024.png'
RES = 'android/app/src/main/res'
DENSITIES = {'mdpi': 108, 'hdpi': 162, 'xhdpi': 216, 'xxhdpi': 324, 'xxxhdpi': 432}
# Launchers show the central 72 of the 108 dp layer; the art fills that area
# with a little bleed so mask edges never show the background.
ART_SCALE = 76 / 108


def box(a, r, axis):
    pad = [(0, 0)] * a.ndim
    pad[axis] = (r + 1, r)
    c = np.cumsum(np.pad(a, pad), axis=axis)
    n = a.shape[axis]
    hi = np.take(c, np.arange(2 * r + 1, 2 * r + 1 + n), axis=axis)
    lo = np.take(c, np.arange(0, n), axis=axis)
    return (hi - lo) / (2 * r + 1)


def blur(a, radius):
    """Three box passes per axis, close to a Gaussian of this radius."""
    r = max(1, radius // 2)
    for axis in (0, 1):
        for _ in range(3):
            a = box(a, r, axis)
    return a


def fill_corners(im):
    """Replace transparent pixels with colours spread from the opaque edge."""
    a = np.asarray(im, dtype=np.float64)
    # Only fully opaque pixels count as art: the corners can carry a faint
    # black drop shadow that would otherwise darken the fill.
    alpha = (a[..., 3] >= 250).astype(np.float64)
    rgb = a[..., :3]
    out = rgb * alpha[..., None]
    covered = alpha.copy()
    # Normalised (premultiplied) blurs at growing radii; each one fills
    # whatever the smaller ones left uncovered.
    for radius in (6, 20, 60, 180):
        w = blur(alpha, radius)
        spread = np.stack([blur(rgb[..., c] * alpha, radius) for c in range(3)], -1)
        spread /= np.maximum(w, 1e-6)[..., None]
        take = (1 - covered) * np.clip(w * 4, 0, 1)
        out += spread * take[..., None]
        covered += take
    out += np.array(edge_colour(im), dtype=np.float64) * (1 - covered)[..., None]
    rgba = np.dstack([np.clip(out, 0, 255), np.full(alpha.shape, 255.0)])
    return Image.fromarray(rgba.round().astype(np.uint8), 'RGBA')


def edge_colour(im):
    """Mean background colour of the opaque ring just inside the art's border
    (bluish pixels only, so characters touching the edge don't tint it)."""
    px = im.load()
    w, h = im.size
    total, n = [0, 0, 0], 0
    for i in range(0, w, 4):
        for x, y in ((i, 12), (i, h - 13), (12, i), (w - 13, i)):
            c = px[x, y]
            if c[3] == 255 and c[2] > c[0] + 20 and c[2] > c[1] + 40:
                total = [t + v for t, v in zip(total, c)]
                n += 1
    return tuple(t // n for t in total)


def circle_mask(size):
    scale = 4
    m = Image.new('L', (size * scale, size * scale), 0)
    ImageDraw.Draw(m).ellipse((0, 0, size * scale - 1, size * scale - 1), fill=255)
    return m.resize((size, size), Image.LANCZOS)


def main():
    src = Image.open(SRC).convert('RGBA')
    square = fill_corners(src)
    bg = edge_colour(src)

    square.convert('RGB').resize((1024, 1024), Image.LANCZOS).save('assets/icons/app_icon.png')

    def foreground(size):
        art = round(size * ART_SCALE)
        layer = Image.new('RGBA', (size, size), (0, 0, 0, 0))
        off = (size - art) // 2
        layer.alpha_composite(square.resize((art, art), Image.LANCZOS), (off, off))
        return layer

    foreground(1024).save('assets/icons/app_icon_foreground.png')

    for dens, size in DENSITIES.items():
        d = f'{RES}/mipmap-{dens}'
        # Legacy (pre-adaptive) icon keeps the art's own rounded shape.
        src.resize((size, size), Image.LANCZOS).save(f'{d}/ic_launcher.png')
        rnd = square.resize((size, size), Image.LANCZOS)
        rnd.putalpha(circle_mask(size))
        rnd.save(f'{d}/ic_launcher_round.png')
        foreground(size).save(f'{d}/ic_launcher_foreground.png')

    print('background #%02X%02X%02X' % bg[:3])


if __name__ == '__main__':
    main()
