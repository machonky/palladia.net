﻿using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Events
{
    public class UserPrincipalRemoved : Event
    {
        public readonly User User;
        public readonly Principal Role;

        public UserPrincipalRemoved(User user, Principal role)
        {
            Palladia.Core.Ensure.ArgumentIsNotNull(user, nameof(user));
            Palladia.Core.Ensure.ArgumentIsNotNull(role, nameof(role));

            this.User = user;
            this.Role = role;
        }
    }
}