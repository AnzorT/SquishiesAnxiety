// Web only: the page you open on a computer (App.web.js). It shows the app inside a phone, at the Galaxy A15's screen
// size in dp (1080 x 2340 px at 450 dpi = 384 x 832), scaled to fit the browser window. The app itself runs in a
// frame of exactly that size (the same address with ?phone=1), so it lays out as on the phone, not across the monitor.
// The app turns the phone itself (src/web/orientation.js calls __phoneFrame.orient).
//   ?device=412x915   another phone (portrait width x height, in dp)
//   ?full=1           no frame: the app across the whole window
import React, { useCallback, useEffect, useRef, useState } from 'react';

const A15 = { name: 'Galaxy A15', w: 384, h: 832 };
const BEZEL = 12;

function deviceOf() {
  const m = /[?&]device=(\d+)x(\d+)/.exec(window.location.search);
  return m ? { name: `${m[1]} x ${m[2]}`, w: Math.min(+m[1], +m[2]), h: Math.max(+m[1], +m[2]) } : A15;
}

function innerUrl() {
  const u = new URL(window.location.href);
  u.searchParams.set('phone', '1');
  return u.pathname + u.search + u.hash;
}

export default function PhoneFrame() {
  const dev = useRef(deviceOf()).current;
  const frame = useRef(null);
  const [landscape, setLandscape] = useState(true);
  const [win, setWin] = useState({ w: window.innerWidth, h: window.innerHeight });

  useEffect(() => {
    const onResize = () => setWin({ w: window.innerWidth, h: window.innerHeight });
    window.addEventListener('resize', onResize);
    window.__phoneFrame = { orient: (o) => setLandscape(o !== 'portrait') };
    document.title = 'PlushCrush';
    document.body.style.margin = '0';
    document.body.style.background = '#14091f';
    return () => {
      window.removeEventListener('resize', onResize);
      delete window.__phoneFrame;
    };
  }, []);

  const back = useCallback(() => {
    try {
      const w = frame.current && frame.current.contentWindow;
      if (w && w.__webBack) w.__webBack();
    } catch (e) {}
  }, []);
  useEffect(() => {
    const onKey = (e) => e.key === 'Escape' && back();
    window.addEventListener('keydown', onKey);
    return () => window.removeEventListener('keydown', onKey);
  }, [back]);

  const sw = landscape ? dev.h : dev.w; // the screen, in dp
  const sh = landscape ? dev.w : dev.h;
  const ow = sw + BEZEL * 2;
  const oh = sh + BEZEL * 2;
  const scale = Math.max(0.3, Math.min((win.w - 32) / ow, (win.h - 76) / oh));

  const e = React.createElement;
  return e(
    'div',
    { style: { position: 'fixed', inset: 0, background: 'radial-gradient(circle at 50% 40%, #2b1645, #14091f 70%)', overflow: 'hidden', fontFamily: 'system-ui, sans-serif' } },
    e(
      'div',
      {
        style: {
          position: 'absolute', left: '50%', top: 'calc(50% - 22px)', width: ow, height: oh,
          transform: `translate(-50%, -50%) scale(${scale})`, transformOrigin: 'center center',
          background: '#0b0b0f', borderRadius: 34, boxShadow: '0 0 0 2px #2a2a33, 0 24px 60px rgba(0,0,0,0.55)',
          transition: 'width .25s, height .25s',
        },
      },
      e('iframe', {
        ref: frame,
        src: innerUrl(),
        title: 'PlushCrush',
        allow: 'autoplay; fullscreen; clipboard-write',
        style: { position: 'absolute', left: BEZEL, top: BEZEL, width: sw, height: sh, border: 0, borderRadius: 22, background: '#1A1326', display: 'block' },
      }),
    ),
    e(
      'div',
      { style: { position: 'absolute', left: 0, right: 0, bottom: 14, display: 'flex', justifyContent: 'center', alignItems: 'center', gap: 12, color: '#bfaee0', fontSize: 13 } },
      e('span', null, `${dev.name} · ${sw} x ${sh} dp · ${Math.round(scale * 100)}%`),
      e('button', { onClick: back, style: btn, title: 'The phone’s back button (Esc)' }, '◁ Back'),
      e('button', { onClick: () => frame.current && frame.current.contentWindow.location.reload(), style: btn }, 'Reload'),
      e('a', { href: '?full=1', style: { ...btn, textDecoration: 'none' } }, 'Full window'),
    ),
  );
}

const btn = { background: '#2e1d4a', color: '#e8dcff', border: '1px solid #4b3474', borderRadius: 8, padding: '5px 10px', fontSize: 13, cursor: 'pointer' };

// The frame is for a computer: inside it (?phone=1), with ?full=1, or on a phone's own browser, the app runs as is.
export function wantsFrame() {
  if (typeof window === 'undefined') return false;
  if (window.top !== window) return false;
  if (/[?&](phone|full)=1/.test(window.location.search)) return false;
  const coarse = window.matchMedia && window.matchMedia('(pointer: coarse)').matches;
  const small = Math.min(window.screen.width, window.screen.height) < 600;
  return !(coarse && small);
}
