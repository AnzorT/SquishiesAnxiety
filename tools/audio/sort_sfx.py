"""Squish Sort's sound effects (SQUISH_SORT.md), synthesized with
squishdoku_sfx.py's building blocks: the fridge's doors, its rattle, jumps
and landings, squishies tumbling out, being picked up, snapping home, an
impostor found out, a sneaky swap. (Stars, coins, confetti, the win and the
countdown tick are Squishdoku's own sd_* sounds.)

Writes assets/audio/sort/fs_*.wav (all short) and src/audio/sortFiles.js,
the list src/audio/sfx.js merges into its effects.

    python tools/audio/sort_sfx.py
"""
import pathlib
import sys

import numpy as np
import soundfile as sf

HERE = pathlib.Path(__file__).parent
sys.path.insert(0, str(HERE))
import squishdoku_sfx as sd  # noqa: E402  (its building blocks; importing it renders its sounds, not writes them)
from squishdoku_sfx import (  # noqa: E402
    SR, band, bell, bloop, boing, brass, chord, click, decay, droplet, env, finish, high, low, mix, noise, note, osc,
    reverb, shimmer, squish, sweep, sweep_filter, thump, vibrato, whoosh,
)

ROOT = HERE.parent.parent
OUT = ROOT / 'assets' / 'audio' / 'sort'
rand = np.random.default_rng(11)


def secs(d):
    return np.arange(int(d * SR)) / SR


def clinks(d, n, lo=2200, hi=5200, gain=(0.15, 0.5)):
    """Bottles and jars knocking: short high bells scattered over d."""
    out = np.zeros(int(d * SR))
    for _ in range(n):
        at = rand.uniform(0, d * 0.85)
        b = bell(rand.uniform(lo, hi), 0.15, ratio=2.76, index=1.2, tau=0.035) * rand.uniform(*gain)
        i = int(at * SR)
        out[i:i + len(b)] += b[: len(out) - i]
    return out


def knocks(d, n, lo=500, hi=1400):
    """Plastic and wood knocks."""
    out = np.zeros(int(d * SR))
    for _ in range(n):
        at = rand.uniform(0, d * 0.9)
        c = band(noise(0.03), lo, hi) * decay(int(0.03 * SR), 0.008) * rand.uniform(0.3, 0.9)
        i = int(at * SR)
        out[i:i + len(c)] += c[: len(out) - i]
    return out


def rumble(d, f0=70, f1=220, trem=13):
    x = band(noise(d), f0, f1, order=2)
    return x * (0.6 + 0.4 * np.sin(2 * np.pi * trem * secs(d))) * env(int(d * SR), a=0.04, d=d, s=0.8, r=0.15)


S = {}

# a squishy popping onto its shelf at the deal
S['fs_pop'] = (mix([(droplet(420, 1250, 0.07), 0, 1.0), (squish(0.08, 2400, 700), 0.01, 0.35), (click(0.006, 5200), 0, 0.2)]), 0.45)

# the doors: shut with a soft rubber "thup" and bottles clinking; open with the
# seal letting go, a cold hum and the light coming on
_seal = sweep_filter(noise(0.09), 2200, 300, 'low') * decay(int(0.09 * SR), 0.025, a=0.003)
S['fs_doorClose'] = (reverb(mix([(thump(62, 0.32, 2.4), 0, 1.0), (_seal, 0, 0.8), (click(0.02, 1200), 0, 0.4), (clinks(0.35, 5, 2600, 4800, (0.1, 0.3)), 0.04, 0.6)]), 0.5, 0.15), 0.8)
_suck = osc(sweep(140, 900, 0.07)) * decay(int(0.07 * SR), 0.03, a=0.002)
_hiss = high(noise(0.3), 3500) * env(int(0.3 * SR), a=0.01, d=0.12, s=0.0, r=0.05)
_hum = (osc(60, 0.7) + 0.5 * osc(120, 0.7) + 0.2 * osc(180, 0.7)) * env(int(0.7 * SR), a=0.25, d=0.6, s=0.6, r=0.2) * 0.35
S['fs_doorOpen'] = (reverb(mix([(_suck, 0, 0.9), (_hiss, 0.02, 0.35), (_hum, 0.05, 0.8), (bell(note('E7'), 0.35, ratio=2.0, index=0.8, tau=0.1), 0.18, 0.35), (shimmer(0.45, 5000, 10000, 30), 0.15, 0.25)]), 0.6, 0.18), 0.72)

# the shake: rattling glass, knocking boxes and a low rumble
S['fs_rattle'] = (mix([(rumble(1.05), 0, 0.9), (clinks(1.05, 34), 0, 0.9), (knocks(1.05, 22), 0, 0.7)]), 0.78)

# up it goes, and lands with a thud and everything inside jumping
S['fs_jump'] = (mix([(boing(220, 0.3), 0, 0.9), (whoosh(0.22, 400, 2400, False), 0, 0.4)]), 0.6)
S['fs_land'] = (reverb(mix([(thump(48, 0.45, 3.0), 0, 1.0), (low(noise(0.12), 900) * decay(int(0.12 * SR), 0.03), 0, 0.7), (clinks(0.3, 9, 2400, 5200, (0.15, 0.45)), 0.01, 0.7), (knocks(0.2, 6), 0.01, 0.5)]), 0.5, 0.15), 0.9)

