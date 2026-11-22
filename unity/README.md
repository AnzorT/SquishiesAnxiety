# PlushCrush in Unity

The Unity version of the game, being rebuilt screen by screen to match the React Native app 1:1.
Plan, decisions and progress: [`PORT_PLAN.md`](PORT_PLAN.md).

## Opening it

1. Install **Unity 6000.3** in Unity Hub, with **Android Build Support** (and iOS if you build for iPhone).
2. Make the creature art (it isn't in git because it's large; this rebuilds it exactly), from the repo's root folder:
   ```bash
   npm install
   npx playwright install chromium
   node webgame/build.mjs --out webgame/test/out/webgame
   node tools/unity-port/export-art.mjs
   ```
3. Unity Hub → **Add** → **Add project from disk** → pick this `unity` folder. Open it.
4. On first open the project sets itself up (menu **PlushCrush > Setup** to run it again):
   - installs URP, the Input System, glTFast and the Test Framework (watch the progress bar);
   - Unity may ask to restart for the Input System: say **Yes**;
   - applies the player settings (app id `com.plushcrush.app`, landscape, Android 64-bit) and creates
     `Assets/_Project/Scenes/Main.unity`;
   - makes URP the render pipeline once it's installed.
5. In the **Game** view, add a resolution of **2340 × 1080** (the Galaxy A15) and pick it.
6. Open `Assets/_Project/Scenes/Main.unity` and press **Play**. The first screen is a setup check: every dot should
   be green. Send a screenshot of it, plus anything red in the Console.

## Checking a screen against the original

Press Play, open **PlushCrush > Reference Overlay**, tick **Show overlay** and pick a screenshot. It's laid over the
game, half see-through; move the opacity slider to compare.

## Layout

```
Assets/_Project/
  Scripts/Core/     plain game logic and data, ported from src/*.js (no UI)
  Scripts/App/      the app: AppRoot (like App.js), the screen router, screens, fonts
  Editor/           first-open setup, URP setup, the Reference Overlay window
  Resources/        fonts, the UI theme
  Reference/        screenshots of the real game, for checking (not shipped)
  Art/Generated/    art exported from the game by tools/unity-port (not in git)
```
