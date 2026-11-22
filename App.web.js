// The web version's start (npm run web; src/web/README.md). Expo's entry imports ./App, and on web Metro picks this
// file first. On a computer it shows the phone frame (src/web/PhoneFrame.js), which runs the app inside it at phone
// size; inside the frame (or on a phone's browser) it's the app itself, after the web stand-ins (src/web/setup.js).
import { wantsFrame } from './src/web/PhoneFrame';

let Root;
if (wantsFrame()) {
  Root = require('./src/web/PhoneFrame').default;
} else if (__DEV__ && /[?&]preview=1/.test(window.location.search)) {
  // the games' popups on their own (src/web/Preview.js)
  require('./src/web/setup');
  Root = require('./src/web/Preview').default;
} else {
  require('./src/web/setup');
  Root = require('./App.js').default;
}

export default Root;
