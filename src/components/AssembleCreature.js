import React from 'react';
import Svg, { Defs, RadialGradient, Stop, Circle, Ellipse, Path, Line } from 'react-native-svg';

// The "assemble" creature preview for the creator flow — a port of the
// decoded "ASMR Creature Squash Game.html" `drawAssembled()` canvas routine
// to SVG (100-unit box, cx 50 / cy 54, same proportions). Renders from a
// build config { body, eyes, mouth, extra, color } and is reused wherever a
// custom creature with no photo needs to be shown (creator preview, the
// MY CREATURES card, the squish stage).

export const ASSEMBLE_BODY_COLORS = ['#2dd4bf', '#f9a8d4', '#facc15', '#a78bfa', '#4ade80', '#fb7185', '#67e8f9'];

export const ASSEMBLE_DEFAULT = { body: 'blob', eyes: 'round', mouth: 'smile', extra: 'none', color: '#2dd4bf' };

const CX = 50;
const CY = 54;

function bodyRadii(body) {
  if (body === 'tall') return { rx: 25, ry: 34 };
  if (body === 'wide') return { rx: 35, ry: 25 };
  return { rx: 30, ry: 30 }; // blob / round
}

function starPoints(px, py, r) {
  const pts = [];
  for (let i = 0; i < 10; i++) {
    const a = (Math.PI / 5) * i - Math.PI / 2;
    const rr = i % 2 ? r * 0.45 : r;
    pts.push(`${i === 0 ? 'M' : 'L'} ${px + Math.cos(a) * rr},${py + Math.sin(a) * rr}`);
  }
  return pts.join(' ') + ' Z';
}

export default function AssembleCreature({ build = ASSEMBLE_DEFAULT, size = 120 }) {
  const b = { ...ASSEMBLE_DEFAULT, ...build };
  const { rx, ry } = bodyRadii(b.body);
  const color = b.color || ASSEMBLE_DEFAULT.color;

  const ex = rx * 0.42;
  const ey = CY - ry * 0.16;
  const er = 5.5;
  const my = CY + ry * 0.34;
  const mw = rx * 0.36;

  const blobPath = `M ${CX},${CY - ry} C ${CX + rx * 1.18},${CY - ry * 0.9} ${CX + rx * 1.05},${CY + ry * 0.85} ${CX},${CY + ry} C ${CX - rx * 1.05},${CY + ry * 0.85} ${CX - rx * 1.18},${CY - ry * 0.9} ${CX},${CY - ry} Z`;

  return (
    <Svg width={size} height={size} viewBox="0 0 100 100">
      <Defs>
        <RadialGradient id="asmBody" cx="35%" cy="32%" r="75%">
          <Stop offset="0%" stopColor="#ffffff" />
          <Stop offset="35%" stopColor={color} />
          <Stop offset="100%" stopColor={color} />
        </RadialGradient>
      </Defs>

      {/* --- extras (behind the body) --- */}
      {b.extra === 'antenna' ? (
        <>
          <Line x1={CX + rx * 0.15} y1={CY - ry} x2={CX + rx * 0.25} y2={CY - ry * 1.42} stroke="#0d9488" strokeWidth={2.2} strokeLinecap="round" />
          <Circle cx={CX + rx * 0.25} cy={CY - ry * 1.5} r={3.5} fill="#ffb703" />
        </>
      ) : null}
      {b.extra === 'ears'
        ? [-1, 1].map((d) => <Circle key={d} cx={CX + d * rx * 0.78} cy={CY - ry * 0.62} r={8.5} fill={color} />)
        : null}
      {b.extra === 'horns'
        ? [-1, 1].map((d) => (
            <Path
              key={d}
              d={`M ${CX + d * rx * 0.44},${CY - ry * 0.86} L ${CX + d * rx * 0.6},${CY - ry * 1.34} L ${CX + d * rx * 0.24},${CY - ry * 0.96} Z`}
              fill="#fbbf24"
            />
          ))
        : null}

      {/* --- body --- */}
      {b.body === 'blob' ? (
        <Path d={blobPath} fill="url(#asmBody)" />
      ) : (
        <Ellipse cx={CX} cy={CY} rx={rx} ry={ry} fill="url(#asmBody)" />
      )}

      {/* --- eyes --- */}
      {b.eyes === 'slit'
        ? [-1, 1].map((d) => (
            <Path
              key={d}
              d={`M ${CX + d * ex - er},${ey} Q ${CX + d * ex},${ey + er * 0.9} ${CX + d * ex + er},${ey}`}
              stroke="#0f172a"
              strokeWidth={1.6}
              strokeLinecap="round"
              fill="none"
            />
          ))
        : b.eyes === 'star'
        ? [-1, 1].map((d) => <Path key={d} d={starPoints(CX + d * ex, ey, er)} fill="#0f172a" />)
        : [-1, 1].map((d) => {
            const s = b.eyes === 'wide' ? 1.35 : 1;
            return (
              <React.Fragment key={d}>
                <Circle cx={CX + d * ex} cy={ey} r={er * s} fill="#ffffff" />
                <Circle cx={CX + d * ex} cy={ey + er * 0.12} r={er * s * 0.48} fill="#0f172a" />
              </React.Fragment>
            );
          })}

      {/* --- mouth --- */}
      {b.mouth === 'open' ? (
        <Ellipse cx={CX} cy={my} rx={mw * 0.62} ry={mw * 0.72} fill="#0f172a" />
      ) : b.mouth === 'flat' ? (
        <Line x1={CX - mw * 0.7} y1={my} x2={CX + mw * 0.7} y2={my} stroke="#0f172a" strokeWidth={2} strokeLinecap="round" />
      ) : b.mouth === 'fang' ? (
        <Path
          d={`M ${CX - mw * 0.7},${my - mw * 0.3} L ${CX + mw * 0.7},${my - mw * 0.3} L ${CX + mw * 0.3},${my + mw * 0.5} L ${CX},${my - mw * 0.05} L ${CX - mw * 0.35},${my + mw * 0.5} Z`}
          fill="#0f172a"
        />
      ) : (
        <Path d={`M ${CX - mw},${my - mw * 0.4} Q ${CX},${my + mw * 0.7} ${CX + mw},${my - mw * 0.4}`} stroke="#0f172a" strokeWidth={2} strokeLinecap="round" fill="none" />
      )}
    </Svg>
  );
}
