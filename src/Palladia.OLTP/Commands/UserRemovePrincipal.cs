using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class UserRemovePrincipal : Command<AuthorisationModel>
    {
        public string UserName { get; }
        public string PrincipalName { get; }

        public UserRemovePrincipal(string userName, string principalName)
        {
            UserName = userName;
            PrincipalName = principalName;
        }

        public override void Execute(AuthorisationModel model)
        {
            if (model.Users.TryGetValue(UserName, out var user))
            {
                if (model.Principals.TryGetValue(PrincipalName, out var role))
                {
                    user.Principals.Remove(role);
                    RaiseEvent(new UserPrincipalRemoved(user, role));
                }
                else
                {
                    throw new PrincipalNotFoundException(PrincipalName);
                }
            }
            else
            {
                throw new UserNotFoundException(UserName);
            }
        }
    }
}
