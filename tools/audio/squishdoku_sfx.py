"""Squishdoku's sound effects (SQUISHDOKU.md), synthesized from scratch: every
tap, mark, creature, timer moment, score creature and Blitz beat has its own.

Writes assets/audio/squishdoku/sd_*: 16-bit mono WAV up to SHORT_S (they
replay fastest, see encode.py), Ogg Vorbis beyond (rare, long ones), and src/audio/squishdokuFiles.js, the list
src/audio/sfx.js merges into its effects. Kept out of assets/audio/sfx,
which encode.py clears.

    python -m pip install --user soundfile numpy scipy   # once
    python tools/audio/squishdoku_sfx.py
"""
import pathlib

import numpy as np
import soundfile as sf
from scipy import signal

HERE = pathlib.Path(__file__).parent
ROOT = HERE.parent.parent
OUT = ROOT / 'assets' / 'audio' / 'squishdoku'
SR = 44100
SHORT_S = 1.2
rand = np.random.default_rng(7)


# --- building blocks -----------------------------------------------------------

def secs(d):
    return np.arange(int(d * SR)) / SR


def note(name):
    """'C5' -> Hz (A4 = 440)."""
    names = {'C': -9, 'D': -7, 'E': -5, 'F': -4, 'G': -2, 'A': 0, 'B': 2}
    semis = names[name[0]]
    rest = name[1:]
    if rest.startswith('#'):
        semis += 1
        rest = rest[1:]
    elif rest.startswith('b'):
        semis -= 1
        rest = rest[1:]
    return 440.0 * 2 ** ((semis + 12 * (int(rest) - 4)) / 12)


def sweep(f0, f1, d, curve='exp'):
    t = np.linspace(0, 1, int(d * SR), endpoint=False)
    if curve == 'exp':
        return f0 * (f1 / f0) ** t
    return f0 + (f1 - f0) * t


def osc(freq, d=None, kind='sine', phase=0.0):
    """freq: Hz or an array of Hz per sample."""
    if np.isscalar(freq):
        freq = np.full(int(d * SR), float(freq))
    ph = phase + 2 * np.pi * np.cumsum(freq) / SR
    if kind == 'sine':
        return np.sin(ph)
    if kind == 'tri':
        return 2 / np.pi * np.arcsin(np.sin(ph))
    if kind == 'square':
        return np.tanh(4 * np.sin(ph))
    if kind == 'saw':
        x = (ph / (2 * np.pi)) % 1.0
        return 2 * x - 1
    raise ValueError(kind)


def env(n, a=0.005, d=0.1, s=0.0, r=0.05, hold=0.0):
    """Attack, hold, exponential decay to the sustain level, then release, over n samples."""
    t = np.arange(n) / SR
    out = np.empty(n)
    end_a = a
    end_h = a + hold
    rel_at = max(end_h, n / SR - r)
    for_a = t < end_a
    out[for_a] = t[for_a] / max(a, 1e-6)
    mid = (t >= end_a) & (t < rel_at)
    out[mid] = np.where(t[mid] < end_h, 1.0, s + (1 - s) * np.exp(-(t[mid] - end_h) / max(d, 1e-6)))
    last = s + (1 - s) * np.exp(-(rel_at - end_h) / max(d, 1e-6)) if rel_at > end_h else 1.0
    tail = t >= rel_at
    out[tail] = last * np.clip(1 - (t[tail] - rel_at) / max(r, 1e-6), 0, 1)
    return out


def decay(n, tau, a=0.002):
    t = np.arange(n) / SR
    return np.minimum(1, t / a) * np.exp(-t / tau)


def noise(d):
    return rand.uniform(-1, 1, int(d * SR))


def band(x, lo, hi, order=2):
    sos = signal.butter(order, [lo, hi], btype='band', fs=SR, output='sos')
    return signal.sosfilt(sos, x)


def low(x, f, order=2):
    sos = signal.butter(order, f, btype='low', fs=SR, output='sos')
    return signal.sosfilt(sos, x)


