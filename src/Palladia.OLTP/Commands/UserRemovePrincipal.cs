using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class UserRemovePrincipal : Command<AuthorisationModel>
    {
        public Guid UserId { get; private set; }
        public Guid PrincipalId { get; private set; }

        public UserRemovePrincipal(Guid userId, Guid principalId)
        {
            UserId = userId;
            PrincipalId = principalId;
        }

        public override void Execute(AuthorisationModel model)
        {
            if (model.Users.TryGetValue(UserId, out var user))
            {
                if (model.Principals.TryGetValue(PrincipalId, out var role))
                {
                    user.Principals.Remove(role);
                    RaiseEvent(new UserPrincipalRemoved(user, role));
                }
                else
                {
                    throw new PrincipalNotFoundException(PrincipalId);
                }
            }
            else
            {
                throw new UserNotFoundException(UserId);
            }
        }
    }
}
