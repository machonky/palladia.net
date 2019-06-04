using System;

namespace Palladia.Core
{
    [Serializable]
    public class Principal
    {
        public string Name { get; }
        public string Description { get; }

        private Principal(string name, string description)
        {
            Ensure.ArgumentIsNotNull(name, nameof(name));

            Name = name;
            Description = description;
        }

        public static Principal New(string name, string description)
        {
            return new Principal(name, description);
        }

        public static readonly Principal Everyone = Principal.New(
            "Everyone", "A role representing all users");

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as Principal;
            if (rhs != null)
            {
                return Name.Equals(rhs.Name);
            }

            return false;
        }
    }
}
