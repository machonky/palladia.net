using Memstate;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class RemovePrincipal : Command<AuthorisationModel>
    {
        public Guid PrincipalId { get; private set; }

        public RemovePrincipal(Guid userId)
        {
            PrincipalId = userId;
        }

        public override void Execute(AuthorisationModel model)
        {
            model.Principals.Remove(PrincipalId);
            RaiseEvent(new PrincipalRemoved(PrincipalId));
        }
    }
}
