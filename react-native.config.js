// react-native-iap is the App Store side of in-app purchases (src/billing/
// index.ios.js). Android uses the app's own Google Play Billing 8 module
// instead (react-native-iap 12 ships Billing 7, which Google Play no longer
// accepts for app updates), so keep it out of the Android build.
module.exports = {
  dependencies: {
    'react-native-iap': {
      platforms: {
        android: null,
      },
    },
  },
};
