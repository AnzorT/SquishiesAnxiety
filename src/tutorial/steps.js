// The guided tutorial (the 2026-10-03 design's tutSync in "ASMR Creature
// Squash v3.dc.html"), on the squad economy (src/squad): every new player
// has a Welcome chest that always holds Mittens (functions/squad.js); the
// second chest is a Basic one bought with the coins earned in the goal
// step; then a card about Stars, sets and finishes.
//
// `tut` on the profile is the current step; 'done' ends it. Each step says
// what the Guide shows (`ui`) and when to move on (`next`), from the store's
// view of the app (store.js) and the profile. App.js runs `stepView` on
// every change (and on a tick for the timed steps) and writes the step.

export const FIRST_STEP = 'start';
// the Crib picks the tutorial up from here (Phase C)
export const CRIB_STEP = 'crib';
export const GOAL_COINS = 500;
const HOLD_MS = 5000;
const ROTATE_PX = 260;

const isDone = (t) => !t || t === 'done';
// The tutorial starts after sign-in: nothing shows on the splash or the
// sign-in screen, and a restart picks it up from the step on the profile.
export const tutorialActive = (profile) => !!profile && !isDone(profile.tut);
// screens the guide never shows on (it waits for the next one)
const QUIET = ['splash', 'auth', 'wheel', 'reel', 'loading'];

const spot = (target, title, text, extra = {}) => ({ mode: 'spot', target, title, text, hand: 'tap', radius: 999, ...extra });
const card = (o) => ({ mode: 'card', ...o });

