using Memstate;
using Palladia.Core;
using Palladia.OLTP.Events;
using System;

namespace Palladia.OLTP.Commands
{
    public class AddUser : Command<AuthorisationModel, User>
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public AddUser(Guid userId, string name, string description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }

        public override User Execute(AuthorisationModel model)
        {
            var result = new User(UserId, Name, Description);
            model.Users.Add(UserId, result);
            RaiseEvent(new UserAdded(result));
            return result;
        }
    }


}
