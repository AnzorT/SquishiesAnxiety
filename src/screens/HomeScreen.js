import React, { useCallback, useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Pressable, ActivityIndicator, Animated, Easing, Dimensions } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { spacing } from '../theme/tokens';
import { squadColors, squadGradients, squadFonts } from '../theme/squadTheme';
import CreatureCard from '../components/CreatureCard';
import AdBanner from '../components/AdBanner';
import IconButton from '../components/squad/IconButton';
import SettingsSheet from './SettingsSheet';

// Home Screen — a vertical creature carousel. Every creature card lives in one
// tall strip that slides on `index` change (the swipe animation); the focused
// card sits centred in the viewport with ~half of each neighbour peeking above
// and below. The two nav arrows overlay the FOCUSED card, straddling its top
// and bottom edge — the up arrow only when there's a card above (index > 0),
// the down arrow only when there's one below (index < n-1). The card itself
// (image area / lock states / info area / hold-to-unlock) lives in CreatureCard.

const CARD_GAP = 18;
const EDGE_PAD = 14; // keeps the first / last card off the viewport edge
const ARROW_H = 34;
const WINDOW_H = Dimensions.get('window').height;

const clampN = (v, lo, hi) => Math.max(lo, Math.min(hi, v));

// Card height for a given viewport: focused card full, ~half of each neighbour.
function carouselGeo(vpH) {
  const cardH = Math.max(150, (vpH - CARD_GAP * 2) / 2.1);
  return { cardH, step: cardH + CARD_GAP };
}

function ArrowButton({ direction, onPress, style }) {
  const isUp = direction === 'up';
  return (
    <Pressable style={[styles.arrowButton, style]} onPress={onPress} hitSlop={12}>
      <View style={isUp ? styles.triangleUp : styles.triangleDown} />
    </Pressable>
  );
}

