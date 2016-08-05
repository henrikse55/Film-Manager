using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Shared.Network
{
    class Serilizer
    {
        public static byte[] Serialize(Object o)
        {
            if (o == null)
                throw new NullReferenceException();
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                bf.Serialize(stream, o);
                return stream.ToArray();
            }
        }

        public static Message Deserialize(byte[] buffer)
        {
            if (buffer == null)
                throw new NullReferenceException();

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (Message)bf.Deserialize(stream);
            }
        }
    }
}
