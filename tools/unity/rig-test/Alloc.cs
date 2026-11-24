// `bench alloc`: what the frames allocate, by type (the runtime's allocation ticks, one per ~100 KB)
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

sealed class AllocListener : EventListener
{
    public readonly Dictionary<string, long> ByType = new Dictionary<string, long>();
    public bool On;
    protected override void OnEventSourceCreated(EventSource s)
    {
        if (s.Name == "Microsoft-Windows-DotNETRuntime") EnableEvents(s, EventLevel.Verbose, (EventKeywords)0x1);
    }
    protected override void OnEventWritten(EventWrittenEventArgs e)
    {
        if (!On || e.EventName == null || !e.EventName.StartsWith("GCAllocationTick")) return;
        int i = e.PayloadNames.IndexOf("TypeName");
        string t = i >= 0 ? e.Payload[i] as string : "?";
        lock (ByType) ByType[t] = (ByType.TryGetValue(t, out var n) ? n : 0) + 1;
    }
}
