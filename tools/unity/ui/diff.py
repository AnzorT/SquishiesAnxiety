# python3 diff.py a.png b.png out.png -> share of pixels that differ visibly (any channel > 24), and a picture of them
import sys
from PIL import Image, ImageChops
a, b = Image.open(sys.argv[1]).convert('RGB'), Image.open(sys.argv[2]).convert('RGB')
d = ImageChops.difference(a, b)
px = d.load(); w, h = d.size; n = 0
mask = Image.new('L', d.size); mp = mask.load()
for y in range(h):
    for x in range(w):
        if max(px[x, y]) > 24: n += 1; mp[x, y] = 255
print(f'{n} of {w*h} px differ visibly ({100*n/(w*h):.2f} %)')
out = Image.blend(a, Image.new('RGB', a.size, (0, 0, 0)), 0.6); out.paste((255, 0, 60), mask=mask); out.save(sys.argv[3])
