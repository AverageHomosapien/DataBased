namespace Databased
{
    public class CustomDbType
    {
        public byte[] Serialize() 
        {
            using MemoryStream m = new();
            using (BinaryWriter writer = new(m))
            {
                JsonWriter
                foreach (var property in typeof(CustomDbType).GetProperties())
                {
                    var propertyType = property.GetType();
                    if (property == null)
                        continue;

                    Convert.
                    var convertedProperty = Convert.ChangeType(property, propertyType);
                    writer.Write(property.GetValue(property));
                }
            }
            return m.ToArray();
        }

        public static T DeSerialize<T>(byte[] data) where T : class
        {
            T result = new();
            using (MemoryStream m = new(data))
            {
                using BinaryReader reader = new(m);
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(prop, reader.Read());
                }
            }
            return result;
        }
    }
}