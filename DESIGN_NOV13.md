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

## Screenshots

`design-screens/` has what each screen looks like (main menu, mini games page, house, all creatures, picker, shop, chests,
yard games). To take fresh ones after a change (works in a cloud session too, where unpkg.com may be blocked):

    cd tools/design-shots
    npm i --no-save playwright react@18.3.1 react-dom@18.3.1 @babel/standalone@7.29.0 three@0.128.0
    npx playwright install chromium          # only if Chromium is not there yet
    node shoot.js ../design-nov13/squish-squad ./out                 # every screen -> out/*.png
    node shoot.js ../design-nov13/squish-squad ./out "Main Menu.dc.html"   # one page

To show them in a cloud session, commit the pictures and push, then open them on GitHub.
