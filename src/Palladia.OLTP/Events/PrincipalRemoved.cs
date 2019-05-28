using System;
using Memstate;

namespace Palladia.OLTP.Events
{
    public class PrincipalRemoved : Event
    {
        public readonly Guid PrincipalId;

        public PrincipalRemoved(Guid principalId)
        {
            this.PrincipalId = principalId;
        }
    }
}