using Memstate;
using System;

namespace Palladia.OLTP.Events
{
    public class UserRemoved : Event
    {
        public readonly Guid UserId;

        public UserRemoved(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
