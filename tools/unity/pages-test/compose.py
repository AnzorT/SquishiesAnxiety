# python3 compose.py draws.json <out dir>   (run by Program.cs)
# Draws each scene's draw list (the Unity page's pictures and drawn texts, where its model puts them) over the app's
# menu, as the GPU will: premultiplied alpha, bilinear sampling, opacity, clip boxes, and layers (the page, the loading
# screen) drawn on their own first. Pictures that land on whole pixels at scale 1 are copied as they are. Then compares
# with the app's screenshot: a pixel differs visibly when a channel is more than 24 levels off (the rule of
# tools/unity/park-test and stack-test).
import json, os, sys, math
import numpy as np
from PIL import Image

spec = json.load(open(sys.argv[1]))
out = sys.argv[2]
cache = {}


def load(path):
    if path not in cache:
        f = np.asarray(Image.open(path).convert('RGBA')).astype(np.float32) / 255
        f[..., :3] *= f[..., 3:4]
        cache[path] = f
    return cache[path]


def over(acc, src, x, y, clip=None):
    """premultiplied src (h, w, 4) over acc at integer (x, y), optionally only inside clip (x0, y0, x1, y1) px"""
    H, W = acc.shape[:2]
    sh, sw = src.shape[:2]
    x0, y0, x1, y1 = max(0, x), max(0, y), min(W, x + sw), min(H, y + sh)
    if clip:
        cx0, cy0, cx1, cy1 = [int(math.ceil(v - 0.5)) for v in clip]
        x0, y0, x1, y1 = max(x0, cx0), max(y0, cy0), min(x1, cx1), min(y1, cy1)
    if x1 <= x0 or y1 <= y0:
        return
    s = src[y0 - y:y1 - y, x0 - x:x1 - x]
    a = acc[y0:y1, x0:x1]
    a[:] = s + a * (1 - s[..., 3:4])


def draw(items, acc):
    H, W = acc.shape[:2]
    for d in items:
        if d.get('layer') is not None:
            src = draw(d['layer'], np.zeros((d['h'], d['w'], 4), np.float32))
        elif d.get('file'):
            src = load(d['file'])
        else:
            src = load(os.path.join(spec_res, d['res'] + ('.jpg.bytes' if d.get('jpeg') else '.png.bytes')))
        a, b, c, dd, e, f = d['m']
        u0, v0, u1, v1 = d['uv']
        clip = d.get('clip')
        if (u0, v0, u1, v1) != (0, 0, 1, 1):
            sh, sw = src.shape[:2]
            # the GPU draws the quad of exactly that part: crop to the whole pixels round it, and clip to the quad
            if abs(b) < 1e-12 and abs(c) < 1e-12:
                qx0, qx1 = sorted((a * u0 * sw + e, a * u1 * sw + e))
                qy0, qy1 = sorted((dd * v0 * sh + f, dd * v1 * sh + f))
                q = (qx0, qy0, qx1, qy1)
                clip = q if not clip else (max(clip[0], q[0]), max(clip[1], q[1]), min(clip[2], q[2]), min(clip[3], q[3]))
            # (a pixel more each side: bilinear sampling at the part's edge reads its neighbours, as the GPU does)
            x0, x1 = max(0, int(math.floor(u0 * sw)) - 1), min(sw, int(math.ceil(u1 * sw)) + 1)
            y0, y1 = max(0, int(math.floor(v0 * sh)) - 1), min(sh, int(math.ceil(v1 * sh)) + 1)
            if x1 <= x0 or y1 <= y0:
                continue
            src = src[y0:y1, x0:x1]
            e, f = a * x0 + c * y0 + e, b * x0 + dd * y0 + f
        op = d['opacity']
        if op <= 0:
            continue
        if abs(a - 1) < 1e-9 and abs(dd - 1) < 1e-9 and abs(b) < 1e-12 and abs(c) < 1e-12 and abs(e - round(e)) < 1e-6 and abs(f - round(f)) < 1e-6:
            s = src if op == 1 else src * op
            over(acc, s, int(round(e)), int(round(f)), clip)
            continue
        sh, sw = src.shape[:2]
        pts = [(a * x + c * y + e, b * x + dd * y + f) for x, y in ((0, 0), (sw, 0), (sw, sh), (0, sh))]
        bx0, by0 = max(0, int(math.floor(min(p[0] for p in pts)))), max(0, int(math.floor(min(p[1] for p in pts))))
        bx1, by1 = min(W, int(math.ceil(max(p[0] for p in pts)))), min(H, int(math.ceil(max(p[1] for p in pts))))
        if bx1 <= bx0 or by1 <= by0:
            continue
        det = a * dd - b * c
        ia, ib, ic, id_ = dd / det, -b / det, -c / det, a / det
        ie, if_ = -(ia * e + ic * f), -(ib * e + id_ * f)
        # output (x + bx0, y + by0) -> input; Pillow samples at pixel centres
        A, B, C = ia, ic, ia * bx0 + ic * by0 + ie
        D, E, F = ib, id_, ib * bx0 + id_ * by0 + if_
        o = np.zeros((by1 - by0, bx1 - bx0, 4), np.float32)
        for ch in range(4):
            im = Image.fromarray(np.ascontiguousarray(src[..., ch]), mode='F')
            o[..., ch] = np.asarray(im.transform((bx1 - bx0, by1 - by0), Image.AFFINE, (A, B, C, D, E, F), resample=Image.BILINEAR))
        if op != 1:
            o *= op
        over(acc, o, bx0, by0, clip)
    return acc


shots = spec['shots']
for sc in spec['scenes']:
    spec_res = sc['res']
    if sc['plate']:
        plate = np.asarray(Image.open(os.path.join(shots, sc['plate'])).convert('RGB')).astype(np.float32) / 255
    else:
        plate = np.full((int(sc['size'][1]), int(sc['size'][0]), 3), 0.2, np.float32)
    H, W = plate.shape[:2]
    acc = np.concatenate([plate, np.ones((H, W, 1), np.float32)], 2)
    got = draw(sc['draws'], acc)[..., :3]
    img = (np.clip(got, 0, 1) * 255 + 0.5).astype(np.uint8)
    Image.fromarray(img).save(os.path.join(out, sc['name'] + '.png'))
    if not sc['reference']:
        print(f"{sc['name']:>16}: {os.path.join(out, sc['name'] + '.png')}")
        continue
    ref = np.asarray(Image.open(os.path.join(shots, sc['reference'])).convert('RGB')).astype(np.int16)
    d = np.abs(ref - img.astype(np.int16)).max(2)
    vis = d > 24
    n = int(vis.sum())
    dimg = np.where(vis[..., None], np.array([255, 0, 60], np.uint8), (img // 3 + 128).astype(np.uint8))
    Image.fromarray(dimg).save(os.path.join(out, sc['name'] + '-diff.png'))
    print(f"{sc['name']:>16}: {n:7d} of {W * H} px differ visibly ({100 * n / (W * H):.3f} %), mean difference {np.abs(ref - img).mean():.2f} levels")
