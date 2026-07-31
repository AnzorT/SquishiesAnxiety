import React, { useState } from 'react';
import { View, Text, TextInput, Pressable, ActivityIndicator, KeyboardAvoidingView, Platform } from 'react-native';
import { registerWithEmail } from '../firebase/auth';
import { createUserProfile } from '../firebase/firestore';
import { authErrorMessage } from '../firebase/authErrors';
import { colors } from '../theme/tokens';
import styles from '../theme/authStyles';

export default function RegisterScreen({ onSwitchToLogin }) {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [age, setAge] = useState('');
  const [error, setError] = useState('');
  const [submitting, setSubmitting] = useState(false);

  const submit = async () => {
    const trimmedEmail = email.trim();
    const ageNum = parseInt(age, 10);

    if (!trimmedEmail || !password) {
      setError('Enter an email and password.');
      return;
    }
    if (password.length < 6) {
      setError('Password needs at least 6 characters.');
      return;
    }
    if (!age || Number.isNaN(ageNum) || ageNum < 1 || ageNum > 120) {
      setError('Enter a valid age.');
      return;
    }

    setError('');
    setSubmitting(true);
    try {
      const user = await registerWithEmail(trimmedEmail, password);
      await createUserProfile(user.uid, { email: trimmedEmail, age: ageNum });
      // no navigation call needed — App.js's onAuthStateChanged listener
      // picks up the signed-in user and switches screens itself.
    } catch (e) {
      setError(authErrorMessage(e));
      setSubmitting(false);
    }
  };

  return (
    <KeyboardAvoidingView style={styles.container} behavior={Platform.OS === 'ios' ? 'padding' : undefined}>
      <Text style={styles.title}>Create your account</Text>
      <Text style={styles.subtitle}>Collect, squish, and unlock the shelf</Text>

      <View style={styles.field}>
        <Text style={styles.label}>Email</Text>
        <TextInput
          style={styles.input}
          value={email}
          onChangeText={setEmail}
          autoCapitalize="none"
          keyboardType="email-address"
          placeholder="you@example.com"
          placeholderTextColor={colors.textMuted}
        />
      </View>

      <View style={styles.field}>
        <Text style={styles.label}>Password</Text>
        <TextInput
          style={styles.input}
          value={password}
          onChangeText={setPassword}
          secureTextEntry
          placeholder="At least 6 characters"
          placeholderTextColor={colors.textMuted}
        />
      </View>

      <View style={styles.field}>
        <Text style={styles.label}>Age</Text>
        <TextInput
          style={styles.input}
          value={age}
          onChangeText={setAge}
          keyboardType="number-pad"
          placeholder="13"
          placeholderTextColor={colors.textMuted}
          maxLength={3}
        />
      </View>

      {!!error && <Text style={styles.error}>{error}</Text>}

      <Pressable style={[styles.button, submitting && styles.buttonDisabled]} onPress={submit} disabled={submitting}>
        {submitting ? <ActivityIndicator color="#FFFFFF" /> : <Text style={styles.buttonText}>Create Account</Text>}
      </Pressable>

      <Pressable onPress={onSwitchToLogin}>
        <Text style={styles.switchText}>
          Already have an account? <Text style={styles.switchLink}>Log in</Text>
        </Text>
      </Pressable>
    </KeyboardAvoidingView>
  );
}
