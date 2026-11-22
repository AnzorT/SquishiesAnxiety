// A release APK in developer mode (src/webDebug.js DEV_MODE): plays like a release build, but new email accounts skip
// the verify step, so test accounts can use made-up addresses. Never upload it: android/app/build.gradle refuses to
// make a Play Store AAB with the switch on, and a normal `gradlew assembleRelease` (no switch) is a store-like APK.
//
//   npm run android:dev-apk                         build android/app/build/outputs/apk/release/app-release.apk
//   npm run android:dev-apk -- --install            ... and install it on the connected phone (ANDROID_SERIAL picks one)
//   npm run android:dev-apk -- --install -PreactNativeArchitectures=arm64-v8a    (faster: only a real phone's CPU)
//
// Any other argument goes to gradle as it is.
import { spawnSync } from 'node:child_process';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const root = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const args = process.argv.slice(2);
const install = args.includes('--install');
const gradleArgs = args.filter((a) => a !== '--install');
const env = { ...process.env, EXPO_PUBLIC_DEV_MODE: '1' };

const run = (cmd, cmdArgs, cwd) => {
  console.log(`> ${cmd} ${cmdArgs.join(' ')}`);
  const r = spawnSync(cmd, cmdArgs, { cwd, env, stdio: 'inherit', shell: process.platform === 'win32' });
  if (r.status !== 0) process.exit(r.status ?? 1);
};

// by its full path: cmd doesn't always look in the current folder (NoDefaultCurrentDirectoryInExePath); quoted for
// the spaces in the project path
const win = process.platform === 'win32';
const gradlew = win ? `"${path.join(root, 'android', 'gradlew.bat')}"` : path.join(root, 'android', 'gradlew');
run(gradlew, ['assembleRelease', ...gradleArgs], path.join(root, 'android'));

const apk = path.join(root, 'android/app/build/outputs/apk/release/app-release.apk');
console.log(`\nDeveloper-mode APK: ${apk}`);
if (install) run('adb', ['install', '-r', win ? `"${apk}"` : apk], root);
