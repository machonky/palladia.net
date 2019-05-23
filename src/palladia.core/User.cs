using System;

namespace Palladia.Core
{
    [Serializable]
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PrincipalSet Principals { get; } = new PrincipalSet();
    }

    public static class UserExtensions
    {

    }
}
