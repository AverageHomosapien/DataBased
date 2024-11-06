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
        private readonly string filename = "memory.txt";

        internal void Save<T>(T obj) where T : class
        {
            byte[] data = ExtractProperties<T>(obj);
            using (var stream = new FileStream(filename, FileMode.Append))
            {
                stream.Write(data, 0, data.Length);
            }
        }

        internal byte[] Get()
        {
            return File.ReadAllBytes(filename);
        }

        private byte[] ExtractProperties<T>(T obj) where T : class
        {
            var serializer = new DataContractSerializer(typeof(T));
            using var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, obj);
            return memoryStream.ToArray();
        }
    }
}
