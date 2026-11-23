#!/usr/bin/env python3
# The app's fonts as data the Unity vector renderer can draw text with (Assets/Resources/Fonts/<name>.json):
# each glyph's outline as SVG path data in font units (y up), its advance, the font's vertical metrics, and the
# pair kerning Chrome applies (GPOS 'kern', pair adjustments), for the characters the app's text uses.
#   pip install fonttools; python3 tools/unity/ui/fonts.py
import json, os, sys
from fontTools.ttLib import TTFont
from fontTools.pens.svgPathPen import SVGPathPen

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..', '..'))
OUT = os.path.join(ROOT, 'unity', 'Assets', 'Resources', 'Fonts')
FONTS = {
    'Fredoka_700Bold': 'fredoka/700Bold', 'Fredoka_600SemiBold': 'fredoka/600SemiBold', 'Fredoka_500Medium': 'fredoka/500Medium',
    'Nunito_700Bold': 'nunito/700Bold', 'Nunito_600SemiBold': 'nunito/600SemiBold', 'Nunito_800ExtraBold': 'nunito/800ExtraBold',
    'Nunito_900Black': 'nunito/900Black', 'Nunito_400Regular': 'nunito/400Regular',
    'Baloo2_500Medium': 'baloo-2/500Medium', 'Baloo2_700Bold': 'baloo-2/700Bold', 'Baloo2_800ExtraBold': 'baloo-2/800ExtraBold',
}
# printable ASCII, Latin-1 letters and the punctuation the app writes (· • … – — ’ “ ” × ★ ♥ ← → etc.)
CHARS = [chr(c) for c in range(0x20, 0x7f)] + [chr(c) for c in range(0xa0, 0x180)] + list('·•…–—‘’“”×÷★☆♥←→↑↓✓✔✕✖⏱▶◀⚡✨')

def pair_kerning(font, gids):
    """{(left gid, right gid): x advance adjustment} from GPOS 'kern' pair lookups (formats 1 and 2)."""
    out = {}
    if 'GPOS' not in font: return out
    gpos = font['GPOS'].table
    if not gpos.FeatureList: return out
    lookups = set()
    for fr in gpos.FeatureList.FeatureRecord:
        if fr.FeatureTag == 'kern': lookups.update(fr.Feature.LookupListIndex)
    order = font.getGlyphOrder()
    want = set(gids)
    for li in sorted(lookups):
        lk = gpos.LookupList.Lookup[li]
        for st in lk.SubTable:
            if lk.LookupType == 9: st = st.ExtSubTable
            if getattr(st, 'LookupType', 2) != 2 and lk.LookupType not in (2, 9): continue
            cov = st.Coverage.glyphs
            if st.Format == 1:
                for i, g1 in enumerate(cov):
                    if g1 not in want: continue
                    for pvr in st.PairSet[i].PairValueRecord:
                        if pvr.SecondGlyph not in want: continue
                        v = pvr.Value1.XAdvance if pvr.Value1 is not None and hasattr(pvr.Value1, 'XAdvance') else 0
                        if v and (g1, pvr.SecondGlyph) not in out: out[(g1, pvr.SecondGlyph)] = v
            elif st.Format == 2:
                c1 = st.ClassDef1.classDefs if st.ClassDef1 else {}
                c2 = st.ClassDef2.classDefs if st.ClassDef2 else {}
                for g1 in cov:
                    if g1 not in want: continue
                    rec = st.Class1Record[c1.get(g1, 0)]
                    for g2 in want:
                        v1 = rec.Class2Record[c2.get(g2, 0)].Value1
                        v = getattr(v1, 'XAdvance', 0) if v1 is not None else 0
                        if v and (g1, g2) not in out: out[(g1, g2)] = v
    return out

def export(name, rel):
    path = os.path.join(ROOT, 'node_modules', '@expo-google-fonts', rel, name + '.ttf')
    f = TTFont(path)
    cmap = f.getBestCmap()
    gs = f.getGlyphSet()
    hmtx = f['hmtx']
    glyphs, by_name = {}, {}
    for ch in CHARS:
        g = cmap.get(ord(ch))
        if g is None: continue
        pen = SVGPathPen(gs)
        gs[g].draw(pen)
        glyphs[ch] = {'adv': hmtx[g][0], 'd': pen.getCommands()}
        by_name[g] = ch
    kern = pair_kerning(f, list(by_name))
    hhea, os2 = f['hhea'], f['OS/2']
    data = {
        'name': name,
        'unitsPerEm': f['head'].unitsPerEm,
        # Chrome's line box uses hhea on Linux (or typo metrics with USE_TYPO_METRICS)
        'ascender': hhea.ascent, 'descender': hhea.descent, 'lineGap': hhea.lineGap,
        'typoAscender': os2.sTypoAscender, 'typoDescender': os2.sTypoDescender, 'typoLineGap': os2.sTypoLineGap,
        'useTypo': bool(os2.fsSelection & (1 << 7)),
        'chars': ''.join(glyphs.keys()),
        'glyphs': [glyphs[c] for c in glyphs],
        # "ab": -12 (font units), flattened for JsonUtility: pairs[i] is two chars, kern[i] its adjustment
        'pairs': [by_name[a] + by_name[b] for (a, b) in kern],
        'kern': [kern[k] for k in kern],
    }
    os.makedirs(OUT, exist_ok=True)
    with open(os.path.join(OUT, name + '.json'), 'w') as fh: json.dump(data, fh, separators=(',', ':'))
    return len(glyphs), len(kern)

if __name__ == '__main__':
    for n, r in FONTS.items():
        g, k = export(n, r)
        print(f'{n}: {g} glyphs, {k} kerning pairs')