def high(x, f, order=2):
    sos = signal.butter(order, f, btype='high', fs=SR, output='sos')
    return signal.sosfilt(sos, x)


def sweep_filter(x, f0, f1, kind='low', q=0.9, steps=48):
    """A filter whose cutoff glides from f0 to f1 (processed in blocks)."""
    out = np.zeros_like(x)
    n = len(x)
    edges = np.linspace(0, n, steps + 1).astype(int)
    zi = None
    for i in range(steps):
        f = f0 * (f1 / f0) ** (i / max(1, steps - 1))
        if kind == 'band':
            sos = signal.butter(2, [max(30, f / (1 + q)), min(SR / 2 - 100, f * (1 + q))], btype='band', fs=SR, output='sos')
        else:
            sos = signal.butter(2, min(f, SR / 2 - 100), btype=kind, fs=SR, output='sos')
        if zi is None or zi.shape[0] != sos.shape[0]:
            zi = np.zeros((sos.shape[0], 2))
        out[edges[i]:edges[i + 1]], zi = signal.sosfilt(sos, x[edges[i]:edges[i + 1]], zi=zi)
    return out


def bell(f, d=0.8, ratio=3.5, index=2.5, tau=0.25, bright=1.0):
    """FM bell: a carrier with a decaying modulator."""
    t = secs(d)
    n = len(t)
    idx = index * bright * np.exp(-t / (tau * 0.6))
    mod = np.sin(2 * np.pi * f * ratio * t) * idx
    car = np.sin(2 * np.pi * f * t + mod)
    return car * decay(n, tau)


def pluck(f, d=0.6, damp=0.996, bright=0.6):
    """Karplus-Strong string."""
    n = int(d * SR)
    period = max(2, int(SR / f))
    buf = low(rand.uniform(-1, 1, period), min(SR / 2 - 100, 1500 + 9000 * bright))
    out = np.empty(n)
    for i in range(n):
        v = buf[i % period]
        out[i] = v
        buf[i % period] = damp * 0.5 * (v + buf[(i + 1) % period])
    return out


def bloop(f0=520, f1=140, d=0.12, tau=0.05):
    """The squishy landing: a sine diving in pitch."""
    fr = sweep(f0, f1, d)
    return osc(fr) * decay(len(fr), tau, a=0.002)


def droplet(f0=450, f1=1300, d=0.07):
    """A water drop / bubble: a sine leaping up."""
    fr = sweep(f0, f1, d)
    return osc(fr) * decay(len(fr), d / 3, a=0.001)


def squish(d=0.14, f0=1600, f1=350):
    """Wet squelch: noise through a falling band."""
    x = sweep_filter(noise(d), f0, f1, kind='band', q=0.6)
    return x * decay(len(x), d / 3, a=0.004)


def click(d=0.012, f=3000):
    x = band(noise(d), f * 0.6, min(SR / 2 - 200, f * 1.6))
    return x * decay(len(x), d / 4, a=0.0005)


def thump(f=70, d=0.25, drop=2.0):
    fr = sweep(f * drop, f, d)
    return osc(fr) * decay(len(fr), d / 3, a=0.002)


def shimmer(d=0.8, lo=3000, hi=9000, density=60):
    """Sparkle: many tiny high bells scattered over d."""
    out = np.zeros(int(d * SR))
    for _ in range(int(density * d)):
        at = rand.uniform(0, d * 0.8)
        f = rand.uniform(lo, hi)
        b = bell(f, 0.12, ratio=2.01, index=0.6, tau=0.03) * rand.uniform(0.2, 0.7)
        i = int(at * SR)
        out[i:i + len(b)] += b[:len(out) - i]
    return out * np.linspace(1, 0.3, len(out))


