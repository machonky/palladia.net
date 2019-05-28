using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class RemoveUser : Command<AuthorisationModel>
    {
        public Guid UserId { get; private set; }

        public RemoveUser(Guid userId)
        {
            UserId = userId;
        }

        public override void Execute(AuthorisationModel model)
        {
            model.Users.Remove(UserId);
            RaiseEvent(new UserRemoved(UserId));
        }
    }
}
