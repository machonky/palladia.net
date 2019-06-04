using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class RemoveUser : Command<AuthorisationModel>
    {
        public string UserName { get; }

        public RemoveUser(string userName)
        {
            UserName = userName;
        }

        public override void Execute(AuthorisationModel model)
        {
            model.Users.Remove(UserName);
            RaiseEvent(new UserRemoved(UserName));
        }
    }
}
