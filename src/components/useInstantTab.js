import { useCallback, useEffect, useRef, useState } from 'react';

// A tab switch that answers the tap at once. The control (a segmented
// switch, the bottom nav) shows the tapped tab right away: its pill starts
// sliding and its label lights up on the tap's own frame. The real switch
// (`onTab`, which re-renders the screen around it) runs two frames later,
// once that has been drawn. Before, the pill waited for the whole screen to
// re-render with the new tab, so for a moment nothing moved and the tap felt
// ignored. The pill's animation runs on the native driver, so it keeps going
// while JS builds the new tab.
//
//   const [shown, press] = useInstantTab(tab, onTab);
//   …pill and labels from `shown`, onPress={() => press(key)}
export default function useInstantTab(tab, onTab) {
  const [shown, setShown] = useState(tab);
  const onTabRef = useRef(onTab);
  onTabRef.current = onTab;
  const frames = useRef([]);
  // a change from outside (a tutorial step, a link to a tab) wins
  useEffect(() => setShown(tab), [tab]);
  useEffect(() => () => frames.current.forEach(cancelAnimationFrame), []);
  const press = useCallback((k) => {
    setShown(k);
    frames.current.forEach(cancelAnimationFrame);
    const first = requestAnimationFrame(() => {
      frames.current = [requestAnimationFrame(() => onTabRef.current(k))];
    });
    frames.current = [first];
  }, []);
  return [shown, press];
}
