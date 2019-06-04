using Memstate;
using Palladia.Core;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class AddPrincipal : Command<AuthorisationModel, Principal>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public AddPrincipal(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override Principal Execute(AuthorisationModel model)
        {
            var result = Principal.New(Name, Description);
            model.Principals.Add(Name, result);
            RaiseEvent(new PrincipalAdded(result));
            return result;
        }
    }
}
