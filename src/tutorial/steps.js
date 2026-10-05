// The guided tutorial (the 2026-10-03 design's tutSync in "ASMR Creature
// Squash v3.dc.html"), on this app's own economy: the first box fills
// Mittens' tokens (its key), the card is held to unlock, box 2 is paid with
// the 500 coins earned in the goal step, and the design's "duplicate →
// token, watch a video to double it" became a card about creature tokens
// (there are no duplicates and no shared tokens here).
//
// `tut` on the profile is the current step; 'done' ends it. Each step says
// what the Guide shows (`ui`) and when to move on (`next`), from the store's
// view of the app (store.js) and the profile. App.js runs `stepView` on
// every change (and on a tick for the timed steps) and writes the step.

import { tokenPrice } from '../economy';

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
  const hasKey = !!profile?.keys?.['1'];
  // a squish-screen step while the player is back on Home: point at the card
  const backToToy = () => (on('home') ? { ui: spot('card:1', `Back to ${name}`, 'Tap the card to keep playing.', { radius: 24, place: 'top' }) } : { hide: true });
  // a box step while the player is back on Home: point at the box
  const backToBox = () => (on('home') ? { ui: spot('box', 'Back to the box', 'Tap here to open it.') } : { hide: true });

  switch (tut) {
    case 'start':
      if (on('home')) return { next: 'box1' };
      return { hide: true };

    case 'box1':
      if (on('box')) return { next: 'box1tap' };
      if (!on('home')) return { hide: true };
      // the first box is already open (a replay): straight on
      if (owned.includes('1') || hasKey) return { next: 'card' };
      return { ui: spot('box', 'Your first Mystery Box!', 'Every squishy friend hatches from a box. Tap here to open yours.') };

    case 'box1tap':
      if (s.boxPhase === 'reveal') return { next: 'lvl2' };
      if (!on('box')) return backToBox();
      if (!s.boxPaid) return { ui: spot('boxPay', 'Open it', 'This box needs paying for first — tap here.') };
      return { ui: spot('boxTap', 'Tap tap tap!', 'Tap the box 10 times to crack it open. This first one is on us.', { radius: 40 }) };

    case 'lvl2':
      return {
        level: 2,
        ui: card({
          level: 2,
          title: 'You reached level 2!',
          text: `You got ${name}' key — your very first squishy friend.`,
          buttons: [{ label: 'Yay!', next: 'reveal' }],
        }),
      };

    case 'reveal':
      if (on('home')) return { next: 'card' };
      if (!on('box')) return { hide: true };
      return { ui: spot('revealUnlock', `Meet ${name}`, `Let’s go and unlock ${name} — tap here.`) };

    // The card target is `card:<id>`: only a mounted card registers, so when
    // the player pages away the guide falls back to a banner until Mittens'
    // card is back in view.
    case 'card':
      if (owned.includes('1')) return { next: 'play' };
      if (!on('home')) return { hide: true };
      if (s.listTab !== 'ours') return { ui: spot('tabs', 'Your creature list', 'Open the OUR CREATURES tab.', { handX: 0.25 }) };
      return { ui: spot('card:1', 'Unlock it!', `Press and hold ${name}'s card until the key turns.`, { hand: 'hold', radius: 24, place: 'top' }) };

    case 'play':
      if (on('toy')) return { next: 'gear' };
      if (!on('home')) return { hide: true };
      return { ui: spot('card:1', `Play with ${name}`, `Find ${name} in your list and tap the card to start playing.`, { radius: 24, place: 'top' }) };

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
      return { ui: spot('back', 'Goal reached!', 'Head back and spend your coins on another Mystery Box.') };

    case 'box2':
      if (on('box')) return { next: 'box2tap' };
      if (!on('home')) return { hide: true };
      return { ui: spot('box', 'Another box', `This one costs ${GOAL_COINS} coins. Let’s open it!`) };

    case 'box2tap':
      if (s.boxPhase === 'reveal') return { next: 'tokens' };
      if (!on('box')) return backToBox();
      if (!s.boxPaid) return { ui: spot('boxPay', 'Pay with coins', `Your ${GOAL_COINS} coins pay for this box — tap OPEN.`) };
      return { ui: spot('boxTap', 'Tap 10 times', 'Tap it open!', { radius: 40 }) };

    case 'tokens': {
      // the cheapest creature still to unlock (roster order = price order)
      const next = creatures.find((c) => /^\d+$/.test(c.id) && c.id !== '0' && !owned.includes(c.id) && !profile?.keys?.[c.id]);
      const need = next ? tokenPrice(next.id) : 35;
      return {
        ui: card({
          badge: 'CREATURE TOKENS',
          title: 'Tokens!',
          text: `Every box gives tokens of one creature. Fill a creature's set — ${need} for ${next ? next.name : 'the next one'} — and its key is yours. The daily chest gives tokens too.`,
          buttons: [{ label: 'Got it', next: 'store' }],
        }),
      };
    }

    case 'store':
      if (on('store')) return { next: 'storeInfo' };
      if (on('box')) return { ui: spot('boxBack', 'Back home', 'Head back — the shop is next.') };
      if (!on('home')) return { hide: true };
      return { ui: spot('store', 'The shop', 'Tap here to see how you unlock more creatures.') };

    case 'storeInfo':
      if (on('home')) return { ui: spot('store', 'The shop', 'Tap here to see how you unlock more creatures.') };
      if (!on('store')) return { hide: true };
      return {
        ui: spot('key', 'Keys unlock creatures', 'Fill a creature’s tokens from Mystery Boxes, or buy its key right away.', {
          hand: null,
          radius: 16,
          next: 'Got it',
          onNext: 'storeBack',
        }),
      };

    case 'storeBack':
      if (on('home')) return { next: 'mine' };
      if (!on('store')) return { hide: true };
      return { ui: spot('storeBack', 'Back to your list', 'One more thing to show you.') };

    case 'mine':
      if (!on('home')) return { hide: true };
      if (s.listTab === 'mine') return { next: 'create' };
      return { ui: spot('tabs', 'Make your own', 'Open the MY CREATURES tab.', { handX: 0.75 }) };

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
            { icon: '✓', color: '#f2b84a', title: 'Claim all six for the chest', desc: 'Coins, a creature token and your streak reward, every day you finish them all.' },
            { icon: '%', color: '#7fae6a', title: '10 days of streak rewards', desc: 'Coins, tokens, free boxes, +5% squish coins a day — and on day 10, half price on a new creature.' },
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
            { icon: '★', color: '#f2b84a', title: 'Keys unlock creatures', desc: 'Fill their tokens from Mystery Boxes, or buy a key in the shop.' },
            { icon: '✦', color: '#9b84d8', title: 'Create your own', desc: 'Turn a photo or a drawing into a squishy on the MY CREATURES tab.' },
            { icon: '×', color: '#f2665a', title: 'Remove ads', desc: 'A one-time purchase in Settings. No more ads, ever.' },
          ],
          buttons: [{ label: 'Start playing', next: 'done' }],
        }),
      };

    default:
      return { hide: true };
  }
}
