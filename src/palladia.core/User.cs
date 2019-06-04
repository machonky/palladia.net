using System;

namespace Palladia.Core
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public User(string name, string description)
        {
            Name = name;
            Description = description;

            Principals.Add(Principal.Everyone);
            Principals.Add(this.AsPrincipal());
        }

        public PrincipalSet Principals { get; } = new PrincipalSet();
    }

    public static class UserExtensions
    {
        public static Principal AsPrincipal(this User user)
        {
            return Principal.New(user.Name, string.Empty);
        }
    }
}
