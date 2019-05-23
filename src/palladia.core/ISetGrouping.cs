using System.Collections.Generic;

namespace Palladia.Core
{
    public interface ISetGrouping<out TKey, TElement> : ISet<TElement>
    {
        TKey Key { get; }
    }
}
