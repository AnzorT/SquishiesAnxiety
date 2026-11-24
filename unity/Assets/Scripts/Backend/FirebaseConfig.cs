// Where the client talks to: the live project's values (the same ones android/app/google-services.json gives the RN
// app; a Firebase web API key isn't a secret, it only names the project) or the Local Emulator Suite.
//
// Kept as C# constants rather than a Resources asset: nothing to load or parse at start-up, and the values change
// only if the project does. If the Android app id `com.plushcrush.unity` is registered in the Firebase console and
// gets its own key, put that key in ApiKey.
using System.Collections.Generic;

namespace SquishSquad.Backend
{
    public sealed class FirebaseConfig
    {
        // android/app/google-services.json: project_info.project_id, client[0].api_key[0].current_key
        public const string LiveProjectId = "squishy-app-61445";
        public const string LiveApiKey = "AIzaSyA2bjX5Ny3IEinzowxFs-_eD6CNFM10p4E";
        public const string LiveStorageBucket = "squishy-app-61445.firebasestorage.app";

        public string ProjectId;
        public string ApiKey;
        public string Region = "us-central1"; // callFunction.js REGION
        public string StorageBucket;

        // Base URLs (no trailing slash). The live ones by default; Emulator() points them at the emulator suite.
        public string AuthBase = "https://identitytoolkit.googleapis.com";
        public string SecureTokenBase = "https://securetoken.googleapis.com";
        public string FirestoreBase = "https://firestore.googleapis.com";
        public string FunctionsBase; // null: https://{region}-{project}.cloudfunctions.net
        public bool IsEmulator;

        // Sent with every Auth request. If the API key is restricted to Android apps in the Google Cloud console,
        // REST calls from a non-SDK client must name the app: X-Android-Package and X-Android-Cert (the signing
        // certificate's SHA-1, hex, no colons).
        public Dictionary<string, string> AuthHeaders = new Dictionary<string, string>();

        public string Database = "(default)";

        public static FirebaseConfig Live() =>
            new FirebaseConfig { ProjectId = LiveProjectId, ApiKey = LiveApiKey, StorageBucket = LiveStorageBucket };

        // The Local Emulator Suite on `host` with its default ports. Use a `demo-` project id: the emulators then
        // never reach a real project. Any API key works with the Auth emulator.
        public static FirebaseConfig Emulator(string projectId = "demo-squish", string host = "127.0.0.1",
            int authPort = 9099, int firestorePort = 8080, int functionsPort = 5001)
        {
            return new FirebaseConfig
            {
                ProjectId = projectId,
                ApiKey = "fake-api-key",
                AuthBase = "http://" + host + ":" + authPort + "/identitytoolkit.googleapis.com",
                SecureTokenBase = "http://" + host + ":" + authPort + "/securetoken.googleapis.com",
                FirestoreBase = "http://" + host + ":" + firestorePort,
                FunctionsBase = "http://" + host + ":" + functionsPort + "/" + projectId,
                IsEmulator = true,
            };
        }

        internal string FunctionUrl(string name) =>
            FunctionsBase != null
                ? FunctionsBase + "/" + Region + "/" + name
                : "https://" + Region + "-" + ProjectId + ".cloudfunctions.net/" + name;

        // projects/{p}/databases/(default)/documents
        internal string DocumentsRoot => "projects/" + ProjectId + "/databases/" + Database + "/documents";
    }
}
