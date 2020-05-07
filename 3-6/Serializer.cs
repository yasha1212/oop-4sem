using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ThirdLaboratory
{
    public static class Serializer
    {
        public static void Serialize(string fileName, List<Clothes> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, list);
            }
        }

        public static List<Clothes> Deserialize(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if(File.Exists(fileName))
            {
                using(FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    return (List<Clothes>)formatter.Deserialize(file);
                }
            } 
            else
            {
                return null;
            }
        }
    }
}
