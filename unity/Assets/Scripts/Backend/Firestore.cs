// Cloud Firestore over its REST API (v1), covering what src/firebase/firestore.js does with the SDK:
//   doc.get()                         → Get(path)                       (null when it doesn't exist)
//   doc.set(data) / set(data, merge)  → Set(path, data, merge)
//   doc.update({ 'a.b': v, … })       → Update(path, fields)            (dotted paths; fails if the doc is missing)
//   collection.add(data)              → Add(collectionPath, data)       (client-made id, like the SDK)
//   doc.delete()                      → Delete(path)
//   collection.orderBy(f).get()       → List(collectionPath, orderBy)   (one collection's documents, paged through)
//   runTransaction                    → RunTransaction(tx => …)          (recordPress's read-then-write)
//   FieldValue.increment / arrayUnion / arrayRemove / serverTimestamp / delete → FieldValue.*
// Every write goes through `documents:commit`, so the transforms ride in the same atomic write as the fields
// (updateTransforms), exactly as the SDK sends them. Paths are "users/{uid}", "users/{uid}/crib/state"…
//
// Requests carry the signed-in user's ID token, so firestore.rules apply just as they do to the app.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SquishSquad.Backend
{
    public sealed class FirestoreDocument
    {
        public string Path; // "users/abc"
        public string Id; // "abc"
        public Dictionary<string, object> Data;
        public DateTime? CreateTime;
        public DateTime? UpdateTime;
    }

    public sealed class FirestoreException : Exception
    {
        public readonly int Status; // HTTP status, 0 when there was no response
        public readonly string Code; // "permission-denied", "not-found", "aborted", "unavailable"… (the SDK's codes)

        public FirestoreException(int status, string code, string message, Exception inner = null) : base(message, inner)
        {
            Status = status;
            Code = code;
        }
    }

    public sealed class Firestore
    {
        readonly FirebaseConfig cfg;
        readonly IHttp http;
        readonly FirebaseAuth auth;

        public Firestore(FirebaseConfig config, IHttp http, FirebaseAuth auth)
        {
            cfg = config;
            this.http = http;
            this.auth = auth;
        }

        string Root => cfg.DocumentsRoot; // projects/p/databases/(default)/documents
        string DbPrefix => Root + "/";
        string Name(string path) => DbPrefix + Trim(path);
        string Url(string resource) => cfg.FirestoreBase + "/v1/" + resource;

        static string Trim(string path) => path.Trim('/');

        // --- reads ----------------------------------------------------------------------------------------------

        public Task<FirestoreDocument> Get(string path, CancellationToken cancel = default) => GetIn(path, null, cancel);

        internal async Task<FirestoreDocument> GetIn(string path, string transaction, CancellationToken cancel)
        {
            if (transaction == null)
            {
                var res = await Send("GET", Url(EscapePath(Root + "/" + Trim(path))), null, cancel, allow404: true).ConfigureAwait(false);
                return res == null ? null : ToDocument(res);
            }
            // inside a transaction: batchGet (a GET with ?transaction= hangs on the emulator; batchGet is what the
            // SDKs use) → [{ "found": doc } | { "missing": name }]
            var body = Json.Write(new Dictionary<string, object> { { "documents", new List<object> { Name(path) } }, { "transaction", transaction } });
            var list = await SendRaw("POST", Url(Root + ":batchGet"), body, cancel, false).ConfigureAwait(false) as List<object>;
            if (list != null)
                foreach (var item in list)
                    if (Json.Get(item, "found") is Dictionary<string, object> found)
                        return ToDocument(found);
            return null;
        }

        // A collection's documents (all pages). `orderBy`: "createdAt" or "createdAt desc".
        public async Task<List<FirestoreDocument>> List(string collectionPath, string orderBy = null, int pageSize = 300,
            CancellationToken cancel = default)
        {
            var docs = new List<FirestoreDocument>();
            string token = null;
            do
            {
                var q = new StringBuilder("?pageSize=").Append(pageSize.ToString(CultureInfo.InvariantCulture));
                if (orderBy != null) q.Append("&orderBy=").Append(Uri.EscapeDataString(orderBy));
                if (token != null) q.Append("&pageToken=").Append(Uri.EscapeDataString(token));
                var res = await Send("GET", Url(EscapePath(Root + "/" + Trim(collectionPath))) + q, null, cancel, allow404: true)
                    .ConfigureAwait(false);
                if (res == null) break;
                if (Json.Get(res, "documents") is List<object> list)
                    foreach (var d in list)
                        docs.Add(ToDocument(d as Dictionary<string, object>));
                token = Json.Str(res, "nextPageToken");
                if (token == "") token = null;
            } while (token != null);
            return docs;
        }

        // --- writes ---------------------------------------------------------------------------------------------

        // doc.set(data): replaces the document (or, with merge, only the fields `data` names). FieldValue sentinels
        // may sit at any depth of `data`.
        public Task Set(string path, IDictionary<string, object> data, bool merge = false, CancellationToken cancel = default) =>
            Commit(new[] { SetWrite(path, data, merge) }, null, cancel);

        // Fails with "already-exists" if it's there.
        public Task Create(string path, IDictionary<string, object> data, CancellationToken cancel = default)
        {
            var w = SetWrite(path, data, false);
            w["currentDocument"] = new Dictionary<string, object> { { "exists", false } };
            return Commit(new[] { w }, null, cancel);
        }

        // doc.update({ 'stack.best.3': 2, coins: FieldValue.Increment(5) }): each key a dotted field path; fails with
        // "not-found" if the document doesn't exist.
        public Task Update(string path, IDictionary<string, object> fields, CancellationToken cancel = default) =>
            Commit(new[] { UpdateWrite(path, fields) }, null, cancel);

        public Task Delete(string path, CancellationToken cancel = default) =>
            Commit(new[] { DeleteWrite(path) }, null, cancel);

        // collection.add(data): a new document with a client-made id (so serverTimestamp works); returns the id.
        public async Task<string> Add(string collectionPath, IDictionary<string, object> data, CancellationToken cancel = default)
        {
            string id = NewId();
            await Set(Trim(collectionPath) + "/" + id, data, false, cancel).ConfigureAwait(false);
            return id;
        }

        // collection.doc().id: 20 random letters and digits, as the SDK makes them.
        public static string NewId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var bytes = new byte[40];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(bytes);
            var sb = new StringBuilder(20);
            foreach (var b in bytes)
            {
                if (b >= 248) continue; // 248 = 62 × 4: keep it uniform
                sb.Append(chars[b % 62]);
                if (sb.Length == 20) break;
            }
            while (sb.Length < 20) sb.Append(chars[Guid.NewGuid().ToByteArray()[0] % 62]);
            return sb.ToString();
        }

        // Several writes in one atomic commit (a WriteBatch).
        public Batch NewBatch() => new Batch(this);

        public sealed class Batch
        {
            readonly Firestore fs;
            internal readonly List<Dictionary<string, object>> Writes = new List<Dictionary<string, object>>();
            internal Batch(Firestore fs) => this.fs = fs;

            public Batch Set(string path, IDictionary<string, object> data, bool merge = false)
            {
                Writes.Add(fs.SetWrite(path, data, merge));
                return this;
            }

            public Batch Update(string path, IDictionary<string, object> fields)
            {
                Writes.Add(fs.UpdateWrite(path, fields));
                return this;
            }

            public Batch Delete(string path)
            {
                Writes.Add(fs.DeleteWrite(path));
                return this;
            }

            public Task Commit(CancellationToken cancel = default) => fs.Commit(Writes, null, cancel);
        }

        // --- transactions ---------------------------------------------------------------------------------------

        public sealed class Transaction
        {
            readonly Firestore fs;
            internal readonly string Id;
            internal readonly List<Dictionary<string, object>> Writes = new List<Dictionary<string, object>>();

            internal Transaction(Firestore fs, string id)
            {
                this.fs = fs;
                Id = id;
            }

            public Task<FirestoreDocument> Get(string path) => fs.GetIn(path, Id, default);
            public void Set(string path, IDictionary<string, object> data, bool merge = false) => Writes.Add(fs.SetWrite(path, data, merge));
            public void Update(string path, IDictionary<string, object> fields) => Writes.Add(fs.UpdateWrite(path, fields));
            public void Delete(string path) => Writes.Add(fs.DeleteWrite(path));
        }

        // runTransaction: reads inside `body` lock what they read; the writes it queues commit together. Retried
        // (up to `attempts` times) when Firestore aborts it for contention.
        public async Task<T> RunTransaction<T>(Func<Transaction, Task<T>> body, int attempts = 5, CancellationToken cancel = default)
        {
            string retry = null;
            for (int attempt = 1; ; attempt++)
            {
                var opts = new Dictionary<string, object>();
                var rw = new Dictionary<string, object>();
                if (retry != null) rw["retryTransaction"] = retry;
                opts["readWrite"] = rw;
                var begun = await Send("POST", Url(Root + ":beginTransaction"),
                    Json.Write(new Dictionary<string, object> { { "options", opts } }), cancel).ConfigureAwait(false);
                var tx = new Transaction(this, Json.Str(begun, "transaction"));
                T result;
                try
                {
                    result = await body(tx).ConfigureAwait(false);
                }
                catch
                {
                    await Rollback(tx.Id).ConfigureAwait(false);
                    throw;
                }
                try
                {
                    await Commit(tx.Writes, tx.Id, cancel).ConfigureAwait(false);
                    return result;
                }
                catch (FirestoreException e) when (e.Code == "aborted" && attempt < attempts)
                {
                    retry = tx.Id;
                }
            }
        }

        async Task Rollback(string id)
        {
            try
            {
                await Send("POST", Url(Root + ":rollback"), Json.Write(new Dictionary<string, object> { { "transaction", id } }), default)
                    .ConfigureAwait(false);
            }
            catch
            {
                // it expires on its own
            }
        }

        // --- building writes ------------------------------------------------------------------------------------

        Dictionary<string, object> SetWrite(string path, IDictionary<string, object> data, bool merge)
        {
            var transforms = new List<object>();
            var deletes = new List<string>();
            var plain = Strip(data, new List<string>(), transforms, deletes, allowDelete: merge);
            var w = new Dictionary<string, object>
            {
                { "update", new Dictionary<string, object> { { "name", Name(path) }, { "fields", FirestoreValues.EncodeFields(plain, DbPrefix) } } },
            };
            if (merge)
            {
                var mask = new List<object>();
                LeafPaths(plain, new List<string>(), mask);
                foreach (var d in deletes) mask.Add(d);
                w["updateMask"] = new Dictionary<string, object> { { "fieldPaths", mask } };
            }
            if (transforms.Count > 0) w["updateTransforms"] = transforms;
            return w;
        }

        Dictionary<string, object> UpdateWrite(string path, IDictionary<string, object> fields)
        {
            var root = new Dictionary<string, object>();
            var mask = new List<object>();
            var transforms = new List<object>();
            foreach (var kv in fields)
            {
                var segs = FirestoreValues.SplitPath(kv.Key);
                if (kv.Value is FieldValue fv)
                {
                    if (fv.Kind == FieldValue.Op.Delete) mask.Add(FirestoreValues.QuotePath(segs));
                    else transforms.Add(Transform(segs, fv));
                    continue;
                }
                object v = kv.Value;
                if (v is IDictionary<string, object> m)
                {
                    var deletes = new List<string>();
                    v = Strip(m, segs, transforms, deletes, allowDelete: false);
                }
                SetNested(root, segs, v);
                mask.Add(FirestoreValues.QuotePath(segs));
            }
            var w = new Dictionary<string, object>
            {
                { "update", new Dictionary<string, object> { { "name", Name(path) }, { "fields", FirestoreValues.EncodeFields(root, DbPrefix) } } },
                // always sent, even empty (a transform-only update): without a mask the write would replace the doc
                { "updateMask", new Dictionary<string, object> { { "fieldPaths", mask } } },
                { "currentDocument", new Dictionary<string, object> { { "exists", true } } },
            };
            if (transforms.Count > 0) w["updateTransforms"] = transforms;
            return w;
        }

        Dictionary<string, object> DeleteWrite(string path) => new Dictionary<string, object> { { "delete", Name(path) } };

        // `data` without its FieldValues (those become transforms / deleted paths), maps copied.
        Dictionary<string, object> Strip(IDictionary<string, object> data, List<string> at, List<object> transforms,
            List<string> deletes, bool allowDelete)
        {
            var o = new Dictionary<string, object>();
            if (data == null) return o;
            foreach (var kv in data)
            {
                var segs = new List<string>(at) { kv.Key };
                switch (kv.Value)
                {
                    case FieldValue fv when fv.Kind == FieldValue.Op.Delete:
                        if (!allowDelete) throw new ArgumentException("FieldValue.Delete only works in Update or a merge Set");
                        deletes.Add(FirestoreValues.QuotePath(segs));
                        break;
                    case FieldValue fv:
                        transforms.Add(Transform(segs, fv));
                        break;
                    case IDictionary<string, object> m:
                        o[kv.Key] = Strip(m, segs, transforms, deletes, allowDelete);
                        break;
                    default:
                        o[kv.Key] = kv.Value;
                        break;
                }
            }
            return o;
        }

        // A merge set's mask: every leaf field it writes (an empty map counts as a leaf).
        static void LeafPaths(IDictionary<string, object> m, List<string> at, List<object> into)
        {
            foreach (var kv in m)
            {
                var segs = new List<string>(at) { kv.Key };
                if (kv.Value is IDictionary<string, object> sub && sub.Count > 0) LeafPaths(sub, segs, into);
                else into.Add(FirestoreValues.QuotePath(segs));
            }
        }

        static void SetNested(Dictionary<string, object> root, List<string> segs, object v)
        {
            var m = root;
            for (int i = 0; i < segs.Count - 1; i++)
            {
                if (!(m.TryGetValue(segs[i], out var next) && next is Dictionary<string, object> nm))
                {
                    nm = new Dictionary<string, object>();
                    m[segs[i]] = nm;
                }
                m = nm;
            }
            m[segs[segs.Count - 1]] = v;
        }

        Dictionary<string, object> Transform(List<string> segs, FieldValue fv)
        {
            var t = new Dictionary<string, object> { { "fieldPath", FirestoreValues.QuotePath(segs) } };
            switch (fv.Kind)
            {
                case FieldValue.Op.Increment:
                    t["increment"] = FirestoreValues.Encode(fv.Amount, DbPrefix);
                    break;
                case FieldValue.Op.ArrayUnion:
                    t["appendMissingElements"] = ArrayOf(fv.Elements);
                    break;
                case FieldValue.Op.ArrayRemove:
                    t["removeAllFromArray"] = ArrayOf(fv.Elements);
                    break;
                case FieldValue.Op.ServerTimestamp:
                    t["setToServerValue"] = "REQUEST_TIME";
                    break;
                default:
                    throw new ArgumentException(fv.ToString());
            }
            return t;
        }

        Dictionary<string, object> ArrayOf(IReadOnlyList<object> items)
        {
            var vals = new List<object>();
            foreach (var x in items) vals.Add(FirestoreValues.Encode(x, DbPrefix));
            return new Dictionary<string, object> { { "values", vals } };
        }

        internal async Task Commit(IEnumerable<Dictionary<string, object>> writes, string transaction, CancellationToken cancel)
        {
            var list = new List<object>();
            foreach (var w in writes) list.Add(w);
            var body = new Dictionary<string, object> { { "writes", list } };
            if (transaction != null) body["transaction"] = transaction;
            await Send("POST", Url(Root + ":commit"), Json.Write(body), cancel).ConfigureAwait(false);
        }

        // --- plumbing -------------------------------------------------------------------------------------------

        FirestoreDocument ToDocument(Dictionary<string, object> d)
        {
            string name = Json.Str(d, "name") ?? "";
            string path = name.StartsWith(DbPrefix, StringComparison.Ordinal) ? name.Substring(DbPrefix.Length) : name;
            int slash = path.LastIndexOf('/');
            return new FirestoreDocument
            {
                Path = path,
                Id = slash >= 0 ? path.Substring(slash + 1) : path,
                Data = FirestoreValues.DecodeFields(Json.Get(d, "fields"), DbPrefix),
                CreateTime = Time(Json.Str(d, "createTime")),
                UpdateTime = Time(Json.Str(d, "updateTime")),
            };
        }

        static DateTime? Time(string s) => string.IsNullOrEmpty(s) ? (DateTime?)null : FirestoreValues.ParseTimestamp(s);

        static string EscapePath(string path)
        {
            var parts = path.Split('/');
            for (int i = 0; i < parts.Length; i++) parts[i] = Uri.EscapeDataString(parts[i]).Replace("%28", "(").Replace("%29", ")");
            return string.Join("/", parts);
        }

        async Task<Dictionary<string, object>> Send(string method, string url, string body, CancellationToken cancel, bool allow404 = false)
        {
            var json = await SendRaw(method, url, body, cancel, allow404).ConfigureAwait(false);
            return json == null ? null : json as Dictionary<string, object> ?? new Dictionary<string, object>();
        }

        // The response's JSON (null for an allowed 404); throws FirestoreException for any other failure.
        async Task<object> SendRaw(string method, string url, string body, CancellationToken cancel, bool allow404)
        {
            var req = new HttpRequest { Method = method, Url = url, Body = body };
            if (auth?.CurrentUser != null)
                req.Headers["Authorization"] = "Bearer " + await auth.GetIdToken(false, cancel).ConfigureAwait(false);
            HttpResult res;
            try
            {
                res = await http.Send(req, cancel).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancel.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new FirestoreException(0, "unavailable", "Network error: " + e.Message, e);
            }
            if (res.Status == 404 && allow404) return null;
            var json = Json.TryParse(res.Body);
            if (res.Ok) return json ?? new Dictionary<string, object>();
            // { "error": { "code": 403, "message": "…", "status": "PERMISSION_DENIED" } } (a list of them, sometimes)
            if (json is List<object> l && l.Count > 0) json = l[0];
            var err = Json.Get(json, "error");
            string status = Json.Str(err, "status");
            string code = status != null ? status.ToLowerInvariant().Replace('_', '-') : CodeFromHttp(res.Status);
            throw new FirestoreException(res.Status, code, Json.Str(err, "message") ?? ("HTTP " + res.Status));
        }

        static string CodeFromHttp(int s)
        {
            switch (s)
            {
                case 400: return "invalid-argument";
                case 401: return "unauthenticated";
                case 403: return "permission-denied";
                case 404: return "not-found";
                case 409: return "aborted";
                case 429: return "resource-exhausted";
                case 503: return "unavailable";
                default: return s >= 500 ? "internal" : "unknown";
            }
        }
    }
}
