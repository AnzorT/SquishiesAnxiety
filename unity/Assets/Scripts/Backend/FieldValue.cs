// firestore.FieldValue's sentinels, as the app uses them: increment, arrayUnion, arrayRemove, serverTimestamp and
// delete. Put one where a value goes in Set / Update data; the client turns it into a field transform (or, for
// Delete, a masked-out field) of the same `:commit` write.
using System;
using System.Collections.Generic;

namespace SquishSquad.Backend
{
    public sealed class FieldValue
    {
        public enum Op
        {
            Increment,
            ArrayUnion,
            ArrayRemove,
            ServerTimestamp,
            Delete,
        }

        public readonly Op Kind;
        public readonly double Amount; // Increment
        public readonly IReadOnlyList<object> Elements; // ArrayUnion / ArrayRemove

        FieldValue(Op kind, double amount = 0, IReadOnlyList<object> elements = null)
        {
            Kind = kind;
            Amount = amount;
            Elements = elements ?? Array.Empty<object>();
        }

        public static FieldValue Increment(double n) => new FieldValue(Op.Increment, n);
        public static FieldValue ArrayUnion(params object[] elements) => new FieldValue(Op.ArrayUnion, 0, (object[])elements.Clone());
        public static FieldValue ArrayRemove(params object[] elements) => new FieldValue(Op.ArrayRemove, 0, (object[])elements.Clone());
        public static readonly FieldValue ServerTimestamp = new FieldValue(Op.ServerTimestamp);
        public static readonly FieldValue Delete = new FieldValue(Op.Delete);

        public override string ToString() => "FieldValue." + Kind;
    }
}
