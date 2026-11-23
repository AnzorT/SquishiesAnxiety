// The live users/{uid} profile, standing in for subscribeToUserProfile (onSnapshot) in src/firebase/firestore.js.
//
// The REST API has no listener: a real one needs Firestore's gRPC Listen stream (or the WebChannel the JS SDK
// uses), which plain HttpClient can't speak. So for now the feed POLLS the document and also re-reads it right after
// every write this client makes, and applies each write to its copy at once (as the SDK's latency compensation does),
// behind IProfileFeed so a real listener can replace it without touching the app code.
//
// Trade-offs of polling:
//   + no extra dependency, works everywhere HttpClient does, and our own writes show at once (local apply) and are
//     confirmed a round trip later (refresh-after-write);
//   - changes made elsewhere (the Cloud Functions' transactions: spinWheel, squad, verifyPurchase; another device; the
//     console) show up only at the next poll, up to Interval late, unless the caller refreshes after the call (the
//     UserData helpers do for the calls they make);
//   - each poll is a billed document read: one per Interval per open app (15 s ≈ 240 reads an hour), so pause it
//     when the app is in the background (Paused) and keep the interval generous.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SquishSquad.Backend
{
    public interface IProfileFeed : IDisposable
    {
        string Uid { get; }

        // The profile as last seen (null: not read yet, or there's no profile doc). Treat it as read-only: every
        // change arrives as a new map.
        IDictionary<string, object> Current { get; }

        // True once the first read finished (Current is then the answer, null meaning "no profile").
        bool Loaded { get; }

        // onSnapshot's callback: the new profile, or null when there's none (or it can't be read any more).
        event Action<IDictionary<string, object>> Changed;

        // A read that failed (network…); Current stays as it was.
        event Action<Exception> Failed;

        // Re-read now.
        Task Refresh();

        // A write this client is making to the profile: applied to Current at once, then the document is re-read
        // once `write` finishes (and polls in between are ignored, so they can't show the old value).
        Task Track(IDictionary<string, object> update, Task write);
    }

    public sealed class PollingProfileFeed : IProfileFeed
    {
        readonly Firestore fs;
        readonly string path;
        readonly Dispatcher dispatcher = new Dispatcher();
        readonly CancellationTokenSource stop = new CancellationTokenSource();
        readonly object gate = new object();
        IDictionary<string, object> current;
        DateTime? seenUpdate;
        bool seenExists;
        bool loaded;
        int pendingWrites;
        int localVersion; // bumped by every local apply, so a read that started before it doesn't overwrite it
        TimeSpan interval;

        public PollingProfileFeed(Firestore firestore, string uid, TimeSpan? interval = null, bool start = true)
        {
            fs = firestore;
            Uid = uid;
            path = "users/" + uid;
            this.interval = interval ?? TimeSpan.FromSeconds(15);
            if (start) _ = Loop();
        }

        public string Uid { get; }
        public IDictionary<string, object> Current => current;
        public bool Loaded => loaded;
        public event Action<IDictionary<string, object>> Changed;
        public event Action<Exception> Failed;

        // How often it polls (it takes effect after the current wait).
        public TimeSpan Interval
        {
            get => interval;
            set => interval = value < TimeSpan.FromSeconds(1) ? TimeSpan.FromSeconds(1) : value;
        }

        // While paused (app in the background) it doesn't poll; Refresh and writes still work. Unpausing refreshes.
        public bool Paused
        {
            get => paused;
            set
            {
                bool was = paused;
                paused = value;
                if (was && !value) _ = Refresh();
            }
        }

        volatile bool paused;

        async Task Loop()
        {
            try
            {
                await Refresh().ConfigureAwait(false);
                while (!stop.IsCancellationRequested)
                {
                    await Task.Delay(interval, stop.Token).ConfigureAwait(false);
                    if (!paused) await Refresh().ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                // disposed
            }
        }

        public async Task Refresh()
        {
            int version;
            lock (gate) version = localVersion;
            FirestoreDocument doc;
            try
            {
                doc = await fs.Get(path, stop.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (FirestoreException e) when (e.Code == "permission-denied" || e.Code == "unauthenticated")
            {
                // signed out, or not this user's: as onSnapshot's error path does, no profile
                Publish(null, null, false, version, force: true);
                RaiseFailed(e);
                return;
            }
            catch (Exception e)
            {
                RaiseFailed(e);
                return;
            }
            Publish(doc?.Data, doc?.UpdateTime, doc != null, version, force: false);
        }

        void Publish(IDictionary<string, object> data, DateTime? updated, bool exists, int version, bool force)
        {
            IDictionary<string, object> emit;
            lock (gate)
            {
                if (stop.IsCancellationRequested) return;
                // a write of ours is in flight, or landed locally after this read began: its own refresh will tell
                if (!force && (pendingWrites > 0 || version != localVersion)) return;
                bool same = loaded && exists == seenExists && updated == seenUpdate && !force;
                loaded = true;
                seenExists = exists;
                seenUpdate = updated;
                if (same) return;
                current = data;
                emit = data;
            }
            var h = Changed;
            if (h != null) dispatcher.Post(() => h(emit));
        }

        void RaiseFailed(Exception e)
        {
            var h = Failed;
            if (h != null) dispatcher.Post(() => h(e));
        }

        public async Task Track(IDictionary<string, object> update, Task write)
        {
            IDictionary<string, object> emit = null;
            lock (gate)
            {
                pendingWrites++;
                localVersion++;
                if (current != null && update != null)
                {
                    var copy = LocalWrites.DeepCopy(current);
                    LocalWrites.ApplyUpdate(copy, update);
                    current = copy;
                    emit = copy;
                }
            }
            if (emit != null)
            {
                var h = Changed;
                if (h != null) dispatcher.Post(() => h(emit));
            }
            try
            {
                await write.ConfigureAwait(false);
            }
            finally
            {
                lock (gate)
                {
                    pendingWrites--;
                    seenUpdate = null; // whatever the server says next is news
                }
                // the server's copy: confirms the write (or, if it failed, puts the old value back)
                if (Volatile.Read(ref pendingWrites) == 0) await Refresh().ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            stop.Cancel();
        }
    }

    // A Firestore update applied to a local copy, the way the server will apply it (latency compensation).
    public static class LocalWrites
    {
        public static Dictionary<string, object> DeepCopy(IDictionary<string, object> m)
        {
            var o = new Dictionary<string, object>();
            foreach (var kv in m) o[kv.Key] = CopyValue(kv.Value);
            return o;
        }

        static object CopyValue(object v)
        {
            if (v is IDictionary<string, object> m) return DeepCopy(m);
            if (v is IList l && !(v is byte[]))
            {
                var o = new List<object>();
                foreach (var x in l) o.Add(CopyValue(x));
                return o;
            }
            return v;
        }

        // `update`: dotted field paths → values or FieldValues (Update's input).
        public static void ApplyUpdate(IDictionary<string, object> doc, IDictionary<string, object> update)
        {
            foreach (var kv in update)
            {
                var segs = FirestoreValues.SplitPath(kv.Key);
                var m = doc;
                for (int i = 0; i < segs.Count - 1; i++)
                {
                    if (!(m.TryGetValue(segs[i], out var next) && next is IDictionary<string, object> nm))
                    {
                        nm = new Dictionary<string, object>();
                        m[segs[i]] = nm;
                    }
                    m = nm;
                }
                string leaf = segs[segs.Count - 1];
                m.TryGetValue(leaf, out var old);
                if (kv.Value is FieldValue fv)
                {
                    if (fv.Kind == FieldValue.Op.Delete) m.Remove(leaf);
                    else m[leaf] = Transform(old, fv);
                }
                else m[leaf] = Resolve(kv.Value);
            }
        }

        // nested sentinels inside a written map (rare): a transform on nothing
        static object Resolve(object v)
        {
            if (v is FieldValue fv) return Transform(null, fv);
            if (v is IDictionary<string, object> m)
            {
                var o = new Dictionary<string, object>();
                foreach (var kv in m)
                    if (!(kv.Value is FieldValue d && d.Kind == FieldValue.Op.Delete))
                        o[kv.Key] = Resolve(kv.Value);
                return o;
            }
            return CopyValue(Normalize(v));
        }

        static object Transform(object old, FieldValue fv)
        {
            switch (fv.Kind)
            {
                case FieldValue.Op.Increment:
                    return (IsNumber(old) ? Convert.ToDouble(old) : 0) + fv.Amount;
                case FieldValue.Op.ArrayUnion:
                {
                    var list = old is IList l ? new List<object>((IEnumerable<object>)CopyValue(l)) : new List<object>();
                    foreach (var x in fv.Elements)
                    {
                        var nx = Normalize(x);
                        if (!list.Exists(y => Same(y, nx))) list.Add(nx);
                    }
                    return list;
                }
                case FieldValue.Op.ArrayRemove:
                {
                    var list = old is IList l ? new List<object>((IEnumerable<object>)CopyValue(l)) : new List<object>();
                    foreach (var x in fv.Elements)
                    {
                        var nx = Normalize(x);
                        list.RemoveAll(y => Same(y, nx));
                    }
                    return list;
                }
                case FieldValue.Op.ServerTimestamp:
                    return null; // the SDK's default estimate ("none") until the server's arrives
            }
            return old;
        }

        // what the value reads back as: numbers as double
        static object Normalize(object v) => IsNumber(v) && !(v is double) ? Convert.ToDouble(v) : v;

        static bool IsNumber(object v) =>
            v is double || v is int || v is long || v is float || v is short || v is byte || v is uint || v is decimal;

        static bool Same(object a, object b)
        {
            if (a == null || b == null) return a == b;
            if (IsNumber(a) && IsNumber(b)) return Convert.ToDouble(a) == Convert.ToDouble(b);
            return a.Equals(b);
        }
    }
}