def whoosh(d=0.35, f0=300, f1=3000, back=True):
    x = noise(d)
    if back:
        half = len(x) // 2
        y = np.concatenate([sweep_filter(x[:half], f0, f1, 'band', 0.5), sweep_filter(x[half:], f1, f0, 'band', 0.5)])
    else:
        y = sweep_filter(x, f0, f1, 'band', 0.5)
    w = np.sin(np.linspace(0, np.pi, len(y))) ** 1.5
    return y * w


def reverb(x, size=0.9, wet=0.25, tone=5000):
    ir_t = secs(size)
    ir = rand.uniform(-1, 1, len(ir_t)) * np.exp(-ir_t / (size / 5))
    ir = low(ir, tone)
    ir /= np.sqrt(np.sum(ir ** 2))
    wet_sig = np.concatenate([signal.fftconvolve(x, ir), [0.0]])
    dry = np.concatenate([x, np.zeros(len(ir_t))])
    return dry * (1 - wet * 0.5) + wet_sig * wet


def mix(parts, d=None):
    """parts: [(signal, start seconds, gain)]."""
    end = max(int(at * SR) + len(s) for s, at, *_ in parts)
    if d:
        end = max(end, int(d * SR))
    out = np.zeros(end)
    for s, at, *g in parts:
        i = int(at * SR)
        out[i:i + len(s)] += s * (g[0] if g else 1.0)
    return out


def chord(freqs, d, fn):
    return sum(fn(f, d) for f in freqs) / len(freqs) ** 0.6


def vibrato(f, d, rate=5.5, depth=0.012):
    t = secs(d)
    return f * (1 + depth * np.sin(2 * np.pi * rate * t))


def finish(x, peak, fade=0.01, max_s=None):
    x = np.tanh(x * 1.2) / np.tanh(1.2)  # gentle glue
    x = x - np.mean(x)
    # trim trailing silence
    loud = np.where(np.abs(x) > 1e-3 * np.abs(x).max())[0]
    if len(loud):
        x = x[: loud[-1] + int(0.02 * SR)]
    if max_s and len(x) > max_s * SR:
        # cut the tail short with a longer fade (the reverb's end)
        x = x[: int(max_s * SR)]
        fade = 0.25
    n = int(fade * SR)
    if n and len(x) > n:
        x[-n:] *= np.linspace(1, 0, n) ** 2
    return x / (np.abs(x).max() + 1e-9) * peak


# Played over and over mid-puzzle, so kept short enough to stay WAV.
MAX_S = {'sd_place': 1.15, 'sd_wrong': 1.15}
# Vorbis rings a little past the original peak.
OGG_HEADROOM = 0.88


# --- the sounds -------------------------------------------------------------------

S = {}

# cells ------------------------------------------------------------------------------
S['sd_tap'] = (mix([(osc(1750, 0.04) * decay(int(0.04 * SR), 0.012), 0, 0.7), (click(0.015, 3500), 0, 0.5), (osc(880, 0.04, 'tri') * decay(int(0.04 * SR), 0.01), 0, 0.3)]), 0.42)


def scratch(d=0.05, f=4200):
    x = band(noise(d), f * 0.55, min(SR / 2 - 200, f * 1.5)) * env(int(d * SR), a=0.004, d=d / 2, r=0.01)
    return x


S['sd_x'] = (mix([(scratch(0.05, 4800), 0, 0.9), (scratch(0.055, 3900), 0.065, 1.0), (click(0.01, 2500), 0.12, 0.4)]), 0.5)
S['sd_xOff'] = (mix([(sweep_filter(noise(0.13), 6500, 1500, 'band', 0.5) * np.sin(np.linspace(0, np.pi, int(0.13 * SR))), 0, 0.9), (droplet(900, 500, 0.05), 0.08, 0.35)]), 0.4)

