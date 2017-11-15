using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class SerialTools
    {
        public static void SerializeSoap(string filename, object o)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            SoapFormatter soapf = new SoapFormatter();

            soapf.Serialize(fs, o); // for any object

            fs.Close();
        }

        public static object DeserializeSoap(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            SoapFormatter soapf = new SoapFormatter();

            object o = soapf.Deserialize(fs);

            fs.Close();
            return o;

        }

        public static void SerializeBin(string filename, object o)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter binf = new BinaryFormatter();

            binf.Serialize(fs, o); // for any object

            fs.Close();
        }

        public static object DeserializeBin(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter binf = new BinaryFormatter();

            object o = binf.Deserialize(fs);

            fs.Close();
            return o;

        }
    }
}
