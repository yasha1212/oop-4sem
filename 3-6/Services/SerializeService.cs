using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ThirdLaboratory
{
    public class SerializeService : ISerializer
    {
        private string FileName { get; set; }

        private List<IFunctionalPlugin> Plugins { get; set; }

        public SerializeService(string fileName, List<IFunctionalPlugin> plugins)
        {
            Plugins = plugins;
            FileName = fileName;
        }

        public void Serialize(List<Clothes> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream file = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, list);
            }
        }

        public List<Clothes> Deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if(File.Exists(FileName))
            {
                using(FileStream file = new FileStream(FileName, FileMode.Open))
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
