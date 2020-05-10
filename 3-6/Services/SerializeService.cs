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

        private IFunctionalPlugin Plugin { get; set; }

        public SerializeService(string fileName, IFunctionalPlugin plugin)
        {
            Plugin = plugin;
            FileName = fileName;
        }

        public void Serialize(List<Clothes> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (var file = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (Plugin == null)
                {
                    formatter.Serialize(file, list);
                }
                else
                {
                    var tempStream = new MemoryStream();

                    formatter.Serialize(tempStream, list);
                    var byteArr = Plugin.ProcessOutput(tempStream.ToArray());
                    file.Write(byteArr, 0, byteArr.Length);
                }
            }
        }

        public List<Clothes> Deserialize()
        {
            if(File.Exists(FileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var file = new FileStream(FileName, FileMode.Open))
                {
                    if (Plugin == null)
                    {
                        return formatter.Deserialize(file) as List<Clothes>;
                    }
                    else
                    {
                        var tempStream = new MemoryStream();
                        var byteArr = new byte[file.Length];

                        file.Read(byteArr, 0, byteArr.Length);
                        byteArr = Plugin.ProcessInput(byteArr);
                        tempStream.Write(byteArr, 0, byteArr.Length);
                        tempStream.Position = 0;
                        return formatter.Deserialize(tempStream) as List<Clothes>;
                    }
                }
            } 
            else
            {
                return null;
            }
        }
    }
}