# placing -------------------------------------------------------------------------
_fall = osc(sweep(1500, 650, 0.17)) * env(int(0.17 * SR), a=0.02, d=0.2, s=0.6, r=0.04) * 0.25
_land = mix([(bloop(560, 150, 0.13, 0.055), 0, 1.0), (squish(0.12, 1800, 400), 0.005, 0.45), (thump(85, 0.12), 0, 0.5)])
_chime = reverb(mix([(bell(note('C6'), 0.5, tau=0.18), 0, 0.6), (bell(note('E6'), 0.5, tau=0.18), 0.045, 0.55), (bell(note('G6'), 0.6, tau=0.2), 0.09, 0.6), (shimmer(0.35, 4000, 9000, 40), 0.1, 0.35)]), 0.7, 0.22)
S['sd_place'] = (mix([(_fall, 0, 1.0), (_land, 0.18, 1.0), (_chime, 0.23, 0.55)]), 0.78)


def grumble(d=0.2):
    fr = sweep(190, 120, d) * (1 + 0.04 * np.sin(2 * np.pi * 22 * secs(d)))
    v = osc(fr, kind='saw')
    v = band(v, 380, 1100) + 0.5 * band(v, 1700, 2600)
    return v * env(len(v), a=0.02, d=0.12, s=0.5, r=0.06)


_buzz = (osc(110, 0.22, 'square') + osc(116.5, 0.22, 'square')) * 0.5
_buzz = low(_buzz, 1400) * env(len(_buzz), a=0.005, d=0.3, s=0.8, r=0.05) * (0.75 + 0.25 * np.sign(np.sin(2 * np.pi * 18 * secs(0.22))))
_poof = sweep_filter(noise(0.18), 4000, 500, 'low') * decay(int(0.18 * SR), 0.05, a=0.004)
S['sd_wrong'] = (mix([(_fall * 0.8, 0, 1.0), (bloop(420, 120, 0.12, 0.05), 0.18, 0.9), (_buzz, 0.24, 0.75), (grumble(0.22), 0.4, 0.8), (_poof, 0.62, 0.8), (droplet(700, 300, 0.06), 0.63, 0.4)]), 0.8)
S['sd_squeak'] = (mix([(band(osc(np.concatenate([sweep(900, 1500, 0.06), sweep(1500, 1050, 0.12)]) * (1 + 0.03 * np.sin(2 * np.pi * 30 * secs(0.18))), kind='saw'), 700, 3200) * env(int(0.18 * SR), a=0.008, d=0.1, s=0.6, r=0.04), 0, 1.0), (band(noise(0.18), 2500, 7000) * decay(int(0.18 * SR), 0.05), 0, 0.12)]), 0.5)

# timer ----------------------------------------------------------------------------
S['sd_tick'] = (mix([(osc(1250, 0.05) * decay(int(0.05 * SR), 0.012), 0, 0.8), (osc(2500, 0.03) * decay(int(0.03 * SR), 0.006), 0, 0.3), (click(0.008, 4000), 0, 0.3)]), 0.5)
_wee = osc(vibrato(1, 0.45, 7, 0.0) * sweep(950, 300, 0.45), kind='tri') * env(int(0.45 * SR), a=0.01, d=0.5, s=0.7, r=0.08)
S['sd_starLost'] = (mix([(_wee, 0, 0.8), (thump(95, 0.12, 1.6), 0.45, 0.7), (click(0.012, 1500), 0.45, 0.3)]), 0.62)
_alarm = np.concatenate([osc(f, 0.1, 'square') * env(int(0.1 * SR), a=0.003, d=0.2, s=0.9, r=0.01) for f in (880, 660, 880, 660)])
_alarm = low(_alarm, 3000)
_wah = osc(sweep(420, 140, 0.65), kind='saw')
_wah = sweep_filter(_wah, 2500, 300, 'low') * env(len(_wah), a=0.02, d=0.6, s=0.6, r=0.15)
S['sd_timeUp'] = (mix([(_alarm, 0, 0.6), (_wah, 0.42, 0.9), (thump(60, 0.3), 0.42, 0.6)]), 0.85)

# board -----------------------------------------------------------------------------
S['sd_boardIn'] = (reverb(mix([(droplet(380 + 60 * i, 900 + 110 * i, 0.06), 0.045 * i + rand.uniform(0, 0.012), 0.6 + 0.03 * i) for i in range(12)]), 0.5, 0.15), 0.55)
S['sd_boardOut'] = (whoosh(0.32, 250, 2600), 0.5)

