# python3 compose.py draws.json <out dir>   (run by Program.cs)
# Draws each scene's list (the Unity carousel's pictures, where ParkModel puts them) over the app's park without the
# carousel, as the GPU will: premultiplied alpha, bilinear sampling, opacity, brightness, masks, and each card drawn
# into its own layer first. Pictures that land on whole pixels at scale 1 are copied as they are. Then compares with
# the app's screenshot: a pixel differs visibly when a channel is more than 24 levels off (the same rule as
# tools/unity/stack-test and ui/diff.py).
import json, os, sys
import numpy as np
from PIL import Image

spec = json.load(open(sys.argv[1]))
out = sys.argv[2]
W, H = int(spec['screen'][0]), int(spec['screen'][1])
cache = {}


def pic(res):
    if res not in cache:
        f = np.asarray(Image.open(os.path.join(spec['res'], res + '.png')).convert('RGBA')).astype(np.float32) / 255
        f[..., :3] *= f[..., 3:4]
        cache[res] = f
    return cache[res]


def place(src, m, w, h):
    """premultiplied picture `src` mapped by m (x' = a x + c y + e, y' = b x + d y + f) onto a w x h canvas"""
    a, b, c, d, e, f = m
    o = np.zeros((h, w, 4), np.float32)
    if abs(a - 1) < 1e-9 and abs(d - 1) < 1e-9 and abs(b) < 1e-12 and abs(c) < 1e-12 and abs(e - round(e)) < 1e-6 and abs(f - round(f)) < 1e-6:
        x, y = int(round(e)), int(round(f))
        sh, sw = src.shape[:2]
        x0, y0, x1, y1 = max(0, x), max(0, y), min(w, x + sw), min(h, y + sh)
        if x1 > x0 and y1 > y0:
            o[y0:y1, x0:x1] = src[y0 - y:y1 - y, x0 - x:x1 - x]
        return o
    det = a * d - b * c
    ia, ib, ic, id_ = d / det, -b / det, -c / det, a / det
    ie, if_ = -(ia * e + ic * f), -(ib * e + id_ * f)
    # Pillow: output (x, y) -> input (A x + B y + C, D x + E y + F); each channel resampled as is (premultiplied)
    for ch in range(4):
        im = Image.fromarray(src[..., ch], mode='F')
        o[..., ch] = np.asarray(im.transform((w, h), Image.AFFINE, (ia, ic, ie, ib, id_, if_), resample=Image.BILINEAR))
    return o


def draw(draws, acc):
    h, w = acc.shape[:2]
    for dr in draws:
        if dr['res'] == 'card':
            layer = draw(dr['children'], np.zeros((dr['h'], dr['w'], 4), np.float32))
            src = layer
        else:
            src = pic(dr['res'])
        m = dr['m']
        u0, v0, u1, v1 = dr['uv']
        if (u0, v0, u1, v1) != (0, 0, 1, 1):
            sh, sw = src.shape[:2]
            x0, x1 = int(np.floor(u0 * sw)), int(np.ceil(u1 * sw))
            y0, y1 = int(np.floor(v0 * sh)), int(np.ceil(v1 * sh))
            src = src[y0:y1, x0:x1]
            a, b, c, d, e, f = m
            m = [a, b, c, d, a * x0 + c * y0 + e, b * x0 + d * y0 + f]
        s = place(src, m, w, h)
        if dr.get('mask'):
            s *= place(pic(dr['mask']), dr['maskM'], w, h)[..., 3:4]
        br = dr['bright']
        if br != 1:
            s[..., :3] = np.minimum(s[..., :3] * br, s[..., 3:4])
        s *= dr['opacity']
        acc[:] = s + acc * (1 - s[..., 3:4])
    return acc


plate = None
if spec['plate']:
    plate = np.asarray(Image.open(os.path.join(spec['shots'], spec['plate'])).convert('RGB')).astype(np.float32) / 255
for sc in spec['scenes']:
    base = plate if plate is not None else np.full((H, W, 3), 0.35, np.float32)
    acc = np.concatenate([base, np.ones((H, W, 1), np.float32)], 2)
    got = draw(sc['draws'], acc)[..., :3]
    img = (np.clip(got, 0, 1) * 255 + 0.5).astype(np.uint8)
    Image.fromarray(img).save(os.path.join(out, sc['name'] + '.png'))
    if not sc['reference']:
        print(f"{sc['name']}: {os.path.join(out, sc['name'] + '.png')}")
        continue
    ref = np.asarray(Image.open(os.path.join(spec['shots'], sc['reference'])).convert('RGB')).astype(np.int16)
    d = np.abs(ref - img.astype(np.int16)).max(2)
    vis = d > 24
    n = int(vis.sum())
    dimg = np.where(vis[..., None], np.array([255, 0, 60], np.uint8), (img // 3 + 128).astype(np.uint8))
    Image.fromarray(dimg).save(os.path.join(out, sc['name'] + '-diff.png'))
    print(f"{sc['name']:>18}: {n:7d} of {W * H} px differ visibly ({100 * n / (W * H):.3f} %), mean difference {np.abs(ref - img).mean():.2f} levels")
