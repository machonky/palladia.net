using Palladia.Core;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Palladia.Test
{
    class Program
    {
        static void _Main(string[] args) // De-activated
        {
            var lookup = new HashSetDictionary<string, string>();
            lookup.Add("zoo", "zebra");
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, lookup);

                stream.Seek(0, SeekOrigin.Begin);
                var result = (HashSetDictionary<string, string>)formatter.Deserialize(stream);

                Console.WriteLine(lookup["zoo"].Contains("zebra"));
            }

            Console.ReadKey();
        }
    }
}
