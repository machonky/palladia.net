using System.Collections.Generic;

namespace Palladia.Core
{
    public interface IHashSetDictionary<TKey, TElement> : IEnumerable<ISetGrouping<TKey, TElement>>
    {
        bool Contains(TKey key);
        int Count { get; }
        ISetGrouping<TKey, TElement> this[TKey key] { get; }
    }
}
