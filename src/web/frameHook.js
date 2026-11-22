// Web only: the line put first in the <head> of every page the app opens from its APK (file:///android_asset/…):
// it hands the page's window to the app's web WebView (src/web/WebView.js window.__rnwFrame) before the page's own
// scripts run. Metro adds it as it serves the pages (metro.config.js); the hosted build writes it into them
// (tools/web/host.mjs).
module.exports = '<script>(function(){try{var p=window.parent,f=window.frameElement;if(f&&p!==window&&p.__rnwFrame)p.__rnwFrame(window,f)}catch(e){}})();</script>';
