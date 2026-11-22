// Web only: react-native-svg as is, plus SvgXml, which its web build (15.2) leaves out. Here SvgXml hands the markup
// to the browser, which draws SVG itself (filters and all). Each copy's ids get their own prefix, as react-native-svg
// keeps each <Svg> to itself: two creatures' gradients both called "a" would otherwise take the first one's colours.
import React, { memo, useMemo } from 'react';
import { View } from 'react-native';

export * from 'react-native-svg/lib/module/ReactNativeSVG.web';
export { default } from 'react-native-svg/lib/module/ReactNativeSVG.web';

let n = 0;
function prepare(xml, width, height) {
  if (!xml) return '';
  const p = `sx${(n++).toString(36)}_`;
  let s = String(xml);
  if (/\sid=/.test(s)) {
    s = s
      .replace(/\sid=(["'])([^"']+)\1/g, (m, q, id) => ` id=${q}${p}${id}${q}`)
      .replace(/url\(\s*(["']?)#([^"')\s]+)\1\s*\)/g, (m, q, id) => `url(#${p}${id})`)
      .replace(/(\s(?:xlink:)?href=)(["'])#([^"']+)\2/g, (m, a, q, id) => `${a}${q}#${p}${id}${q}`);
  }
  // the outer <svg> fills the box it's given (its own width/height become its viewBox when it has none)
  return s.replace(/<svg\b([^>]*)>/i, (m, attrs) => {
    let a = attrs;
    const w = /\swidth=(["'])([\d.]+)(?:px)?\1/.exec(a);
    const h = /\sheight=(["'])([\d.]+)(?:px)?\1/.exec(a);
    if (!/\sviewBox=/i.test(a) && w && h) a += ` viewBox="0 0 ${w[2]} ${h[2]}"`;
    a = a.replace(/\s(width|height)=(["'])[^"']*\2/g, '');
    return `<svg${a} width="${width != null ? width : '100%'}" height="${height != null ? height : '100%'}" style="display:block;overflow:visible">`;
  });
}

export const SvgXml = memo(function SvgXml({ xml, width, height, style, pointerEvents, ...rest }) {
  const html = useMemo(() => prepare(xml, width, height), [xml, width, height]);
  if (!html) return null;
  return (
    <View style={[width != null || height != null ? { width, height } : null, style]} pointerEvents={pointerEvents || 'none'}>
      {React.createElement('div', {
        style: { width: '100%', height: '100%', display: 'block', lineHeight: 0 },
        dangerouslySetInnerHTML: { __html: html },
      })}
    </View>
  );
});

export const SvgFromXml = SvgXml;
