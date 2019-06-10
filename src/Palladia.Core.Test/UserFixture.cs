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
            var admin = Principal.New("Admin", "Adminstrator");

            var root = new User("Root", "The first user of a system");

            root.Principals.Add(admin);

            var tester = new SerializationTester();
            tester.TestSerialization(root, result => 
            {
                Assert.That(result.Name, Is.EqualTo("Root"));
                Assert.That(result.Description, Is.EqualTo("The first user of a system"));
                Assert.That(result.Principals.Contains(admin));
            });
        }
    }
}
