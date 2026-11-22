package com.plushcrush.app

import android.os.Build
import android.os.Bundle
import android.util.Log

import androidx.core.view.WindowCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.view.WindowInsetsControllerCompat

import com.facebook.react.ReactActivity
import com.facebook.react.ReactActivityDelegate
import com.facebook.react.defaults.DefaultNewArchitectureEntryPoint.fabricEnabled
import com.facebook.react.defaults.DefaultReactActivityDelegate

import expo.modules.ReactActivityDelegateWrapper

class MainActivity : ReactActivity() {
  override fun onCreate(savedInstanceState: Bundle?) {
    // Set the theme to AppTheme BEFORE onCreate to support
    // coloring the background, status bar, and navigation bar.
    // This is required for expo-splash-screen.
    setTheme(R.style.AppTheme);
    super.onCreate(null)
    hideNavigationBar()
    preferSixtyHz()
    window.decorView.post { preferSixtyHz() }
  }

  // PERF 2026-11-20: the game runs at a steady 60 fps. On a 90/120 Hz phone every frame that misses the short vsync
  // (11.1 / 8.3 ms) waited for the next one, so busy screens ran at 45 fps with stutter; asking the display for its
  // 60 Hz mode (same resolution) gives every frame 16.7 ms. Phones without a 60 Hz mode are left as they are.
  // (applied again on resume and focus, beside the navigation bar: set once in onCreate it didn't stick)
  private fun preferSixtyHz() {
    if (Build.VERSION.SDK_INT < Build.VERSION_CODES.M) return
    try {
      val attrs = window.attributes
      var changed = false
      // the refresh rate itself: the system picks its own display mode for it (Samsung shows apps only the phone's
      // top mode, so an app can't name the 60 Hz one; the Galaxy A16 lists just 90 Hz to apps)
      if (attrs.preferredRefreshRate != 60f) {
        attrs.preferredRefreshRate = 60f
        changed = true
      }
      // and the 60 Hz mode by id where the phone lets apps see it
      @Suppress("DEPRECATION")
      val display = windowManager.defaultDisplay
      if (display != null) {
        val cur = display.mode
        val best = display.supportedModes
          .filter { it.physicalWidth == cur.physicalWidth && it.physicalHeight == cur.physicalHeight }
          .minByOrNull { Math.abs(it.refreshRate - 60f) }
        if (best != null && Math.abs(best.refreshRate - 60f) <= 1f && attrs.preferredDisplayModeId != best.modeId) {
          attrs.preferredDisplayModeId = best.modeId
          changed = true
        }
      }
      if (changed) {
        window.attributes = attrs
        Log.i("PlushCrush", "60 Hz requested (mode ${attrs.preferredDisplayModeId}, rate ${attrs.preferredRefreshRate})")
      }
      // Android 15+: a touch doesn't push the screen back up to its top rate (the API is newer than compileSdk 34)
      if (Build.VERSION.SDK_INT >= 35) {
        try {
          window.javaClass.getMethod("setFrameRateBoostOnTouchEnabled", Boolean::class.javaPrimitiveType).invoke(window, false)
        } catch (e: Exception) {
        }
      }
    } catch (e: Exception) {
      Log.w("PlushCrush", "preferSixtyHz failed", e)
    }
  }
  private fun hideNavigationBar() {
    val controller = WindowCompat.getInsetsController(window, window.decorView)
    controller.systemBarsBehavior = WindowInsetsControllerCompat.BEHAVIOR_SHOW_TRANSIENT_BARS_BY_SWIPE
    // and the status bar (2026-11-20): JS hides it once (expo-status-bar), and coming back from the lock screen the system
    // showed it again over the game, pushing it down, until the next launch
    controller.hide(WindowInsetsCompat.Type.navigationBars() or WindowInsetsCompat.Type.statusBars())
  }

  override fun onWindowFocusChanged(hasFocus: Boolean) {
    super.onWindowFocusChanged(hasFocus)
    if (hasFocus) {
      hideNavigationBar()
      preferSixtyHz()
    }
  }

  override fun onResume() {
    super.onResume()
    hideNavigationBar()
    preferSixtyHz()
  }

  /**
   * Returns the name of the main component registered from JavaScript. This is used to schedule
   * rendering of the component.
   */
  override fun getMainComponentName(): String = "main"

  /**
   * Returns the instance of the [ReactActivityDelegate]. We use [DefaultReactActivityDelegate]
   * which allows you to enable New Architecture with a single boolean flags [fabricEnabled]
   */
  override fun createReactActivityDelegate(): ReactActivityDelegate {
    return ReactActivityDelegateWrapper(
          this,
          BuildConfig.IS_NEW_ARCHITECTURE_ENABLED,
          object : DefaultReactActivityDelegate(
              this,
              mainComponentName,
              fabricEnabled
          ){})
  }

  /**
    * Align the back button behavior with Android S
    * where moving root activities to background instead of finishing activities.
    * @see <a href="https://developer.android.com/reference/android/app/Activity#onBackPressed()">onBackPressed</a>
    */
  override fun invokeDefaultOnBackPressed() {
      if (Build.VERSION.SDK_INT <= Build.VERSION_CODES.R) {
          if (!moveTaskToBack(false)) {
              // For non-root activities, use the default implementation to finish them.
              super.invokeDefaultOnBackPressed()
          }
          return
      }

      // Use the default back button implementation on Android S
      // because it's doing more than [Activity.moveTaskToBack] in fact.
      super.invokeDefaultOnBackPressed()
  }
}
