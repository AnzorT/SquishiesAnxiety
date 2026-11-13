// The new design (webgame/: the Nov 13 prototype's Main Menu and Squad House v6) replaces the app's Home and Crib.
// false = the app as it was before (classic Home + Crib), e.g. to compare.
export const NEW_DESIGN = true;

// The guided tutorial still points at the classic Home and Crib (src/tutorial/steps.js), so while a player is in it
// they stay on those; the new design takes over when it's done. true = the new design even during the tutorial
// (its coach marks will wait for screens that aren't there).
export const NEW_DESIGN_DURING_TUTORIAL = false;
