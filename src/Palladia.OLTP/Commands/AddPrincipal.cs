using Memstate;
using Palladia.Core;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class AddPrincipal : Command<AuthorisationModel, Principal>
    {
        public Guid PrincipalId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public AddPrincipal(Guid principalId, string name, string description)
        {
            PrincipalId = principalId;
            Name = name;
            Description = description;
        }

        public override Principal Execute(AuthorisationModel model)
        {
            var result = Principal.New(PrincipalId, Name, Description);
            model.Principals.Add(PrincipalId, result);
            RaiseEvent(new PrincipalAdded(result));
            return result;
        }
    }
}
