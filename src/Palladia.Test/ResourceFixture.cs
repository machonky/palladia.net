using NUnit.Framework;
using Palladia.Core;
using System;

namespace Palladia.Test
{
    [TestFixture]
    public class ResourceFixture
    {
        [Test]
        public void TestSerialization()
        {
            var id = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var admin = Principal.New(id, "Admin", "Adminstrator");

            var root = new User(Guid.Parse("00000000-0000-0000-0000-000000000003"),
                "Root", "The first user of a system");

            root.Principals.Add(admin);

            var resource = new Resource<string>("Catalog");
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
