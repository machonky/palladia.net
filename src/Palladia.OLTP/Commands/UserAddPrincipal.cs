using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class UserAddPrincipal : Command<AuthorisationModel>
    {
        public string UserName { get; }
        public string PrincipalName { get; }

        public UserAddPrincipal(string userName, string principalName)
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
                    user.Principals.Add(role);
                    RaiseEvent(new UserPrincipalAdded(user, role));
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
