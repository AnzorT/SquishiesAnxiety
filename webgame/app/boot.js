// Loaded first by every page of the in-app game (before support.js). Plain ES2017, no build step.
// 0. Scripts run in the order the designer listed them. support.js adds each page's <helmet> scripts to <head> one
//    by one; a script added that way runs as soon as it arrives, so the order depended on loading speed (e.g. the
//    order of the mini games, which register as their scripts run). async=false makes them run in the listed order.
(function () {
  var append = Node.prototype.appendChild;
  Node.prototype.appendChild = function (el) {
    if (this === document.head && el && el.tagName === 'SCRIPT' && el.src && !el.hasAttribute('async')) el.async = false;
    return append.call(this, el);
  };
})();
// 1. fetch() for files next to the page. The app loads the game from file:// (Android: file:///android_asset/webgame/,
//    iOS: the app bundle). Chrome's and Safari's fetch() refuse file: URLs, but the design runtime (support.js) fetches
//    the pages it embeds (dc-import) and the house fetches its catalog CSV. XMLHttpRequest may read them (the WebView
//    allows file access), so file: fetches go through XHR. Over http(s) (tests, a dev server) nothing changes.
(function () {
  if (location.protocol !== 'file:' || !window.fetch) return;
  var nativeFetch = window.fetch.bind(window);
  var TYPES = { html: 'text/html', js: 'text/javascript', json: 'application/json', csv: 'text/csv', svg: 'image/svg+xml', css: 'text/css',
    png: 'image/png', jpg: 'image/jpeg', webp: 'image/webp', wav: 'audio/wav', mp3: 'audio/mpeg', txt: 'text/plain' };
  window.fetch = function (input, init) {
    var raw = typeof input === 'string' ? input : input && input.url;
    var url;
    try { url = new URL(raw, location.href); } catch (e) { return nativeFetch(input, init); }
    if (url.protocol !== 'file:') return nativeFetch(input, init);
    return new Promise(function (resolve, reject) {
      var x = new XMLHttpRequest();
      x.open('GET', url.href);
      x.responseType = 'arraybuffer';
      x.onload = function () {
        // file: XHR reports status 0 on success
        var ok = x.status === 0 || (x.status >= 200 && x.status < 300);
        var ext = (url.pathname.split('.').pop() || '').toLowerCase();
        resolve(new Response(ok ? x.response : null, { status: ok ? 200 : x.status, headers: { 'Content-Type': TYPES[ext] || 'application/octet-stream' } }));
      };
      x.onerror = function () { resolve(new Response(null, { status: 404, statusText: 'Not Found' })); };
      x.send();
    });
  };
})();
