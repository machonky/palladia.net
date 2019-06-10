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
            var admin = Principal.New("Admin", "Adminstrator");
            var root = new User("Root","The first user of a system");

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
