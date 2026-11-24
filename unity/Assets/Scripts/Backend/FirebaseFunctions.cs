// Callable Cloud Functions over plain HTTPS, exactly as src/firebase/callFunction.js does it: POST { data } with the
// signed-in user's ID token, resolve with `result`, fail with `error.message`. Region us-central1.
//   callFunction('spinWheel', { tzOffsetMinutes, bonus })  → Functions.Call("spinWheel", new Dictionary<…> { … })
//   squad/api.js callFunction('squad', { move, … })        → Functions.Call("squad", …)
// The result comes back as the JSON shape (Dictionary<string, object> / List<object> / double / bool / string).
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SquishSquad.Backend
{
    public sealed class FunctionsException : Exception
    {
        public readonly int Status; // HTTP status (0: no response)
        public readonly string Code; // the callable's status: "unauthenticated", "failed-precondition"… (null if none)
        public readonly object Details; // error.details, if the function sent any

        public FunctionsException(int status, string code, string message, object details = null, Exception inner = null)
            : base(message, inner)
        {
            Status = status;
            Code = code;
            Details = details;
        }
    }

    public sealed class FirebaseFunctions
    {
        readonly FirebaseConfig cfg;
        readonly IHttp http;
        readonly FirebaseAuth auth;

        public FirebaseFunctions(FirebaseConfig config, IHttp http, FirebaseAuth auth)
        {
            cfg = config;
            this.http = http;
            this.auth = auth;
        }

        public async Task<object> Call(string name, IDictionary<string, object> data = null, CancellationToken cancel = default)
        {
            if (auth.CurrentUser == null) throw new FunctionsException(0, "unauthenticated", "Not signed in");
            string token = await auth.GetIdToken(false, cancel).ConfigureAwait(false);
            var req = new HttpRequest
            {
                Method = "POST",
                Url = cfg.FunctionUrl(name),
                Body = Json.Write(new Dictionary<string, object> { { "data", data ?? new Dictionary<string, object>() } }),
            };
            req.Headers["Authorization"] = "Bearer " + token;
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
                throw new FunctionsException(0, "unavailable", "Network error: " + e.Message, null, e);
            }
            var body = Json.TryParse(res.Body) as Dictionary<string, object> ?? new Dictionary<string, object>();
            var err = Json.Get(body, "error");
            if (!res.Ok || err != null)
            {
                string status = Json.Str(err, "status");
                throw new FunctionsException(res.Status, status?.ToLowerInvariant().Replace('_', '-'),
                    Json.Str(err, "message") ?? ("HTTP " + res.Status), Json.Get(err, "details"));
            }
            return Json.Get(body, "result");
        }

        // Call, with the result as a map (null when the function returned something else).
        public async Task<Dictionary<string, object>> CallMap(string name, IDictionary<string, object> data = null, CancellationToken cancel = default) =>
            await Call(name, data, cancel).ConfigureAwait(false) as Dictionary<string, object>;
    }
}
