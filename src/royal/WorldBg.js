import React, { memo, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, StyleSheet, View } from 'react-native';
import Room from '../hop/Room';
import { weatherToday } from '../weather';
import { useGameDims } from './GameFrame';

// The mini-games' level maps' backgrounds. Until 2026-11-17 all four stood in the main menu's world (a picture of it
// per season); then the user gave each its own: Squish Stack a forest that scrolls with its road (src/stack/ForestMap.js,
// which takes the season from here), Squishdoku and Squish Hop the room their levels are played in, Squish Sort the
// kitchen (RoomBackdrop below).

// the season, as the menu's world shows it: today's weather from config/weather (src/weather.js)
export const seasonNow = () => weatherToday();

// where a map's row of levels runs over a whole room (the maps' rowAt): along the floor, under the furniture
export const ROW_ON_FLOOR = 0.75;

// A screen's rooms behind its level map: where the map says they run (spans, from the map's onSpans) and how far the
// map is scrolled (scrollX, which the map drives on the UI thread). Pass both to RoomBackdrop and to the map.
export function useRoomStrip() {
  const scrollX = useRef(new Animated.Value(0)).current;
  const [spans, onSpans] = useState(null);
  return { scrollX, spans, onSpans };
}

// Behind a game's level map: the rooms its levels are played in (2026-11-17, the user: Squishdoku's and Squish Hop's
// rooms change, so each map's background is the room those levels are played in; Squish Sort only the kitchen),
// scrolling with the map (2026-11-17, the user: the background "not being scrolled" when the list is). Each room as a
// level draws it (src/hop/Room.js), all of it (`full`), in daylight, its picture repeated side by side for as long as
// its levels run (the pictures run on into each other), a wooden post where one room gives way to the next.
// spans: [{ room, x0, x1 }] along the map's page (its content's x). When they change (Squishdoku's next chapter) the
// new rooms fade in over the old. Fades in as the map slides in (sw: useViewSwitch); `under`: held at full opacity
// under a level that's starting (useRoomUnder).
export function RoomBackdrop({ sw, on, spans, scrollX, phase = 'day', under = false }) {
  if (!on || !spans || !spans.length) return null;
  return (
    <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, under ? null : { opacity: sw.style.opacity }]}>
      <StripFade spans={spans} scrollX={scrollX} phase={phase} />
    </Animated.View>
  );
}

// 2026-11-20 (the user: flickering): from the map into a level, the room behind the map went at the tap, while the
// level (which draws its own room) was still being built and fading in, so the bare page background flashed between
// two pictures of the same room. The map's room now stays up, at full opacity, under a level that has just started
// (`playing`, from the map) until shortly after the level is built (sw.ready), then goes (the level covers it).
export function useRoomUnder(sw, playing) {
  const [gone, setGone] = useState(false);
  useEffect(() => {
    if (!playing) {
      setGone(false);
      return undefined;
    }
    if (!sw.ready) return undefined;
    const t = setTimeout(() => setGone(true), 900);
    return () => clearTimeout(t);
  }, [playing, sw.ready]);
  return playing && !gone;
}

const keyOf = (spans) => spans.map((s) => `${s.room}:${Math.round(s.x0)}:${Math.round(s.x1)}`).join('|');

function StripFade({ spans, scrollX, phase }) {
  const key = keyOf(spans);
  const [st, setSt] = useState({ cur: spans, key, prev: null, n: 0 });
  // (new rooms: worked out while rendering, so the old ones never leave before the new ones are drawn over them)
  if (key !== st.key) setSt({ cur: spans, key, prev: st.cur, n: st.n + 1 });
  const fade = useMemo(() => new Animated.Value(st.n ? 0 : 1), [st.n]);
  useEffect(() => {
    if (!st.n) return undefined;
    const anim = Animated.timing(fade, { toValue: 1, duration: 420, useNativeDriver: true });
    anim.start(({ finished }) => finished && setSt((s) => (s.n === st.n ? { ...s, prev: null } : s)));
    return () => anim.stop();
  }, [st.n, fade]);
  return (
    <>
      {st.prev ? <Strip key={`p${st.n}`} spans={st.prev} scrollX={scrollX} phase={phase} /> : null}
      <Animated.View key={`c${st.n}`} style={[StyleSheet.absoluteFill, { opacity: fade }]}>
        <Strip spans={st.cur} scrollX={scrollX} phase={phase} />
      </Animated.View>
    </>
  );
}

const POST_W = 16;
const valueOf = (v) => (typeof v.__getValue === 'function' ? v.__getValue() : 0);

// The rooms along the page, a picture a screen wide, moved by the map's scroll on the UI thread. Only the pictures
// about the screen are drawn (Squish Hop's map is some 11,000 dp long): which, it learns from the scroll's value (a
// screen's width at a time), a couple of screens' worth either side, so a fling never outruns them.
const Strip = memo(function Strip({ spans, scrollX, phase }) {
  const { width, height } = useGameDims();
  const [at, setAt] = useState(() => Math.floor(valueOf(scrollX) / width));
  useEffect(() => {
    const to = (x) => {
      const i = Math.floor(x / width);
      setAt((a) => (a === i ? a : i));
    };
    to(valueOf(scrollX));
    const id = scrollX.addListener(({ value }) => to(value));
    return () => scrollX.removeListener(id);
  }, [scrollX, width]);
  const shift = useMemo(() => Animated.multiply(scrollX, -1), [scrollX]);
  const lo = (at - 2) * width;
  const hi = (at + 4) * width;
  const out = [];
  spans.forEach((s, j) => {
    // (the pictures from the room's start, a screen apart)
    const from = s.x0 + Math.max(0, Math.floor((lo - s.x0) / width)) * width;
    for (let x = from; x < Math.min(s.x1, hi); x += width) {
      out.push(
        <View key={`${j}:${x}`} style={[styles.tile, { left: x, width: Math.min(width, s.x1 - x), height }]}>
          <Room room={s.room} phase={phase} width={width} height={height} full />
        </View>,
      );
    }
    if (j > 0 && s.x0 > lo - POST_W && s.x0 < hi + POST_W) out.push(<View key={`post${j}`} style={[styles.post, { left: s.x0 - POST_W / 2, height }]} />);
  });
  return <Animated.View style={[styles.strip, { width: spans[spans.length - 1].x1, height, transform: [{ translateX: shift }] }]}>{out}</Animated.View>;
});

const styles = StyleSheet.create({
  strip: { position: 'absolute', left: 0, top: 0 },
  tile: { position: 'absolute', top: 0, overflow: 'hidden' },
  // where two rooms meet: a wooden post (the wood look's browns)
  post: { position: 'absolute', top: 0, width: POST_W, backgroundColor: '#c7884a', borderLeftWidth: 3, borderRightWidth: 3, borderColor: '#7a4a22' },
});
