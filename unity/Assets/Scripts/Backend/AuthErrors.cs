// Firebase Auth errors: the REST API's codes (EMAIL_EXISTS, INVALID_PASSWORD…) turned into the SDK's
// "auth/…" codes, and those into the words the app shows (src/firebase/authErrors.js, word for word).
using System;
using System.Collections.Generic;

namespace SquishSquad.Backend
{
    public sealed class FirebaseAuthException : Exception
    {
        public readonly string Code; // "auth/email-already-in-use"
        public readonly string ServerCode; // "EMAIL_EXISTS" (null for a network failure)
        public readonly int Status; // HTTP status, 0 when there was no response

        public FirebaseAuthException(string code, string serverCode, int status, string detail = null, Exception inner = null)
            : base(AuthErrors.MessageFor(code), inner)
        {
            Code = code;
            ServerCode = serverCode;
            Status = status;
            Detail = detail;
        }

        // the server's own text, for logs ("WEAK_PASSWORD : Password should be at least 6 characters")
        public readonly string Detail;
    }

    public static class AuthErrors
    {
        // src/firebase/authErrors.js MESSAGES
        static readonly Dictionary<string, string> Messages = new Dictionary<string, string>
        {
            { "auth/email-already-in-use", "That email is already registered — try logging in instead." },
            { "auth/invalid-email", "That email address doesn't look right." },
            { "auth/weak-password", "Password needs at least 6 characters." },
            { "auth/user-not-found", "No account found with that email." },
            { "auth/wrong-password", "Incorrect password." },
            { "auth/invalid-credential", "Incorrect email or password." },
            { "auth/network-request-failed", "Network error — check your connection." },
            { "auth/too-many-requests", "Too many attempts — wait a bit and try again." },
        };

        public const string Fallback = "Something went wrong. Please try again.";

        // authErrorMessage(error)
        public static string MessageFor(string code) => code != null && Messages.TryGetValue(code, out var m) ? m : Fallback;

        public static string MessageFor(Exception e) => MessageFor((e as FirebaseAuthException)?.Code);

        // The REST API's error message → the SDK's code (the JS SDK's SERVER_ERROR_MAP, the cases these calls meet).
        static readonly Dictionary<string, string> ServerCodes = new Dictionary<string, string>
        {
            { "EMAIL_EXISTS", "auth/email-already-in-use" },
            { "INVALID_EMAIL", "auth/invalid-email" },
            { "MISSING_EMAIL", "auth/invalid-email" },
            { "WEAK_PASSWORD", "auth/weak-password" },
            { "MISSING_PASSWORD", "auth/missing-password" },
            { "EMAIL_NOT_FOUND", "auth/user-not-found" },
            { "INVALID_PASSWORD", "auth/wrong-password" },
            { "INVALID_LOGIN_CREDENTIALS", "auth/invalid-credential" },
            { "USER_DISABLED", "auth/user-disabled" },
            { "TOO_MANY_ATTEMPTS_TRY_LATER", "auth/too-many-requests" },
            { "OPERATION_NOT_ALLOWED", "auth/operation-not-allowed" },
            { "PASSWORD_LOGIN_DISABLED", "auth/operation-not-allowed" },
            { "INVALID_CUSTOM_TOKEN", "auth/invalid-custom-token" },
            { "CREDENTIAL_MISMATCH", "auth/custom-token-mismatch" },
            { "TOKEN_EXPIRED", "auth/user-token-expired" },
            { "USER_NOT_FOUND", "auth/user-token-expired" },
            { "INVALID_ID_TOKEN", "auth/invalid-user-token" },
            { "INVALID_REFRESH_TOKEN", "auth/invalid-user-token" },
            { "INVALID_API_KEY", "auth/invalid-api-key" },
            { "API_KEY_INVALID", "auth/invalid-api-key" },
            { "QUOTA_EXCEEDED", "auth/quota-exceeded" },
        };

        public static string CodeForServer(string serverCode)
        {
            if (string.IsNullOrEmpty(serverCode)) return "auth/internal-error";
            if (ServerCodes.TryGetValue(serverCode, out var c)) return c;
            if (serverCode.StartsWith("API key not valid", StringComparison.Ordinal)) return "auth/invalid-api-key";
            return "auth/internal-error";
        }

        // The refresh / lookup failures after which the session is gone for good (the SDK signs the user out).
        internal static bool EndsSession(string code) =>
            code == "auth/user-token-expired" || code == "auth/invalid-user-token" || code == "auth/user-disabled";
    }
}
