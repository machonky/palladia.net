using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Events
{
    public class UserPrincipalRemoved : Event
    {
        public readonly User User;
        public readonly Principal Role;

        public UserPrincipalRemoved(User user, Principal role)
        {
            this.User = user;
            this.Role = role;
        }
    }
}