# solve ------------------------------------------------------------------------------


def brass(f, d):
    v = osc(vibrato(f, d, 5.5, 0.006), kind='saw')
    v = sweep_filter(v, 900, 4200, 'low', steps=16) * env(len(v), a=0.025, d=0.4, s=0.75, r=0.1)
    return v


_fan = mix([
    (brass(note('G4'), 0.11), 0, 0.7), (brass(note('C5'), 0.11), 0.12, 0.7), (brass(note('E5'), 0.11), 0.24, 0.7),
    (chord([note('C5'), note('E5'), note('G5'), note('C6')], 0.75, brass), 0.36, 1.0),
    (thump(65, 0.3), 0.36, 0.6),
    (shimmer(0.9, 3500, 9000, 70), 0.38, 0.5),
    (bell(note('C7'), 0.6, tau=0.2), 0.38, 0.25),
])
S['sd_solve'] = (reverb(_fan, 1.0, 0.25), 0.92)


def boing(f=300, d=0.28):
    t = secs(d)
    fr = f * (1 + 0.5 * np.exp(-t / 0.08) * np.sin(2 * np.pi * 14 * t)) * (1 + 0.6 * t)
    return osc(fr) * decay(len(t), 0.09, a=0.003)


S['sd_hop'] = (mix([(boing(320, 0.28), 0, 1.0), (squish(0.06, 2500, 900), 0, 0.2)]), 0.55)
_crackle = np.zeros(int(0.6 * SR))
for _ in range(90):
    i = int(rand.uniform(0.03, 0.55) * SR)
    c = click(0.006, rand.uniform(2500, 7000)) * rand.uniform(0.2, 0.8)
    _crackle[i:i + len(c)] += c[: len(_crackle) - i]
S['sd_confetti'] = (mix([(sweep_filter(noise(0.08), 6000, 900, 'low') * decay(int(0.08 * SR), 0.02), 0, 1.0), (thump(110, 0.08), 0, 0.5), (_crackle, 0.02, 0.6), (shimmer(0.5, 5000, 10000, 50), 0.05, 0.3)]), 0.6)

# result: the three score creatures, each bigger than the last -----------------------
_pop = osc(sweep(300, 1000, 0.035)) * decay(int(0.035 * SR), 0.012, a=0.001)
S['sd_star1'] = (reverb(mix([(_pop, 0, 0.8), (bell(note('E5'), 0.6, tau=0.2), 0.02, 0.8), (bell(note('E6'), 0.4, tau=0.12, index=1.2), 0.02, 0.25), (shimmer(0.3, 4000, 8000, 30), 0.03, 0.3), (thump(110, 0.1), 0, 0.35)]), 0.6, 0.2), 0.7)
S['sd_star2'] = (reverb(mix([(_pop, 0, 0.9), (bell(note('G5'), 0.8, tau=0.26), 0.02, 0.7), (bell(note('B5'), 0.8, tau=0.26), 0.035, 0.6), (bell(note('D6'), 0.6, tau=0.2), 0.05, 0.4), (shimmer(0.5, 4000, 9500, 50), 0.04, 0.4), (thump(90, 0.15), 0, 0.5), (whoosh(0.2, 1500, 6000, False), 0, 0.15)]), 0.8, 0.24), 0.8)
_rise = osc(sweep(400, 2400, 0.25), kind='tri') * env(int(0.25 * SR), a=0.2, d=0.1, s=1, r=0.03) * 0.25
S['sd_star3'] = (reverb(mix([
    (_rise, 0, 1.0),
    (thump(55, 0.4, 2.5), 0.25, 1.0),
    (sweep_filter(noise(0.15), 8000, 800, 'low') * decay(int(0.15 * SR), 0.04), 0.25, 0.6),
    (chord([note('C6'), note('E6'), note('G6'), note('C7')], 1.2, lambda f, d: bell(f, d, tau=0.4, index=2.0)), 0.25, 1.0),
    (chord([note('C4'), note('G4'), note('C5')], 0.9, brass), 0.25, 0.55),
    (shimmer(1.1, 3500, 10000, 90), 0.27, 0.6),
]), 1.2, 0.3), 0.95)
S['sd_starEmpty'] = (mix([(thump(80, 0.2, 1.4), 0, 0.8), (osc(sweep(260, 120, 0.35), kind='tri') * env(int(0.35 * SR), a=0.01, d=0.3, s=0.5, r=0.08), 0.02, 0.6), (low(noise(0.05), 600) * decay(int(0.05 * SR), 0.012), 0, 0.5)]), 0.5)


