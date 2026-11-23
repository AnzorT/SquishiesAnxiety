#!/usr/bin/env bash
# Runs the Unity editor headless inside a unityci/editor container (CI): activates the license, then runs one
# -executeMethod with a virtual screen (the screenshots need a real graphics device, so no -nographics).
#
#   unity/ci/unity.sh <ExecuteMethod>        e.g. SquishSquad.EditorTools.CiBuild.CaptureMenu
#
# License, from the environment (GitHub secrets):
#   UNITY_SERIAL + UNITY_EMAIL + UNITY_PASSWORD   a Plus/Pro seat: activated with the serial, returned afterwards
#   UNITY_LICENSE (+ UNITY_EMAIL/UNITY_PASSWORD)  a Personal license: the contents of Unity_lic.ulf
set -euo pipefail
METHOD="$1"
PROJECT="${PROJECT_PATH:-unity}"

if ! command -v xvfb-run >/dev/null; then
  apt-get update -qq && DEBIAN_FRONTEND=noninteractive apt-get install -y -qq xvfb libgl1-mesa-dri libglu1-mesa >/dev/null
fi

returned=0
return_license() { if [ -n "${UNITY_SERIAL:-}" ] && [ "$returned" = 0 ]; then returned=1; unity-editor -batchmode -nographics -quit -logFile - -returnlicense -username "$UNITY_EMAIL" -password "$UNITY_PASSWORD" || true; fi; }
trap return_license EXIT

if [ -n "${UNITY_SERIAL:-}" ]; then
  unity-editor -batchmode -nographics -quit -logFile - -serial "$UNITY_SERIAL" -username "$UNITY_EMAIL" -password "$UNITY_PASSWORD"
elif [ -n "${UNITY_LICENSE:-}" ]; then
  for d in "$HOME/.local/share/unity3d/Unity" /usr/share/unity3d/config; do
    mkdir -p "$d"; printf '%s' "$UNITY_LICENSE" | tr -d '\r' > "$d/Unity_lic.ulf"
  done
else
  echo "No Unity license: add UNITY_LICENSE (Personal) or UNITY_SERIAL as repository secrets (see unity/README.md)" >&2
  exit 1
fi

xvfb-run -a -s "-screen 0 1280x1024x24" \
  unity-editor -batchmode -logFile - -projectPath "$PROJECT" -executeMethod "$METHOD" -quit
