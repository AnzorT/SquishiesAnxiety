import React, { useMemo, useRef } from 'react';
import { useFrame } from '@react-three/fiber';
import * as THREE from 'three';
import { createSquishMaterial } from '../engine/SquishShaderMaterial';

// Procedural toy geometry — no external 3D assets required. A rounded
// icosphere gives us a soft blob silhouette that reads as "plush" once the
// shader deformation and shading are applied.
export default function PlushToy({ squishState, colorHex = '#FFC7A8', onFrame }) {
  const meshRef = useRef();
  const material = useMemo(() => createSquishMaterial(colorHex), [colorHex]);

  const geometry = useMemo(() => {
    const geo = new THREE.IcosahedronGeometry(1, 3);
    // squash slightly on Y for a "sitting" plush silhouette rather than a
    // perfect sphere
    geo.scale(1, 0.88, 1);
    return geo;
  }, []);

  useFrame((state) => {
    const depth = squishState.tick();
    material.uniforms.uDepth.value = depth;
    material.uniforms.uTouchPoint.value.set(
      squishState.touchPoint.x,
      squishState.touchPoint.y
    );
    material.uniforms.uTime.value = state.clock.elapsedTime;
    if (onFrame) onFrame(depth);
  });

  return <mesh ref={meshRef} geometry={geometry} material={material} />;
}
