using System;

namespace Palladia.Core
{
    [Serializable]
    public class Principal
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        private Principal(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static Principal New(Guid id, string name, string description)
        {
            return new Principal(id, name, description);
        }

        public static readonly Principal Everyone = Principal.New(Guid.Empty, "Everyone", "A role representing all users");

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
