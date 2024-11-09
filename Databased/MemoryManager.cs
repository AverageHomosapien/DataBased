using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Databased
{
    internal class MemoryManager
    {
        private readonly string filename = "memory2.customdb";
        private const char delimiter = '|';
        private const int delimiterAsByte = 124;

        internal void Save<T>(T obj) where T : class
        {
            byte[] data = ExtractProperties(obj);

            //var dataConv = Convert.ToBase64String(data.Union(new byte[] { delimiterAsByte }).ToArray());
            var dataConv = Convert.ToBase64String(data);

            File.AppendAllText(filename, dataConv);

            //Encoding.UTF8.GetBytes(obj);
        }

        internal byte[] Get()
        {
            return File.ReadAllBytes(filename);
        }

        internal T ParseClass<T>() where T : class
        {

            // Decode the string back to a byte array
            // Can't just read all text as it pulls out multiple objects in a single byte stream...
            // .. then when decoding them will only decode to individual object not any iterable object
            FileStream fs = File.OpenRead(filename);

            List<byte> bytes = new List<byte>();

            List<T> objs = new();

            int readByte = fs.ReadByte();
            while (readByte != -1)
            {
                if (readByte == delimiterAsByte)
                {
                    T obj = ConstructObject<T>(bytes.ToArray());

                    objs.Add(obj);
                    bytes.Clear();
                    continue;
                }
                bytes.Add((byte)readByte);
                readByte = fs.ReadByte();
            }

            return objs.First();
        }

        private T ConstructObject<T>(byte[] decodedObject) where T : class
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));

            // Create a memory stream and pass in the decoded byte array as the parameter
            MemoryStream memoryStream = new MemoryStream(decodedObject);

            // Deserialise byte array back to employees object.
            T employees = (T)dcs.ReadObject(memoryStream);
            return employees;
        }

        private static byte[] ExtractProperties<T>(T obj) where T : class
        {
            var serializer = new DataContractSerializer(typeof(T));
            using var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, obj);
            return memoryStream.ToArray();
        }
    }
}
