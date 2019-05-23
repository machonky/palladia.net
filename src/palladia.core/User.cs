using System;

namespace Palladia.Core
{
    [Serializable]
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public User()
        {
            Principals.Add(Principal.Everyone);
            Principals.Add(this.AsPrincipal());
        }

        public PrincipalSet Principals { get; } = new PrincipalSet();
    }

    public static class UserExtensions
    {
        public static Principal AsPrincipal(this User user)
        {
            return Principal.New(user.Id, user.Name, string.Empty);
        }
    }
}
