import React, { useState } from 'react';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import ShelfScreen from './src/screens/ShelfScreen';
import SquishScreen from './src/screens/SquishScreen';

export default function App() {
  const [activeToy, setActiveToy] = useState(null);

  return (
    <SafeAreaProvider>
      <StatusBar style="light" />
      {activeToy ? (
        <SquishScreen toy={activeToy} onBack={() => setActiveToy(null)} />
      ) : (
        <ShelfScreen onSelectToy={setActiveToy} />
      )}
    </SafeAreaProvider>
  );
}
