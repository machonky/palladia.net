using Memstate;
using Palladia.Core;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class AddUser : Command<AuthorisationModel, User>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public AddUser(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override User Execute(AuthorisationModel model)
        {
            var result = new User(Name, Description);
            model.Users.Add(Name, result);
            RaiseEvent(new UserAdded(result));
            return result;
        }
    }


}
