import React, { useMemo, useRef } from 'react';
import { useFrame } from '@react-three/fiber';
import * as THREE from 'three';

// Lightweight point-sprite particle burst. Two triggers:
//  - "puff": small air-distortion puff when compression crosses 50% depth
//  - "burst": larger colored release fired on true burst events (e.g. bead fill)
const PARTICLE_COUNT = 60;

export default function ParticleBurst({ trigger, colorHex = '#FFFFFF' }) {
  const pointsRef = useRef();
  const velocities = useRef([]);
  const active = useRef(false);
  const startTime = useRef(0);

  const geometry = useMemo(() => {
    const geo = new THREE.BufferGeometry();
    const positions = new Float32Array(PARTICLE_COUNT * 3);
    geo.setAttribute('position', new THREE.BufferAttribute(positions, 3));
    return geo;
  }, []);

  const material = useMemo(
    () =>
      new THREE.PointsMaterial({
        color: new THREE.Color(colorHex),
        size: 0.035,
        transparent: true,
        opacity: 0,
        depthWrite: false,
      }),
    [colorHex]
  );

  React.useEffect(() => {
    if (!trigger) return;
    active.current = true;
    startTime.current = Date.now();
    const isBig = trigger === 'burst';
    const speed = isBig ? 1.4 : 0.5;

    const positions = geometry.attributes.position.array;
    velocities.current = [];
    for (let i = 0; i < PARTICLE_COUNT; i++) {
      positions[i * 3] = 0;
      positions[i * 3 + 1] = 0;
      positions[i * 3 + 2] = 0;
      const theta = Math.random() * Math.PI * 2;
      const phi = Math.random() * Math.PI;
      velocities.current.push({
        x: Math.sin(phi) * Math.cos(theta) * speed,
        y: Math.sin(phi) * Math.sin(theta) * speed,
        z: Math.cos(phi) * speed,
      });
    }
    geometry.attributes.position.needsUpdate = true;
    material.opacity = 1;
  }, [trigger]);

  useFrame((_, delta) => {
    if (!active.current) return;
    const elapsed = (Date.now() - startTime.current) / 1000;
    if (elapsed > 0.6) {
      active.current = false;
      material.opacity = 0;
      return;
    }
    const positions = geometry.attributes.position.array;
    for (let i = 0; i < PARTICLE_COUNT; i++) {
      const v = velocities.current[i];
      positions[i * 3] += v.x * delta;
      positions[i * 3 + 1] += v.y * delta;
      positions[i * 3 + 2] += v.z * delta;
    }
    geometry.attributes.position.needsUpdate = true;
    material.opacity = Math.max(0, 1 - elapsed / 0.6);
  });

  return <points ref={pointsRef} geometry={geometry} material={material} />;
}
