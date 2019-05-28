using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Events
{
    public class UserAdded : Event
    {
        public readonly User NewUser;

        public UserAdded(User newUser)
        {
            NewUser = newUser;
        }
    }
}
