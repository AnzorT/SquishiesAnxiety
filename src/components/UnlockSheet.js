import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, LinearGradient as SvgGradient, Stop, Path } from 'react-native-svg';
import { BUTTON_VARIANTS, candyColors, candyFonts, tierOf } from '../theme/candyTheme';
import { tokenCount, tokenPrice } from '../economy';
import CandyPopup from './candy/CandyPopup';
import CandyButton, { ButtonText } from './candy/CandyButton';
import OutlinedTitle from './candy/OutlinedTitle';
import CreatureToken from './candy/Tokens';
import CreatureThumbnail from './CreatureThumbnail';
import { BagIcon } from './candy/RoundButton';
import { RaysSpin, TierChip } from './candy/Decor';

// Tapping a locked creature: a short popup that says it's unlocked in the
// Shop, lists the two ways in one line each — its own tokens (so far / its
// price, from Mystery Boxes), or $0.99 — and a SHOP button with
// the Shop's bag icon, which opens the Key Shop on that creature's row. The
// buying happens there. Once a key is waiting it says so instead: hold the
// card on Home to unlock.

export function Gem({ size = 30 }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 30 30">
      <Defs>
        <SvgGradient id="gemFace" x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#d9fbff" />
          <Stop offset="0.5" stopColor="#5fd8f7" />
          <Stop offset="1" stopColor="#1a86d0" />
        </SvgGradient>
      </Defs>
      <Path d="M8 4 H22 L28 11 L15 27 L2 11 Z" fill="#0c5a9c" transform="translate(0,1.5)" />
      <Path d="M8 4 H22 L28 11 L15 27 L2 11 Z" fill="url(#gemFace)" stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" />
      <Path d="M2 11 H28 M8 4 L11 11 L15 27 M22 4 L19 11 L15 27" stroke="#ffffff" strokeOpacity={0.75} strokeWidth={1.2} fill="none" />
    </Svg>
  );
}

function Way({ icon, children, last }) {
  return (
    <View style={[styles.way, !last && styles.wayLine]}>
      <View style={styles.wayIcon}>{icon}</View>
      <View style={styles.wayText}>{children}</View>
    </View>
  );
}

export default function UnlockSheet({ creature, profile, moneyPrice, onClose, onOpenShop }) {
  if (!creature) return <CandyPopup visible={false} onClose={onClose} />;
  const id = creature.id;
  const tier = tierOf(id);
  const keyed = profile?.keys?.[id] === true;
  const need = tokenPrice(id);
  const have = tokenCount(profile, id);
  const pink = BUTTON_VARIANTS.pink;

  return (
    <CandyPopup visible onClose={onClose} maxWidth={330}>
      <View style={styles.hero}>
        <View style={styles.rays} pointerEvents="none">
          <RaysSpin size={210} opacity={0.55} color="#ff9fd6" style={styles.raysAt} />
        </View>
        <CreatureThumbnail creature={creature} size={92} locked={!keyed} mood={keyed ? 'ready' : 'sleep'} />
      </View>
      <View style={styles.nameRow}>
        <OutlinedTitle text={creature.name} fill="pink" size={24} />
        {tier ? <TierChip tier={tier} fontSize={10} /> : null}
      </View>

      {keyed ? (
        <>
          <OutlinedTitle text="KEY READY!" fill="gold" size={26} style={styles.readyTitle} />
          <Text style={styles.lead}>Hold its card on Home to unlock it.</Text>
          <CandyButton label="GOT IT" variant="blue" size="md" onPress={onClose} style={styles.cta} />
        </>
      ) : (
        <>
          <Text style={styles.lead}>Unlock it in the Shop:</Text>
          <View style={styles.ways}>
            <Way icon={<CreatureToken creature={creature} size={26} />}>
              <Text style={styles.count}>{`${have.toLocaleString()}/${need.toLocaleString()}`}</Text>
              <Text style={styles.wayLabel}>tokens</Text>
              <Text style={styles.have}>· from Mystery Boxes</Text>
            </Way>
            <Way icon={<Gem size={22} />} last>
              <Text style={styles.wayLabel}>Unlock now</Text>
              <Text style={styles.money}>{moneyPrice}</Text>
            </Way>
          </View>
          <CandyButton variant="pink" size="md" pulse="soft" onPress={() => onOpenShop(creature)} style={styles.cta}>
            <View style={styles.ctaRow}>
              <BagIcon size={22} />
              <ButtonText ring={pink.ring} size={17}>
                SHOP
              </ButtonText>
            </View>
          </CandyButton>
        </>
      )}
    </CandyPopup>
  );
}

const styles = StyleSheet.create({
  hero: { width: 120, height: 100, alignItems: 'center', justifyContent: 'center' },
  rays: { position: 'absolute', left: 60, top: 50 },
  raysAt: { left: -105, top: -105 },
  nameRow: { flexDirection: 'row', alignItems: 'center', gap: 6, marginTop: -2 },
  readyTitle: { marginTop: 8 },
  lead: {
    color: candyColors.ink,
    fontFamily: candyFonts.display,
    fontSize: 15,
    textAlign: 'center',
    marginTop: 6,
    marginBottom: 8,
  },
  ways: {
    alignSelf: 'stretch',
    backgroundColor: '#ffffff',
    borderRadius: 16,
    borderWidth: 1.5,
    borderColor: '#ecd9fb',
    paddingHorizontal: 12,
    marginBottom: 12,
  },
  way: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingVertical: 8 },
  wayLine: { borderBottomWidth: 1, borderBottomColor: '#f3e6fb' },
  wayIcon: { width: 44, alignItems: 'center' },
  wayText: { flex: 1, flexDirection: 'row', alignItems: 'center', gap: 5 },
  wayLabel: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyHeavy, fontSize: 12.5 },
  count: { color: '#d3179a', fontFamily: candyFonts.display, fontSize: 14 },
  have: { color: candyColors.mutedLight, fontFamily: candyFonts.bodyHeavy, fontSize: 11 },
  money: { color: '#1695d6', fontFamily: candyFonts.display, fontSize: 14 },
  cta: { alignSelf: 'stretch' },
  ctaRow: { flexDirection: 'row', alignItems: 'center', gap: 8 },
});
