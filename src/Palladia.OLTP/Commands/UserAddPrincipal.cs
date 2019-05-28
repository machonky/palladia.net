using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class UserAddPrincipal : Command<AuthorisationModel>
    {
        public Guid UserId { get; private set; }
        public Guid PrincipalId { get; private set; }

        public UserAddPrincipal(Guid userId, Guid principalId)
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
                    user.Principals.Add(role);
                    RaiseEvent(new UserPrincipalAdded(user, role));
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
