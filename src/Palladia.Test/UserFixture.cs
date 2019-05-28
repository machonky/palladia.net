using NUnit.Framework;
using Palladia.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Palladia.Test
{
    [TestFixture]
    public class UserFixture
    {
        [Test]
        public void TestSerialization()
        {
            var id = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var admin = Principal.New(id, "Admin", "Adminstrator");

            var rootId = Guid.Parse("00000000-0000-0000-0000-000000000003");
            var root = new User(rootId, "Root", "The first user of a system");

            root.Principals.Add(admin);

            var tester = new SerializationTester();
            tester.TestSerialization(root, result => 
            {
                Assert.That(result.Id, Is.EqualTo(rootId));
                Assert.That(result.Name, Is.EqualTo("Root"));
                Assert.That(result.Description, Is.EqualTo("The first user of a system"));
                Assert.That(result.Principals.Contains(admin));
            });
        }
    }
}
