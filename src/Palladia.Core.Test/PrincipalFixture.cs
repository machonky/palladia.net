using NUnit.Framework;
using Palladia.Core;
using System;
using System.Linq;

namespace Palladia.Test
{
    [TestFixture]
    public class PrincipalFixture
    {
        [Test]
        public void TestSerialization()
        {
            var admin = Principal.New("Admin", "Adminstrator");
            var tester = new SerializationTester();
            tester.TestSerialization(admin, result =>
            {
                Assert.That(result.Name, Is.EqualTo("Admin"));
                Assert.That(result.Description, Is.EqualTo("Adminstrator"));
            });

            var principals = new PrincipalSet();
            principals.Add(admin);

            var setTester = new SerializationTester();
            setTester.TestSerialization(principals, result =>
            {
                Assert.That(result.Count, Is.EqualTo(1));
                var first = result.First();
                Assert.That(first.Name, Is.EqualTo("Admin"));
                Assert.That(first.Description, Is.EqualTo("Adminstrator"));
            });
        }
    }
}
