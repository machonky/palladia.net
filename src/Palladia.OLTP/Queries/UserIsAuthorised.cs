using Memstate;
using Palladia.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Palladia.OLTP.Queries
{
    public class UserIsAuthorised : Query<AuthorisationModel, bool>
    {
        public User User { get; }
        public string Operation { get; }
        public string ResourceName { get; }

        public UserIsAuthorised(User user, string operation, string resourceName)
        {
            Core.Ensure.ArgumentIsNotNull(user, nameof(user));
            Core.Ensure.ArgumentIsNotNullOrWhitespace(operation, nameof(operation));
            Core.Ensure.ArgumentIsNotNullOrWhitespace(resourceName, nameof(resourceName));

            User = user;
            Operation = operation;
            ResourceName = resourceName;
        }

        public override bool Execute(AuthorisationModel db)
        {
            if (db.Resources.TryGetValue(ResourceName, out var resource))
            {
                return resource.IsAuthorised(Operation, User);
            }

            return false;
        }
    }
}
