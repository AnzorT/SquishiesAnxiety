import * as THREE from 'three';

// Vertex-displacement squish shader.
// uDepth: 0..1 compression amount. uTouchPoint: uv-space touch location.
// Displacement falls off radially from the touch point using a smoothstep,
// pushing vertices inward along their normal — cheap stand-in for soft-body
// deformation. Fragment shader adds foam whitening at the compressed core
// and a soft glossy rim for the "coated" plush look.

const vertexShader = `
  uniform float uDepth;
  uniform vec2 uTouchPoint; // in uv space, 0..1
  uniform float uTime;

  varying vec2 vUv;
  varying float vCompression;

  void main() {
    vUv = uv;
    float dist = distance(uv, uTouchPoint);
    float falloff = 1.0 - smoothstep(0.0, 0.45, dist);
    float displacement = uDepth * falloff;
    vCompression = displacement;

    vec3 newPosition = position - normal * displacement * 0.6;
    // gentle idle breathing so the toy doesn't look static at rest
    float breathe = sin(uTime * 1.1) * 0.006;
    newPosition += normal * breathe;

    gl_Position = projectionMatrix * modelViewMatrix * vec4(newPosition, 1.0);
  }
`;

const fragmentShader = `
  uniform vec3 uBaseColor;
  uniform float uDepth;
  varying vec2 vUv;
  varying float vCompression;

  void main() {
    // Foam whitening at the compressed core
    vec3 whitened = mix(uBaseColor, vec3(1.0), vCompression * 0.55);
    // Soft glossy rim based on compression edge
    float rim = smoothstep(0.15, 0.0, abs(vCompression - 0.15));
    vec3 color = whitened + rim * 0.08;
    gl_FragColor = vec4(color, 1.0);
  }
`;

export function createSquishMaterial(baseColorHex = '#FFC7A8') {
  return new THREE.ShaderMaterial({
    uniforms: {
      uDepth: { value: 0 },
      uTouchPoint: { value: new THREE.Vector2(0.5, 0.5) },
      uTime: { value: 0 },
      uBaseColor: { value: new THREE.Color(baseColorHex) },
    },
    vertexShader,
    fragmentShader,
  });
}

export default createSquishMaterial;