// The step for the app as it is: { ui } to show, { next } to move to, or
// { hide: true } when the step's screen isn't on (the guide waits).
export function stepView({ tut, s, profile, creatures = [], mittens }) {
  if (isDone(tut)) return { hide: true };
  if (s.busy || QUIET.includes(s.screen)) return { hide: true };
  const name = mittens?.name || 'Mittens';
  const starter = creatures.find((c) => c.id === '0')?.name || 'Nimbo';
  const on = (screen) => s.screen === screen;
  const owned = profile?.ownedIds || [];
  // Home is the Squishies tab and 'store' the Shop tab (MainScreen). A
  // squishy is a cell in the Collection (`card:<id>`, scrolled into view);
  // its sheet's SQUISH button is `sheetPlay`.
  const sheetUp = String(s.squadSheet) === '1';
  const toMittens = (title, text) =>
    sheetUp ? { ui: spot('sheetPlay', title, 'Tap SQUISH to play.', { radius: 20, place: 'top' }) } : { ui: spot('card:1', title, text, { radius: 18, place: 'top' }) };
  // a squish-screen step while the player is back on Home: point at the cell
  const backToToy = () => (on('home') ? toMittens(`Back to ${name}`, `Tap ${name} to keep playing.`) : { hide: true });
  // a chest step while the player is back on Home: point at the Shop tab
  const backToBox = () => (on('home') ? { ui: spot('store', 'Back to your chest', 'Tap the Shop to open it.') } : { hide: true });
  // the chest opener, while it's up (in the Shop)
  const smashing = s.boxPhase === 'opening';

  switch (tut) {
    case 'start':
      if (on('home')) return { next: 'box1' };
      return { hide: true };

    case 'box1':
      if (on('store')) return { next: 'box1tap' };
      if (!on('home')) return { hide: true };
      // the welcome chest is already open (a replay): straight on
      if (owned.includes('1')) return { next: 'play' };
      return { ui: spot('store', 'Your first chest!', 'Every squishy friend comes out of a chest. A welcome chest is waiting for you in the Shop — tap here.') };

    case 'box1tap':
      if (s.boxPhase === 'reveal') return { next: 'lvl2' };
      if (!on('store')) return backToBox();
      if (smashing) return { ui: spot('chestStage', 'Tap tap tap!', 'Tap the chest until it bursts open. Stop and it heals!', { radius: 40, block: false }) };
      return { ui: spot('shelf', 'Open it', 'Your Welcome chest is in My Chests. Tap it!', { radius: 16 }) };

    case 'lvl2':
      return {
        level: 2,
        ui: card({
          level: 2,
          title: 'You reached level 2!',
          text: `${name} joined your squad — your very first squishy friend.`,
          buttons: [{ label: 'Yay!', next: 'reveal' }],
        }),
      };

    case 'reveal':
      if (on('home')) return { next: 'play' };
      if (!on('store')) return { hide: true };
      if (s.boxPhase === 'reveal') return { ui: spot('revealDone', `Meet ${name}`, 'Tap here to say hi.') };
      return { ui: spot('storeBack', 'Back to your squishies', `Let’s go and play with ${name}.`) };

    // Mittens' cell (`card:1`) is only mounted on Collection > Squishies;
    // elsewhere the guide falls back to a banner.
    case 'play':
      if (on('toy')) return { next: 'gear' };
      if (!on('home')) return { hide: true };
      return toMittens(`Play with ${name}`, `Here’s ${name}. Tap them, then SQUISH to start playing.`);

    case 'gear':
      if (!on('toy')) return backToToy();
      if (s.settingsOpen) return { next: 'gearClose' };
      return { ui: spot('gear', 'Settings', 'First, tap the gear to open your settings.') };

    case 'gearClose':
      if (!on('toy')) return backToToy();
      if (!s.settingsOpen) return { next: 'hold' };
      return { ui: spot('gearClose', 'Sound and more', 'Sounds, vibration and poke options live here. Tap ✕ to close it.') };

    case 'hold': {
      if (!on('toy')) return backToToy();
      if (s.holdMs >= HOLD_MS) return { next: 'rotate' };
      const left = Math.ceil((HOLD_MS - s.holdMs) / 1000);
      return {
        timed: true,
        ui: spot('stage', 'Squash it!', `Press and hold ${name} with one finger.`, {
          hand: 'hold',
          radius: 28,
          pad: 0,
          place: 'bottom',
          block: false,
          progress: s.holdMs / HOLD_MS,
          note: s.holdActive ? `Keep holding… ${left}s` : 'Hold for 5 seconds',
        }),
      };
    }

    case 'rotate':
      if (!on('toy')) return backToToy();
      if (s.rotateAcc >= ROTATE_PX) return { next: 'goal' };
      return {
        ui: spot('stage', 'Spin it around', `Put two fingers on ${name} and twist to rotate.`, {
          hand: 'two',
          radius: 28,
          pad: 0,
          place: 'bottom',
          block: false,
          progress: Math.min(1, s.rotateAcc / ROTATE_PX),
        }),
      };

    case 'goal': {
      const coins = profile?.coins ?? 0;
      if (coins >= GOAL_COINS) return { next: 'back' };
      if (!on('toy')) return backToToy();
      return {
        ui: {
          mode: 'banner',
          title: `Goal: reach ${GOAL_COINS} coins`,
          text: `Squish ${name} to earn coins. Tutorial boost: ×10!`,
          progress: coins / GOAL_COINS,
          note: `${coins} / ${GOAL_COINS} coins`,
        },
      };
    }

    case 'back':
      if (on('home')) return { next: 'box2' };
      if (!on('toy')) return { hide: true };
      return { ui: spot('back', 'Goal reached!', 'Head back and spend your coins on a chest.') };

    case 'box2':
      if (on('store')) return { next: 'box2tap' };
      if (!on('home')) return { hide: true };
      return { ui: spot('store', 'Another chest', 'Your coins buy chests in the Shop. Tap here!') };

    case 'box2tap':
      if (s.boxPhase === 'reveal') return { next: 'stars' };
      if (!on('store')) return on('home') ? { ui: spot('store', 'Back to the Shop', 'Let’s buy that chest.') } : { hide: true };
      if (smashing) return { ui: spot('chestStage', 'Tap it open', 'Tap tap tap!', { radius: 40, block: false }) };
      if (s.shopSheet === 'got') return { ui: spot('openNow', 'Open it now', 'Tap OPEN NOW.') };
      return { ui: spot('buy:basic', 'A Basic chest', 'It costs 250 coins. Tap to buy it!', { radius: 999 }) };

    case 'stars':
      return {
        ui: card({
          badge: 'STARS & FINISHES',
          title: 'Stars!',
          text: 'Got a squishy you already have? It turns into Stars. Spend Stars to grow your squishies, get the ones you’re missing, or give them a Shiny or Rainbow finish. Finish a set for a bonus squishy!',
          buttons: [{ label: 'Got it', next: 'storeBack' }],
        }),
      };

    case 'storeBack':
      if (on('home')) return { next: 'mine' };
      if (!on('store')) return { hide: true };
      if (s.boxPhase === 'reveal') return { ui: spot('revealDone', 'Nice!', 'Tap here to finish.') };
      return { ui: spot('storeBack', 'Back to your squishies', 'One more thing to show you.') };

    case 'mine':
      if (!on('home')) return { hide: true };
      if (s.listTab === 'mine') return { next: 'create' };
      return { ui: spot('tabs', 'Make your own', 'Open My creations.', { handX: 0.75 }) };

    case 'create':
      if (!on('home')) return { hide: true };
      return {
        ui: spot('createCard', 'Create a creature', 'Turn any photo or drawing into your own squishy.', {
          hand: null,
          radius: 24,
          place: 'top',
          next: 'Nice!',
          onNext: 'cribBtn',
        }),
      };

    case 'cribBtn':
      if (on('crib')) return { next: CRIB_STEP };
      if (!on('home')) return { hide: true };
      return { ui: spot('crib', 'Visit the Crib', `Your squishies have a cozy home. Tap here to go see ${name}.`) };

    // --- the Crib (the design's Squad Crib tutSync), drawn by the Crib's own
    // guide: the welcome card, tap the starter, send it for a snack, level
    // 3 and the daily challenges, a last card. The Crib reports cribSel /
    // cribPet0 / dailyOpen and keeps the living room on for the first steps.
    case 'crib':
      if (on('home')) return { ui: spot('crib', 'Visit the Crib', `Your squishies have a cozy home. Tap here to go see ${name}.`) };
      if (!on('crib')) return { hide: true };
      return {
        ui: card({
          width: 400,
          badge: 'THE CRIB',
          title: 'Welcome home!',
          text: 'This is where your squishies live. How they feel decides how many coins they make.',
          items: [
            { icon: '+', color: '#7fae6a', title: 'Happy friends earn more', desc: 'The happier a creature is, the more coins it makes every second.' },
            { icon: '–', color: '#f2665a', title: 'Sad or grumpy friends cost you', desc: 'Unhappy creatures earn less, and can even take coins away.' },
            { icon: '♥', color: '#5fb6dc', title: 'Keep them happy', desc: 'Baths, snacks, sleep and play keep their stats up.' },
          ],
          buttons: [{ label: 'Let’s go', next: 'c_tap' }],
        }),
      };

    case 'c_tap':
      if (on('home')) return { ui: spot('crib', 'Back to the Crib', `${starter} is waiting for you.`) };
      if (!on('crib')) return { hide: true };
      if (s.cribSel === '0') return { next: 'c_feed' };
      return { ui: spot('cr:0', `${starter} is in the Living Room`, 'Tap them to see how they’re feeling.', { pad: 4 }) };

    case 'c_feed':
      if (on('home')) return { ui: spot('crib', 'Back to the Crib', `${starter} is hungry!`) };
      if (!on('crib')) return { hide: true };
      if (s.cribPet0 && s.cribPet0.act === 'eat') return { next: 'c_lvl3' };
      if (s.cribSel !== '0') return { next: 'c_tap' };
      return { ui: spot('act-eat', 'They’re hungry!', 'Their Tummy is low. Tap Snack to send them to the kitchen.', { radius: 14, place: 'top', width: 260 }) };

    case 'c_lvl3':
      // once the starter has landed in the kitchen (after a restart it's
      // back home and hungry: feed it again first)
      if (!on('crib') || !s.cribPet0) return { hide: true };
      if (s.cribPet0.act !== 'eat') return { next: 'c_feed' };
      if (!s.cribPet0.live) return { hide: true };
      return {
        level: 3,
        ui: card({
          level: 3,
          title: 'You reached level 3!',
          text: `${starter} is happily munching. You just unlocked Daily Challenges.`,
          buttons: [{ label: 'Show me', next: 'c_daily' }],
        }),
      };

    case 'c_daily':
      // the Crib opens its daily panel for this step; the card goes over it
      if (!on('crib') || !s.dailyOpen) return { hide: true };
      return {
        ui: card({
          width: 420,
          badge: 'DAILY STREAK',
          title: 'New challenges every day',
          text: 'Finish them in the Crib and in the squish game.',
          items: [
            { icon: '✓', color: '#f2b84a', title: 'Claim all six for the chest', desc: 'Coins, Stars and your streak reward, every day you finish them all.' },
            { icon: '%', color: '#7fae6a', title: '10 days of streak rewards', desc: 'Coins, Stars, free chests, +5% squish coins a day — and on day 10, half price on a new creature.' },
            { icon: '!', color: '#f2665a', title: 'Miss a day, lose the streak', desc: 'Your streak goes back to day 1.' },
          ],
          buttons: [{ label: 'Got it', next: 'c_offers' }],
        }),
      };

    case 'c_offers':
      if (!on('crib')) return { hide: true };
      return {
        ui: card({
          width: 420,
          badge: 'ALL SET',
          title: 'Make it even squishier',
          text: 'You’re all set! A few more things to know:',
          items: [
            { icon: '★', color: '#f2b84a', title: 'Chests bring new squishies', desc: 'Free ones every day, more in the Shop. Grow them with Stars in the Star Shop.' },
            { icon: '✦', color: '#9b84d8', title: 'Create your own', desc: 'Turn a photo or a drawing into a squishy in Collection > My creations.' },
            { icon: '×', color: '#f2665a', title: 'Remove ads', desc: 'A one-time purchase in Settings. No more ads, ever.' },
          ],
          buttons: [{ label: 'Start playing', next: 'done' }],
        }),
      };

    default:
      return { hide: true };
  }
}
