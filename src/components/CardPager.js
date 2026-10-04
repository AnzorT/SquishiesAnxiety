import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, PanResponder, StyleSheet, View } from 'react-native';
import RoundButton, { Triangle } from './candy/RoundButton';
import sfx from '../audio/sfx';

// One Home list: ▲ button, a vertical one-card-at-a-time track, ▼ button.
//
// Every card on screen or next to it is a mounted, page-keyed element, and a
// single native-driven `pos` value places them all. Paging just animates
// `pos`, so:
//   · an arrow tap starts moving on the very next frame — the incoming card
//     is already mounted (only the one beyond it mounts, off-screen);
//   · a finger drag moves the same cards, and letting go hands over to the
//     same card instance — nothing remounts, so the creature's animation
//     never restarts mid-swipe.
// The motion is the design's: the incoming card rises/drops 108% of the
// track while growing 0.94 → 1 and fading 0.5 → 1 (cardSlideUp/Down); the
// outgoing one leaves the other way, shrinking and fading out (cardExitUp/
// Down), 0.4s cubic-bezier(0.4, 0, 0.2, 1).

const ARROW_H = 44;
const SWIPE_COMMIT = 46; // the design's swipe threshold, px
const EASE = Easing.bezier(0.4, 0, 0.2, 1);
const DURATION = 400;

function Arrow({ dir, onPress, dim }) {
  return (
    <View style={styles.arrowRow}>
      <RoundButton size={28} lip={3} onPress={onPress} hitSlop={12} style={dim ? { opacity: 0.35 } : null}>
        <Triangle dir={dir} size={8} />
      </RoundButton>
    </View>
  );
}

const Page = React.memo(function Page({ index, pos, trackH, navDir, current, children }) {
  const style = useMemo(() => {
    const d = Animated.subtract(index, pos);
    const shift = trackH * 1.08;
    return {
      transform: [
        { translateY: d.interpolate({ inputRange: [-2, -1, 0, 1, 2], outputRange: [-2 * shift, -shift, 0, shift, 2 * shift], extrapolate: 'clamp' }) },
        { scale: d.interpolate({ inputRange: [-1, 0, 1], outputRange: [0.94, 1, 0.94], extrapolate: 'clamp' }) },
      ],
      // The card coming in fades 0.5 → 1, the one leaving 1 → 0, so which
      // side gets which depends on the direction of travel.
      opacity: d.interpolate({ inputRange: [-1, 0, 1], outputRange: navDir > 0 ? [0, 1, 0.5] : [0.5, 1, 0], extrapolate: 'clamp' }),
    };
  }, [index, pos, trackH, navDir]);
  return (
    <Animated.View style={[styles.page, style]} pointerEvents={current ? 'box-none' : 'none'}>
      {children}
    </Animated.View>
  );
});

