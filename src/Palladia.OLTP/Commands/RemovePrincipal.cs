using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class RemovePrincipal : Command<AuthorisationModel>
    {
        public string PrincipalName { get; }

        public RemovePrincipal(string name)
        {
            PrincipalName = name;
        }

        public override void Execute(AuthorisationModel model)
        {
            model.Principals.Remove(PrincipalName);
            RaiseEvent(new PrincipalRemoved(PrincipalName));
        }
    }
}
