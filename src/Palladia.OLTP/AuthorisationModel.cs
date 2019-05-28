using Palladia.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Palladia.OLTP
{
    [Serializable]
    public class AuthorisationModel
    {
        public Dictionary<Guid, Principal> Principals { get; } = new Dictionary<Guid, Principal>();
        public Dictionary<Guid, User> Users { get; } = new Dictionary<Guid, User>();
        public Dictionary<Guid, Resource<string>> Resources { get; } = new Dictionary<Guid, Resource<string>>();
    }
}