function CardPager({
  pageCount,
  initialPage = 0,
  onPageChange,
  renderPage,
  pageKey = (i) => String(i),
  jump, // { page, token } — move straight to `page` whenever `token` changes
  placeholder = null, // shown in the track while `ready` is false
  ready = true,
}) {
  const clampPage = useCallback((p) => Math.max(0, Math.min(Math.max(0, pageCount - 1), p)), [pageCount]);
  const [page, setPage] = useState(() => clampPage(initialPage));
  const [span, setSpan] = useState(() => ({ lo: page - 1, hi: page + 1 }));
  const [navDir, setNavDir] = useState(1);
  const [trackH, setTrackH] = useState(0);
  const pos = useRef(new Animated.Value(page)).current;
  const pageRef = useRef(page);
  const anim = useRef(null);
  const navDirRef = useRef(navDir);

  const setDir = useCallback((d) => {
    if (navDirRef.current !== d) {
      navDirRef.current = d;
      setNavDir(d);
    }
  }, []);

  const goTo = useCallback(
    (target, { duration = DURATION, instant = false } = {}) => {
      const next = clampPage(target);
      const from = pageRef.current;
      if (anim.current) anim.current.stop();
      if (next === from && !instant) {
        // e.g. an uncommitted drag — settle back
        anim.current = Animated.spring(pos, { toValue: next, friction: 9, tension: 80, useNativeDriver: true });
        anim.current.start();
        return;
      }
      if (next !== from) setDir(next > from ? 1 : -1);
      pageRef.current = next;
      setPage(next);
      if (next !== from && onPageChange) onPageChange(next);
      if (next !== from && !instant) sfx.play('swoosh');
      if (instant) {
        pos.setValue(next);
        setSpan({ lo: next - 1, hi: next + 1 });
        return;
      }
      setSpan((s) => ({ lo: Math.min(s.lo, from - 1, next - 1), hi: Math.max(s.hi, from + 1, next + 1) }));
      anim.current = Animated.timing(pos, { toValue: next, duration, easing: EASE, useNativeDriver: true });
      anim.current.start(({ finished }) => {
        if (finished) setSpan({ lo: next - 1, hi: next + 1 });
      });
    },
    [clampPage, onPageChange, pos, setDir]
  );

  // The list shrank under us (a custom creature deleted) — stay in range.
  useEffect(() => {
    if (pageRef.current > pageCount - 1 && pageCount > 0) goTo(pageCount - 1, { instant: true });
  }, [pageCount, goTo]);

  useEffect(() => {
    if (jump && jump.token) goTo(jump.page, { instant: true });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [jump && jump.token]);

  useEffect(() => () => anim.current && anim.current.stop(), []);

  // --- finger drag ---
  const trackHRef = useRef(0);
  trackHRef.current = trackH;
  const countRef = useRef(pageCount);
  countRef.current = pageCount;
  const goToRef = useRef(goTo);
  goToRef.current = goTo;

  const pan = useMemo(
    () =>
      PanResponder.create({
        // Capture phase: the card's own Pressable (tap / hold-to-unlock)
        // claims touches as they land, so the swipe has to take over on the
        // way down once the finger is clearly moving vertically.
        onMoveShouldSetPanResponderCapture: (_e, g) => Math.abs(g.dy) > 6 && Math.abs(g.dy) > Math.abs(g.dx),
        onMoveShouldSetPanResponder: (_e, g) => Math.abs(g.dy) > 6 && Math.abs(g.dy) > Math.abs(g.dx),
        onPanResponderTerminationRequest: () => false,
        onPanResponderGrant: () => {
          if (anim.current) anim.current.stop();
          pos.setValue(pageRef.current);
        },
        onPanResponderMove: (_e, g) => {
          const shift = (trackHRef.current || 1) * 1.08;
          const last = countRef.current - 1;
          let p = pageRef.current - g.dy / shift;
          // rubber-band past either end
          if (p < 0) p *= 0.25;
          else if (p > last) p = last + (p - last) * 0.25;
          if (g.dy) setDir(g.dy < 0 ? 1 : -1);
          pos.setValue(p);
        },
        onPanResponderRelease: (_e, g) => {
          const dir = g.dy < 0 ? 1 : -1;
          const target = pageRef.current + dir;
          const inRange = target >= 0 && target <= countRef.current - 1;
          const committed = inRange && (Math.abs(g.dy) >= SWIPE_COMMIT || Math.abs(g.vy) > 0.6);
          goToRef.current(committed ? target : pageRef.current, { duration: 260 });
        },
        onPanResponderTerminate: () => goToRef.current(pageRef.current, { duration: 260 }),
      }),
    [pos, setDir]
  );

  const pages = [];
  if (trackH > 0 && ready) {
    for (let i = Math.max(0, span.lo); i <= Math.min(pageCount - 1, span.hi); i++) {
      pages.push(
        <Page key={pageKey(i)} index={i} pos={pos} trackH={trackH} navDir={navDir} current={i === page}>
          {renderPage(i)}
        </Page>
      );
    }
  }

  return (
    <View style={styles.fill}>
      <Arrow dir="up" onPress={() => goTo(pageRef.current - 1)} dim={page === 0} />
      <View style={styles.track} onLayout={(e) => setTrackH(e.nativeEvent.layout.height)} {...pan.panHandlers}>
        {ready ? pages : <View style={styles.page}>{placeholder}</View>}
      </View>
      <Arrow dir="down" onPress={() => goTo(pageRef.current + 1)} />
    </View>
  );
}

export default React.memo(CardPager);

export const CARD_SIZE = { width: '84%', height: '88%', maxHeight: 400 };

const styles = StyleSheet.create({
  fill: { flex: 1 },
  arrowRow: { height: ARROW_H, alignItems: 'center', justifyContent: 'center' },
  track: { flex: 1, minHeight: 0, overflow: 'hidden' },
  page: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
});