# squishies tumbling out of the fridge into the tray, one after another
_tum = mix([(bloop(rand.uniform(380, 640), rand.uniform(120, 200), 0.12, 0.05), 0.075 * i + rand.uniform(0, 0.02), 0.7) for i in range(9)] + [(squish(0.1, 2000, 500), 0.075 * i + 0.01, 0.25) for i in range(0, 9, 2)] + [(thump(110, 0.08), 0.075 * i, 0.25) for i in range(0, 9, 3)])
S['fs_tumble'] = (_tum, 0.62)

# picking one up, and putting it back down in the tray
S['fs_pick'] = (mix([(droplet(500, 1500, 0.06), 0, 1.0), (band(osc(sweep(900, 1400, 0.07), kind='saw'), 800, 3000) * env(int(0.07 * SR), a=0.005, d=0.05, s=0.5, r=0.02), 0.01, 0.18)]), 0.4)
S['fs_drop'] = (mix([(bloop(380, 140, 0.11, 0.045), 0, 1.0), (squish(0.07, 1600, 500), 0, 0.3)]), 0.45)

# home: a squelchy snap and a rising chime
_chime = mix([(bell(note('E6'), 0.45, tau=0.15), 0, 0.6), (bell(note('G6'), 0.45, tau=0.15), 0.05, 0.55), (bell(note('C7'), 0.55, tau=0.18), 0.1, 0.6), (shimmer(0.3, 4500, 9500, 35), 0.08, 0.35)])
S['fs_snap'] = (reverb(mix([(squish(0.1, 2200, 500), 0, 0.7), (bloop(700, 260, 0.08, 0.03), 0, 0.6), (click(0.01, 2600), 0, 0.4), (_chime, 0.04, 0.6)]), 0.6, 0.2), 0.75)

# wrong spot: the buzzer and a boing back to the tray
S['fs_wrong'] = (mix([(sd._buzz, 0, 0.8), (boing(260, 0.26), 0.2, 0.7), (sd.grumble(0.18), 0.12, 0.45)]), 0.72)

# an impostor found out: dun-dun, a poof and away
_dun = mix([(brass(note('D3'), 0.16), 0, 0.9), (brass(note('A2'), 0.32), 0.18, 1.0)])
_poof = sweep_filter(noise(0.22), 5000, 400, 'low') * decay(int(0.22 * SR), 0.06, a=0.004)
S['fs_impostor'] = (reverb(mix([(_dun, 0, 1.0), (thump(70, 0.25), 0.18, 0.6), (_poof, 0.42, 0.9), (whoosh(0.3, 600, 5000, False), 0.45, 0.5)]), 0.6, 0.18), 0.82)

# the sneaky swap: two hops past each other
S['fs_swap'] = (mix([(boing(340, 0.24), 0, 0.8), (boing(450, 0.24), 0.12, 0.8), (whoosh(0.4, 500, 3500), 0.02, 0.45), (droplet(600, 300, 0.06), 0.38, 0.4)]), 0.6)

# a heart lost: a crack and a falling whistle
_crack = sum(click(0.012, f) * g for f, g in ((3800, 1.0), (2400, 0.7), (5200, 0.5)))
S['fs_heart'] = (mix([(_crack, 0, 0.9), (click(0.015, 3000), 0.04, 0.6), (osc(sweep(1100, 380, 0.3), kind='tri') * env(int(0.3 * SR), a=0.005, d=0.25, s=0.5, r=0.05), 0.03, 0.55)]), 0.6)

# REMEMBER!: a magic sweep up as the peek starts
_arp = mix([(bell(note(n), 0.45, tau=0.16, index=1.6), 0.06 * i, 0.55) for i, n in enumerate(['C6', 'E6', 'G6', 'B6', 'D7'])])
S['fs_peek'] = (reverb(mix([(_arp, 0, 1.0), (shimmer(0.5, 5000, 10000, 45), 0.1, 0.35), (whoosh(0.3, 1200, 7000, False), 0, 0.25)]), 0.8, 0.22), 0.6)

# some got mixed up: a wobbly "huh?"
_huh = osc(vibrato(1, 0.42, 9, 0.0) * np.concatenate([sweep(420, 380, 0.16), sweep(380, 640, 0.26)]), kind='tri')
_huh = _huh * env(len(_huh), a=0.01, d=0.5, s=0.8, r=0.06) * (1 + 0.15 * np.sin(2 * np.pi * 11 * secs(0.42)))
S['fs_mixed'] = (mix([(_huh, 0, 1.0), (boing(500, 0.2), 0.3, 0.3)]), 0.55)


def main():
    OUT.mkdir(parents=True, exist_ok=True)
    for old in OUT.glob('*.wav'):
        old.unlink()
    total = 0
    for name, (data, peak) in S.items():
        x = finish(np.asarray(data, dtype=np.float64), peak, max_s=1.2)
        assert np.isfinite(x).all(), name
        dest = OUT / f'{name}.wav'
        sf.write(dest, x.astype(np.float32), SR, subtype='PCM_16')
        size = dest.stat().st_size
        total += size
        print(f'{dest.relative_to(ROOT)}  {len(x) / SR:5.2f}s  {size / 1024:6.1f} KB')
    lines = [f"  {n}: require('../../assets/audio/sort/{n}.wav')," for n in sorted(S)]
    header = ["// Generated by tools/audio/sort_sfx.py — Squish Sort's sound effects.", "// Don't edit by hand.", '', 'export default {']
    (ROOT / 'src' / 'audio' / 'sortFiles.js').write_text('\n'.join(header + lines + ['};', '']), encoding='utf8')
    print(f'{len(S)} sounds, {total / 1024:.0f} KB')


if __name__ == '__main__':
    main()
