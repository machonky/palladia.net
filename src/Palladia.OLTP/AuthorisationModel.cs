using Palladia.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Palladia.OLTP
{
    [Serializable]
    public class AuthorisationModel
    {
        public Dictionary<string, Principal> Principals { get; } = new Dictionary<string, Principal>();
        public Dictionary<string, User> Users { get; } = new Dictionary<string, User>();
        public Dictionary<string, Resource> Resources { get; } = new Dictionary<string, Resource>();
    }
}