def choir(f, d):
    v = sum(osc(vibrato(f * (1 + det), d, 5 + det * 80, 0.008), kind='saw') for det in (-0.006, 0, 0.007)) / 3
    v = band(v, 300, 2600)
    return v * env(len(v), a=0.12, d=0.8, s=0.7, r=0.35)


_stamp = mix([(thump(50, 0.35, 3.0), 0, 1.0), (sweep_filter(noise(0.12), 9000, 600, 'low') * decay(int(0.12 * SR), 0.03), 0, 0.8), (click(0.02, 1800), 0, 0.5)])
S['sd_perfect'] = (reverb(mix([(_stamp, 0, 1.0), (chord([note('C5'), note('E5'), note('G5'), note('B5'), note('D6')], 1.3, choir), 0.06, 0.8), (shimmer(1.2, 4000, 10000, 80), 0.08, 0.6), (bell(note('G6'), 0.9, tau=0.3), 0.08, 0.3)]), 1.3, 0.3), 0.95)
S['sd_coinTick'] = (mix([(osc(note('E7'), 0.12) * decay(int(0.12 * SR), 0.04), 0, 0.6), (osc(note('A7'), 0.12) * decay(int(0.12 * SR), 0.03), 0.012, 0.5), (click(0.006, 6000), 0, 0.2)]), 0.42)
_xp = osc(sweep(300, 1300, 0.7), kind='tri') * env(int(0.7 * SR), a=0.05, d=1, s=1, r=0.12) * (0.75 + 0.25 * np.sin(2 * np.pi * 16 * secs(0.7)))
S['sd_xpFill'] = (mix([(_xp, 0, 0.6), (shimmer(0.7, 3000, 7000, 40), 0, 0.4)]), 0.5)
_arp = mix([(low(osc(note(n), 0.16, 'square'), 3500) * env(int(0.16 * SR), a=0.005, d=0.1, s=0.4, r=0.04), 0.075 * i, 0.6) for i, n in enumerate(['C5', 'E5', 'G5', 'C6', 'E6'])])
S['sd_levelUp'] = (reverb(mix([(_arp, 0, 1.0), (chord([note('C6'), note('E6'), note('G6')], 0.7, lambda f, d: bell(f, d, tau=0.25)), 0.4, 0.9), (shimmer(0.8, 4000, 10000, 70), 0.4, 0.5), (thump(80, 0.2), 0.4, 0.4)]), 0.9, 0.25), 0.88)

# map -----------------------------------------------------------------------------
S['sd_unlock'] = (reverb(mix([(click(0.015, 2200), 0, 0.8), (click(0.015, 3200), 0.06, 0.8), (sum(bell(note(n), 0.4, tau=0.15) * 0.4 for n in ['G5']), 0.12, 1.0), (mix([(bell(note(n), 0.35, tau=0.12), 0.04 * i, 0.5) for i, n in enumerate(['C6', 'E6', 'G6', 'C7'])]), 0.14, 1.0), (shimmer(0.4, 5000, 10000, 40), 0.18, 0.3)]), 0.6, 0.2), 0.62)
S['sd_locked'] = (mix([(thump(150, 0.15, 1.5), 0, 0.9), (band(noise(0.04), 500, 1500) * decay(int(0.04 * SR), 0.01), 0, 0.6), (osc(220, 0.08, 'square') * decay(int(0.08 * SR), 0.02), 0, 0.15)]), 0.5)
S['sd_nodePop'] = (mix([(droplet(500, 1150, 0.07), 0, 1.0), (click(0.006, 5000), 0, 0.2)]), 0.38)
S['sd_select'] = (mix([(whoosh(0.28, 400, 3500, False), 0, 0.6), (bell(note('G5'), 0.5, tau=0.18), 0.2, 0.7), (bell(note('D6'), 0.5, tau=0.18), 0.25, 0.5), (thump(120, 0.1), 0.2, 0.3)]), 0.62)

