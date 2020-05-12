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
            var formatter = new BinaryFormatter();

            using (var file = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (Plugin == null)
                {
                    formatter.Serialize(file, list);
                }
                else
                {
                    using (var tempStream = new MemoryStream())
                    {
                        formatter.Serialize(tempStream, list);
                        tempStream.Position = 0;
                        var result = Plugin.ProcessOutput(tempStream.ToArray(), FileName);
                        var resultStream = new MemoryStream(result);
                        resultStream.CopyTo(file);
                    }
                }
            }
        }

        public List<Clothes> Deserialize()
        {
            if(File.Exists(FileName))
            {
                var formatter = new BinaryFormatter();
                formatter.Binder = new CustomBinder();

                using (var file = new FileStream(FileName, FileMode.Open))
                {
                    if (Plugin == null)
                    {
                        return formatter.Deserialize(file) as List<Clothes>;
                    }
                    else
                    {
                        var tempStream = new MemoryStream();
                        file.CopyTo(tempStream);
                        var result = Plugin.ProcessInput(tempStream.ToArray(), FileName);
                        var resultStream = new MemoryStream(result);
                        return formatter.Deserialize(resultStream) as List<Clothes>;
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
