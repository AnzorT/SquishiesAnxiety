import { StyleSheet } from 'react-native';
import { colors, radii, spacing } from './tokens';

// Shared chrome for LoginScreen and RegisterScreen — same form, same field
// styling, just different fields/copy.
export const authStyles = StyleSheet.create({
  container: { flex: 1, backgroundColor: colors.bg, justifyContent: 'center', paddingHorizontal: spacing(7) },
  title: { fontSize: 28, fontWeight: '800', color: colors.textPrimary, marginBottom: spacing(1) },
  subtitle: { fontSize: 14, fontWeight: '600', color: colors.textMuted, marginBottom: spacing(7) },
  field: { marginBottom: spacing(4) },
  label: {
    fontSize: 12,
    fontWeight: '700',
    color: colors.textMuted,
    marginBottom: spacing(1),
    textTransform: 'uppercase',
    letterSpacing: 0.5,
  },
  input: {
    backgroundColor: colors.surface,
    borderWidth: 1,
    borderColor: colors.surfaceBorder,
    borderRadius: radii.md,
    paddingHorizontal: spacing(4),
    paddingVertical: spacing(3),
    fontSize: 15,
    color: colors.textPrimary,
  },
  error: { color: colors.danger, fontSize: 13, fontWeight: '600', marginBottom: spacing(3) },
  button: {
    backgroundColor: colors.accent,
    borderRadius: radii.pill,
    paddingVertical: spacing(3.5),
    alignItems: 'center',
    marginTop: spacing(2),
  },
  buttonDisabled: { opacity: 0.6 },
  buttonText: { color: '#FFFFFF', fontSize: 16, fontWeight: '800' },
  switchText: { textAlign: 'center', marginTop: spacing(5), color: colors.textMuted, fontSize: 13 },
  switchLink: { color: colors.accent, fontWeight: '700' },
});

export default authStyles;
