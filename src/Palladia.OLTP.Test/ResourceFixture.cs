using NUnit.Framework;
using Palladia.Core;
using Palladia.OLTP;
using System;

namespace Palladia.Test
{
    [TestFixture]
    public class ResourceFixture
    {
        [Test]
        public void TestSerialization()
        {
            var admin = Principal.New("Admin", "Adminstrator");
            var root = new User("Root", "The first user of a system");

            root.Principals.Add(admin);

            var resource = new Resource("Catalog","Description");
            resource.Acl.Grant("Read", Principal.Everyone);
            resource.Acl.Grant("Write", admin);

            var tester = new SerializationTester();
            tester.TestSerialization(resource, result => 
            {
                Assert.IsTrue(result.IsAuthorised("Read", root));
                Assert.IsTrue(result.IsAuthorised("Write", root));
            });
        }
    }
}
