using NUnit.Framework;
using Palladia.Core;

namespace Palladia.Test
{
    [TestFixture]
    public class HashSetDictionaryFixture
    {
        [Test]
        public void TestSerialization()
        {
            var lookup = new HashSetDictionary<string, string>();
            lookup.Add("zoo", "zebra");
            var tester = new SerializationTester();
            tester.TestSerialization(lookup, result => 
            {
                Assert.IsTrue(result["zoo"].Contains("zebra"));
            });
        }
    }
}
