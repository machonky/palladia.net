using Palladia.Core;
using System;

namespace Palladia.OLTP
{
    [Serializable]
    public class Resource : Resource<string>
    {
        public Resource(string name, string description)
            : base(name, description)
        {}
    }
}
