﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Palladia.Core
{
    [Serializable]
    public class HashSetDictionary<TKey, TElement> : IHashSetDictionary<TKey, TElement>
    {
        private readonly Dictionary<TKey, ISetGrouping<TKey, TElement>> innerValues =
            new Dictionary<TKey, ISetGrouping<TKey, TElement>>();

        [Serializable]
        public class SetGrouping<TKey1, TElement1> : HashSet<TElement1>, ISetGrouping<TKey1, TElement1>//, ISerializable
        {
            public SetGrouping(TKey1 key)
            {
                Key = key;
            }
            
            protected SetGrouping(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                Key = (TKey1)info.GetValue("Key", typeof(TKey1));
            }

            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
                info.AddValue("Key", Key);
            }
            
            public TKey1 Key { get; set; }
        }

        protected virtual ISetGrouping<TKey, TElement> CreateGrouping(TKey key)
        {
            return new SetGrouping<TKey, TElement>(key);
        }

        public IEnumerator<ISetGrouping<TKey, TElement>> GetEnumerator()
        {
            return innerValues.Select(keyValuePair => keyValuePair.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TKey key)
        {
            ISetGrouping<TKey, TElement> grouping;
            if (!innerValues.TryGetValue(key, out grouping))
            {
                grouping = CreateGrouping(key);
                innerValues.Add(key, grouping);
            }
        }

        public void Add(TKey key, TElement element)
        {
            ISetGrouping<TKey, TElement> grouping;
            if (!innerValues.TryGetValue(key, out grouping))
            {
                grouping = CreateGrouping(key);
                innerValues.Add(key, grouping);
            }
            grouping.Add(element);
        }

        public void Add(TKey key, ISet<TElement> elements)
        {
            ISetGrouping<TKey, TElement> grouping;
            if (!innerValues.TryGetValue(key, out grouping))
            {
                grouping = CreateGrouping(key);
                innerValues.Add(key, grouping);
            }

            foreach (var element in elements)
            {
                grouping.Add(element);
            }
        }

        public bool Remove(TKey key)
        {
            return innerValues.Remove(key);
        }

        public bool Remove(TKey key, TElement element)
        {
            ISetGrouping<TKey, TElement> grouping;
            if (innerValues.TryGetValue(key, out grouping))
            {
                if (grouping.Remove(element))
                {
                    return true;
                }
            }
            return false;
        }

        public int Remove(TKey key, ISet<TElement> elements)
        {
            int successCount = 0;
            ISetGrouping<TKey, TElement> grouping;
            if (TryGetGrouping(key, out grouping))
            {
                foreach (var element in elements)
                {
                    if (grouping.Remove(element))
                    {
                        ++successCount;
                    }
                }
            }
            return successCount;
        }

        public bool ContainsKey(TKey key)
        {
            return innerValues.ContainsKey(key);
        }

        public bool TryGetGrouping(TKey key, out ISetGrouping<TKey, TElement> grouping)
        {
            return innerValues.TryGetValue(key, out grouping);
        }

        public bool Contains(TKey key)
        {
            return innerValues.ContainsKey(key);
        }

        public int Count
        {
            get { return innerValues.Count; }
        }

        public ISetGrouping<TKey, TElement> this[TKey key]
        {
            get
            {
                ISetGrouping<TKey, TElement> result;
                if (innerValues.TryGetValue(key, out result))
                {
                    return result;
                }

                return CreateGrouping(key);
            }
        }
    }
}