# controls ----------------------------------------------------------------------------
S['sd_mode'] = (mix([(click(0.01, 2600), 0, 0.7), (click(0.01, 3400), 0.045, 0.6), (osc(sweep(420, 900, 0.09)) * decay(int(0.09 * SR), 0.035), 0.05, 0.6)]), 0.45)
S['sd_modeOff'] = (mix([(click(0.01, 3000), 0, 0.6), (osc(sweep(900, 420, 0.09)) * decay(int(0.09 * SR), 0.035), 0.02, 0.6)]), 0.42)
S['sd_pause'] = (mix([(osc(sweep(700, 350, 0.14), kind='tri') * decay(int(0.14 * SR), 0.06), 0, 1.0), (low(noise(0.05), 2000) * decay(int(0.05 * SR), 0.015), 0, 0.2)]), 0.45)
S['sd_resume'] = (mix([(osc(sweep(350, 800, 0.14), kind='tri') * decay(int(0.14 * SR), 0.07), 0, 1.0), (bell(note('A6'), 0.2, tau=0.06), 0.08, 0.3)]), 0.45)

# blitz -----------------------------------------------------------------------------
_beep = lambda f, d=0.16: (osc(f, d) * 0.7 + osc(f, d, 'tri') * 0.3 + osc(f * 2, d) * 0.15) * env(int(d * SR), a=0.004, d=0.2, s=0.8, r=0.04)
S['sd_count'] = (mix([(_beep(660), 0, 1.0), (thump(110, 0.1), 0, 0.3)]), 0.6)
S['sd_go'] = (reverb(mix([(_beep(1320, 0.28) * np.linspace(1, 0.6, int(0.28 * SR)), 0, 0.9), (chord([note('C5'), note('G5'), note('C6')], 0.45, brass), 0, 0.7), (thump(60, 0.3), 0, 0.6), (whoosh(0.3, 800, 7000, False), 0, 0.25)]), 0.7, 0.2), 0.85)
S['sd_blitzNext'] = (mix([(whoosh(0.3, 300, 4000), 0, 0.7), (bell(note('C6'), 0.45, tau=0.15), 0.18, 0.7), (bell(note('G6'), 0.45, tau=0.15), 0.23, 0.6), (thump(100, 0.1), 0.18, 0.3)]), 0.65)
S['sd_pip'] = (mix([(bell(note('G6'), 0.18, ratio=2.0, index=1.0, tau=0.06), 0, 1.0), (click(0.006, 5000), 0, 0.2)]), 0.45)


def trombone(f, d):
    v = osc(vibrato(f, d, 6, 0.015 if d > 0.4 else 0.004), kind='saw')
    v = sweep_filter(v, 700, 1800, 'low', steps=12)
    return v * env(len(v), a=0.03, d=0.5, s=0.8, r=0.08)