export default function HomeScreen({
  creatures = [],
  ownedIds = [],
  keys = {},
  coins = 0,
  index,
  onChangeIndex,
  onSelectToy,
  onUnlockWithKey,
  nickname,
  onSaveNickname,
  adsFree,
  onClaimAdsFree,
  totalEarned,
  stats,
  favoriteCreatureName,
  onSubmitFeedback,
  onLogout,
  onOpenAchievements,
  onOpenStore,
}) {
  const insets = useSafeAreaInsets();
  const [settingsOpen, setSettingsOpen] = useState(false);
  const [viewportH, setViewportH] = useState(0);

  const safeIndex = creatures.length ? Math.min(Math.max(index ?? 0, 0), creatures.length - 1) : 0;

  const goTo = useCallback(
    (next) => {
      if (!creatures.length) return;
      const clamped = Math.min(Math.max(next, 0), creatures.length - 1);
      if (clamped !== safeIndex) onChangeIndex(clamped);
    },
    [creatures.length, safeIndex, onChangeIndex]
  );

  const ownedCount = creatures.filter((c) => ownedIds.includes(c.id)).length;

  // Carousel geometry. Until the viewport has been measured we fall back to a
  // sensible fraction of the window so the very first paint is close.
  const count = creatures.length;
  const vpH = viewportH || Math.round(WINDOW_H * 0.58);
  const { cardH, step } = carouselGeo(vpH);

  // Centre the focused card, but clamp so the first / last card hugs the
  // viewport edge instead of leaving a big empty band.
  const maxY = EDGE_PAD;
  const minY = Math.min(maxY, vpH - EDGE_PAD - ((count - 1) * step + cardH));
  const targetY = clampN(vpH / 2 - cardH / 2 - safeIndex * step, minY, maxY);

  // The arrows overlay the focused card, straddling its top / bottom edge.
  const focusedTop = targetY + safeIndex * step;
  const upArrowTop = focusedTop - ARROW_H / 2;
  const downArrowTop = focusedTop + cardH - ARROW_H / 2;

  const slide = useRef(new Animated.Value(0)).current;
  const prevIndexRef = useRef(safeIndex);
  useEffect(() => {
    const indexChanged = prevIndexRef.current !== safeIndex;
    prevIndexRef.current = safeIndex;
    if (indexChanged && viewportH > 0) {
      Animated.timing(slide, {
        toValue: targetY,
        duration: 360,
        easing: Easing.out(Easing.cubic),
        useNativeDriver: true,
      }).start();
    } else {
      // first mount / viewport just measured — snap into place, no animation
      slide.setValue(targetY);
    }
  }, [safeIndex, targetY, viewportH, slide]);

  const onViewportLayout = useCallback(
    (e) => {
      const h = Math.round(e.nativeEvent.layout.height);
      if (h <= 0 || h === viewportH) return;
      // Position the strip for this exact height before the first paint that
      // shows it, so it doesn't visibly jump from the window-fraction guess.
      const g = carouselGeo(h);
      const mY = EDGE_PAD;
      const nY = Math.min(mY, h - EDGE_PAD - ((count - 1) * g.step + g.cardH));
      slide.setValue(clampN(h / 2 - g.cardH / 2 - safeIndex * g.step, nY, mY));
      setViewportH(h);
    },
    [viewportH, safeIndex, slide, count]
  );

  if (!creatures.length) {
    return (
      <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={[styles.centered, { paddingTop: insets.top, paddingBottom: insets.bottom }]}>
        <ActivityIndicator color={squadColors.pinkLight} />
        <Text style={styles.loadingText}>Loading your shelf…</Text>
      </LinearGradient>
    );
  }

  return (
    <LinearGradient colors={squadGradients.homeBg.colors} start={squadGradients.homeBg.start} end={squadGradients.homeBg.end} style={styles.container}>
      <View style={[styles.content, { paddingTop: insets.top }]}>
        <View style={styles.header}>
          <View>
            <Text style={styles.nickname}>{nickname}</Text>
            <View style={styles.pillsRow}>
              <View style={styles.pill}>
                <LinearGradient
                  colors={squadGradients.goldDot.colors}
                  start={squadGradients.goldDot.start}
                  end={squadGradients.goldDot.end}
                  style={styles.coinDot}
                />
                <Text style={styles.coinText}>{coins}</Text>
              </View>
            </View>
          </View>
          <View style={styles.headerIcons}>
            <IconButton name="emoji-events" onPress={onOpenAchievements} />
            <IconButton name="storefront" onPress={onOpenStore} />
            <IconButton name="settings" onPress={() => setSettingsOpen(true)} />
          </View>
        </View>

        <View style={styles.stage}>
          <View style={styles.viewport} onLayout={onViewportLayout}>
            {viewportH > 0 && (
              <>
                <Animated.View style={[styles.strip, { transform: [{ translateY: slide }] }]}>
                  {creatures.map((c, i) => (
                    <View key={c.id} style={[styles.cardSlot, { height: cardH, marginBottom: CARD_GAP }]}>
                      <CreatureCard
                        creature={c}
                        unlocked={ownedIds.includes(c.id)}
                        hasKey={!!keys[c.id]}
                        dimmed={i !== safeIndex}
                        onFocus={() => goTo(i)}
                        onSelectToy={onSelectToy}
                        onOpenStore={onOpenStore}
                        onUnlockWithKey={onUnlockWithKey}
                      />
                    </View>
                  ))}
                </Animated.View>

                {safeIndex > 0 && (
                  <ArrowButton
                    direction="up"
                    style={[styles.arrowOnCard, { top: upArrowTop }]}
                    onPress={() => goTo(safeIndex - 1)}
                  />
                )}
                {safeIndex < count - 1 && (
                  <ArrowButton
                    direction="down"
                    style={[styles.arrowOnCard, { top: downArrowTop }]}
                    onPress={() => goTo(safeIndex + 1)}
                  />
                )}
              </>
            )}
          </View>

          <View style={styles.adSection}>
            <AdBanner />
          </View>
        </View>
      </View>

      <SettingsSheet
        visible={settingsOpen}
        onClose={() => setSettingsOpen(false)}
        nickname={nickname}
        onSaveNickname={onSaveNickname}
        adsFree={adsFree}
        onClaimAdsFree={onClaimAdsFree}
        onSubmitFeedback={onSubmitFeedback}
        onLogout={onLogout}
        ownedCount={ownedCount}
        totalCount={creatures.length}
        totalEarned={totalEarned}
        coins={coins}
        stats={stats}
        favoriteCreatureName={favoriteCreatureName}
      />
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  content: { flex: 1 },
  centered: { flex: 1, alignItems: 'center', justifyContent: 'center' },
  loadingText: { marginTop: spacing(3), color: squadColors.textLavender, fontSize: 13, fontFamily: squadFonts.bodyBold },

  header: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingTop: 14,
    paddingHorizontal: 16,
    paddingBottom: 10,
    flexShrink: 0,
  },
  nickname: { fontFamily: squadFonts.headingExtraBold, fontWeight: '800', color: squadColors.textWhite, fontSize: 17 },
  pillsRow: { flexDirection: 'row', gap: 8, marginTop: 5 },
  pill: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 5,
    backgroundColor: squadColors.panel,
    borderWidth: 1,
    borderColor: squadColors.panelBorder,
    borderRadius: 999,
    paddingHorizontal: 10,
    paddingVertical: 4,
  },
  coinDot: {
    width: 14,
    height: 14,
    borderRadius: 7,
    shadowColor: squadColors.goldAmber,
    shadowOpacity: 0.7,
    shadowRadius: 6,
    shadowOffset: { width: 0, height: 0 },
  },
  coinText: { color: squadColors.gold, fontFamily: squadFonts.bodyExtraBold, fontWeight: '800', fontSize: 13 },
  headerIcons: { flexDirection: 'row', gap: 8 },

  stage: { flex: 1, flexDirection: 'column', minHeight: 0 },
  viewport: { flex: 1, overflow: 'hidden', minHeight: 0, position: 'relative' },
  strip: { position: 'absolute', left: 0, right: 0, top: 0 },
  cardSlot: { width: '100%', alignItems: 'center' },
  adSection: { height: 66, alignItems: 'center', justifyContent: 'center', paddingBottom: 8, flexShrink: 0 },

  arrowButton: { width: 64, height: ARROW_H, alignItems: 'center', justifyContent: 'center' },
  arrowOnCard: { position: 'absolute', left: '50%', marginLeft: -32, zIndex: 5 },
  triangleUp: {
    width: 0,
    height: 0,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderLeftWidth: 14,
    borderRightWidth: 14,
    borderBottomWidth: 20,
    borderLeftColor: 'transparent',
    borderRightColor: 'transparent',
    borderBottomColor: squadColors.pinkLight,
  },
  triangleDown: {
    width: 0,
    height: 0,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderLeftWidth: 14,
    borderRightWidth: 14,
    borderTopWidth: 20,
    borderLeftColor: 'transparent',
    borderRightColor: 'transparent',
    borderTopColor: squadColors.pinkLight,
  },
});
