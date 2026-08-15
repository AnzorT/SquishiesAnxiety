const { getDefaultConfig } = require('expo/metro-config');

const config = getDefaultConfig(__dirname);
config.transformer.unstable_allowRequireContext = true;
// Not in Metro's default asset list — needed so require('./cloude_3d.glb')
// bundles as a binary asset (resolved via expo-asset) instead of Metro
// trying to parse it as source.
config.resolver.assetExts.push('glb', 'gltf');

module.exports = config;