_sad = mix([(trombone(note('G3'), 0.28), 0.0, 0.8), (trombone(note('F#3'), 0.28), 0.3, 0.8), (trombone(note('F3'), 0.28), 0.6, 0.8), (trombone(note('E3'), 0.8) * np.linspace(1, 0.3, int(0.8 * SR)), 0.9, 0.9)])
S['sd_blitzFail'] = (reverb(mix([(thump(45, 0.4, 3), 0, 1.0), (sweep_filter(noise(0.3), 5000, 200, 'low') * decay(int(0.3 * SR), 0.08), 0, 0.8), (_sad, 0.2, 0.9)]), 0.8, 0.2), 0.88)
S['sd_drain'] = (mix([(droplet(1300 - 85 * i, 900 - 60 * i, 0.05), 0.055 * i, 0.7) for i in range(10)]), 0.5)
_harp = mix([(pluck(note(n), 0.7, 0.997, 0.7), 0.045 * i, 0.5) for i, n in enumerate(['C5', 'D5', 'E5', 'G5', 'A5', 'C6', 'D6', 'E6', 'G6', 'A6', 'C7'])])
S['sd_revive'] = (reverb(mix([(_harp, 0, 1.0), (chord([note('C5'), note('E5'), note('G5')], 1.0, choir), 0.2, 0.6), (shimmer(0.9, 4000, 10000, 60), 0.3, 0.5)]), 1.1, 0.3), 0.85)
_coins = np.zeros(int(1.4 * SR))
for _ in range(45):
    i = int(rand.uniform(0.3, 1.2) * SR)
    c = (osc(rand.uniform(2600, 3600), 0.1) * decay(int(0.1 * SR), 0.03)) * rand.uniform(0.2, 0.6)
    _coins[i:i + len(c)] += c[: len(_coins) - i]
_win = mix([
    (brass(note('C5'), 0.12), 0, 0.7), (brass(note('E5'), 0.12), 0.13, 0.7), (brass(note('G5'), 0.12), 0.26, 0.7),
    (brass(note('C6'), 0.12), 0.39, 0.7),
    (chord([note('C5'), note('E5'), note('G5'), note('C6'), note('E6')], 1.3, brass), 0.52, 1.0),
    (thump(50, 0.5, 3), 0.52, 0.9),
    (_coins, 0.4, 0.6),
    (shimmer(1.5, 3500, 10000, 90), 0.52, 0.6),
    (chord([note('C7'), note('G7')], 1.0, lambda f, d: bell(f, d, tau=0.35)), 0.52, 0.3),
])
S['sd_blitzWin'] = (reverb(_win, 1.4, 0.28), 0.95)


# --- write ---------------------------------------------------------------------------

def main():
    OUT.mkdir(parents=True, exist_ok=True)
    for old in list(OUT.glob('*.wav')) + list(OUT.glob('*.ogg')):
        old.unlink()
    total = 0
    files = {}
    for name, (data, peak) in S.items():
        x = finish(np.asarray(data, dtype=np.float64), peak, max_s=MAX_S.get(name))
        assert np.isfinite(x).all(), name
        if len(x) / SR <= SHORT_S:
            dest = OUT / f'{name}.wav'
            sf.write(dest, x.astype(np.float32), SR, subtype='PCM_16')
        else:
            dest = OUT / f'{name}.ogg'
            with sf.SoundFile(dest, 'w', SR, 1, format='OGG', subtype='VORBIS', compression_level=0.4) as f:
                for i in range(0, len(x), 4096):
                    f.write((x[i:i + 4096] * OGG_HEADROOM).astype(np.float32))
        files[name] = dest.name
        size = dest.stat().st_size
        total += size
        print(f'{dest.relative_to(ROOT)}  {len(x) / SR:5.2f}s  {size / 1024:6.1f} KB')
    lines = [f"  {n}: require('../../assets/audio/squishdoku/{files[n]}')," for n in sorted(S)]
    header = [
        '// Generated by tools/audio/squishdoku_sfx.py — Squishdoku\'s sound effects.',
        "// Don't edit by hand.",
        '',
        'export default {',
    ]
    (ROOT / 'src' / 'audio' / 'squishdokuFiles.js').write_text('\n'.join(header + lines + ['};', '']), encoding='utf8')
    print(f'{len(S)} sounds, {total / 1024:.0f} KB')


if __name__ == '__main__':
    main()
