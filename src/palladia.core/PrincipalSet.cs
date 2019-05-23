using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Palladia.Core
{
    [Serializable]
    public class PrincipalSet : HashSet<Principal>
    {
        public PrincipalSet()
        { }

        protected PrincipalSet(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
