using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Palladia.Test
{
    public class SerializationTester
    {
        public void TestSerialization<T>(T graph, Action<T> assertions)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, graph);
                stream.Seek(0, SeekOrigin.Begin);
                var result = (T)formatter.Deserialize(stream);
                assertions(result);
            }
        }
    }
}
