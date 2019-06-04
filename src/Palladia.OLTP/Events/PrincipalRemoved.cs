using System;
using Memstate;

namespace Palladia.OLTP.Events
{
    public class PrincipalRemoved : Event
    {
        public readonly string PrincipalName;

        public PrincipalRemoved(string principalName)
        {
            Palladia.Core.Ensure.ArgumentIsNotNullOrWhitespace(principalName, nameof(principalName));

            this.PrincipalName = principalName;
        }
    }
}