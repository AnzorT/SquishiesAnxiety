// Module resolution for running the app's src/ in Node (see register.mjs).
const SHIMS = {
  '@react-native-firebase/firestore': './shims/firestore.mjs',
  '@react-native-firebase/app': './shims/app.mjs',
  '@react-native-firebase/auth': './shims/auth.mjs',
};

export async function resolve(specifier, context, next) {
  if (SHIMS[specifier]) return { url: new URL(SHIMS[specifier], import.meta.url).href, shortCircuit: true };
  try {
    return await next(specifier, context);
  } catch (e) {
    // the app's `import … from '../progression'` (Metro adds the .js)
    if (/^\.\.?\//.test(specifier) && !/\.[cm]?js$/.test(specifier)) return next(specifier + '.js', context);
    throw e;
  }
}
