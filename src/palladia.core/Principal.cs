using System;

namespace Palladia.Core
{
    [Serializable]
    public class Principal
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }

        private Principal(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static Principal New(string id, string name, string description)
        {
            return new Principal(id, name, description);
        }

        public static readonly Principal Everyone = Principal.New("Principal.Everyone", "Everyone", "A role representing all users");

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as Principal;
            if (rhs != null)
            {
                return Id.Equals(rhs.Id);
            }

            return false;
        }
    }
}
