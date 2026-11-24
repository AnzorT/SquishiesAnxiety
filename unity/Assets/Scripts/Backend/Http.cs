// The transport under the Firebase REST client: one small interface, so tests (or a UnityWebRequest version, should
// HttpClient ever misbehave on a platform) can stand in for it.
//
// HttpClient works in Unity 6 on the Mono and IL2CPP backends (Android and iOS included) and on desktop; it does NOT
// work on WebGL (no sockets there): a WebGL build would need an IHttp over UnityWebRequest.
//
// Threading: everything here is Task-based. Internally the client awaits with ConfigureAwait(false), so its own work
// runs on the thread pool; a caller that awaits from Unity's main thread comes back on the main thread (Unity
// installs a SynchronizationContext there), so `await auth.LoginWithEmail(...)` in a MonoBehaviour can touch
// GameObjects afterwards. Events (AuthStateChanged, IProfileFeed.Changed) are posted to the SynchronizationContext
// that was current when the object was made: construct FirebaseAuth / the profile feed on the main thread.
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SquishSquad.Backend
{
    public sealed class HttpRequest
    {
        public string Method = "GET";
        public string Url;
        public Dictionary<string, string> Headers = new Dictionary<string, string>();
        public string Body; // null: no body
        public string ContentType = "application/json";
    }

    public sealed class HttpResult
    {
        public int Status; // 0: no response (network down, timeout)
        public string Body;
        public bool Ok => Status >= 200 && Status < 300;
    }

    public interface IHttp
    {
        // Resolves with whatever status came back; throws (HttpRequestException / TaskCanceledException) only when
        // there was no response at all.
        Task<HttpResult> Send(HttpRequest request, CancellationToken cancel = default);
    }

    public sealed class HttpClientHttp : IHttp, IDisposable
    {
        readonly HttpClient client;

        public HttpClientHttp(TimeSpan? timeout = null, HttpMessageHandler handler = null)
        {
            client = handler != null ? new HttpClient(handler) : new HttpClient();
            client.Timeout = timeout ?? TimeSpan.FromSeconds(20);
        }

        public async Task<HttpResult> Send(HttpRequest request, CancellationToken cancel = default)
        {
            using (var msg = new HttpRequestMessage(new HttpMethod(request.Method), request.Url))
            {
                if (request.Body != null)
                    msg.Content = new StringContent(request.Body, Encoding.UTF8, request.ContentType ?? "application/json");
                foreach (var h in request.Headers)
                    if (!msg.Headers.TryAddWithoutValidation(h.Key, h.Value) && msg.Content != null)
                        msg.Content.Headers.TryAddWithoutValidation(h.Key, h.Value);
                using (var res = await client.SendAsync(msg, cancel).ConfigureAwait(false))
                {
                    string body = res.Content != null ? await res.Content.ReadAsStringAsync().ConfigureAwait(false) : "";
                    return new HttpResult { Status = (int)res.StatusCode, Body = body };
                }
            }
        }

        public void Dispose() => client.Dispose();
    }

    // Raises callbacks on the SynchronizationContext captured at construction (Unity's main thread), or inline when
    // there was none (a console test).
    internal sealed class Dispatcher
    {
        readonly SynchronizationContext ctx = SynchronizationContext.Current;

        public void Post(Action a)
        {
            if (a == null) return;
            if (ctx == null || ctx == SynchronizationContext.Current) a();
            else ctx.Post(_ => a(), null);
        }
    }
}
