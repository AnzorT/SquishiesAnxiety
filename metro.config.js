const { getDefaultConfig } = require('expo/metro-config');

const config = getDefaultConfig(__dirname);
config.transformer.unstable_allowRequireContext = true;
// Not in Metro's default asset list — needed so require('./glorp_3d.glb')
// bundles as a binary asset (resolved via expo-asset) instead of Metro
// trying to parse it as source. See SquishyToy.js's Glorp build path.
config.resolver.assetExts.push('glb', 'gltf');
// The v3 sounds and music (assets/audio/sfx, assets/audio/music) are Ogg.
config.resolver.assetExts.push('ogg');

module.exports = config;
