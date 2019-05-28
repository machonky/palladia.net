using NUnit.Framework;
using Palladia.Core;
using System;

namespace Palladia.Test
{
    [TestFixture]
    public class AccessControlListFixture
    {
        [Test]
        public void TestSerialization()
        {
            var id = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var admin = Principal.New(id, "Admin", "Adminstrator");

            var root = new User(Guid.Parse("00000000-0000-0000-0000-000000000003"), 
                "Root","The first user of a system");

            root.Principals.Add(admin);

            var acl = new AccessControlList<string>();
            acl.Grant("Register", admin);
            acl.Deny("Delete", admin);

            var tester = new SerializationTester();
            tester.TestSerialization(acl, result => 
            {
                Assert.IsTrue(result.IsGranted("Register", root));
                Assert.IsTrue(result.IsDenied("Delete", root));
            });
        }
    }
}
