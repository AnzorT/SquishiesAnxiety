// The web demo's server moves (src/web/Demo.js; a build with EXPO_PUBLIC_DEMO=1): in that build metro.config.js hands
// the app this file in place of src/squad/api.js. The games call only Blitz's gem save, which here spends the page's
// own gems by the same rule as functions/squad.js blitzSave (10, then twice the last, up to 320).
import { blitzSaveGems } from '../../squishdoku/levels';
import { demoProfile, setDemoProfile } from './store';

export async function blitzSave(i) {
  const gems = blitzSaveGems(i);
  const p = demoProfile();
  if ((p.gems || 0) < gems) throw new Error('not_enough_gems');
  setDemoProfile({ ...p, gems: p.gems - gems });
  return { gems };
}

export async function move(name) {
  throw new Error(`not in the demo: ${name}`);
}
