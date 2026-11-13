# Squish Squad design prototype, Nov 13 2026

`Squish Squad Prototype Nov13.zip` is the latest playable design prototype (it replaces the older
`ASMR Creature Squash Game.zip` as the reference): the new landscape main menu (creature in front of the house,
mini games page, walk-into-the-house animation), the house (Squad House v6), all 118 creatures with their
animations, the v6 cards (bigger picture, smaller name board), the yard mini games, shop and chests, plus all art and sounds.

Extract it:

    python -m zipfile -e "Squish Squad Prototype Nov13.zip" tools/design-nov13

Then read `tools/design-nov13/squish-squad/CLAUDE.md` first: how the prototype pages work, which file does what,
what is new and what is still open. To see it running: `cd tools/design-nov13/squish-squad && python3 -m http.server 8000`
and open http://localhost:8000/Main%20Menu.dc.html (needs internet for React/three.js/fonts from the CDNs).
