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

        internal void Save<T>(T obj) where T : class
        {
            byte[] data = ExtractProperties(obj);

            var dataConv = Convert.ToBase64String(data);

            File.AppendAllText(filename, dataConv);

            //using var stream = new FileStream(filename, FileMode.Append);
            ////stream.Position = 0;
            //foreach (byte b in data)
            //{
            //    stream.WriteByte(b);
            //}
        }

        internal byte[] Get()
        {
            return File.ReadAllBytes(filename);
        }

        internal T ParseClass<T>() where T : class
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));

            // Decode the string back to a byte array
            byte[] decodedObject = Convert.FromBase64String(File.ReadAllText(filename));

            // Create a memory stream and pass in the decoded byte array as the parameter
            MemoryStream memoryStream = new MemoryStream(decodedObject);

            foreach(var rootNode in memoryStream.)
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
