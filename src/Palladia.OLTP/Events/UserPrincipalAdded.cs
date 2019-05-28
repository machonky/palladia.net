using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Events
{
    public class UserPrincipalAdded : Event
    {
        public readonly User User;
        public readonly Principal Role;

        public UserPrincipalAdded(User user, Principal role)
        {
            this.User = user;
            this.Role = role;
        }
    }
}
