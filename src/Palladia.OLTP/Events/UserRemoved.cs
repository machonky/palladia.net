using Memstate;
using System;

namespace Palladia.OLTP.Events
{
    public class UserRemoved : Event
    {
        public readonly string UserName;

        public UserRemoved(string userName)
        {
            Palladia.Core.Ensure.ArgumentIsNotNullOrWhitespace(userName, nameof(userName));

            this.UserName = userName;
        }
    }
}
