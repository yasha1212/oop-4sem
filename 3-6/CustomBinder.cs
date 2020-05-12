using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Reflection;

namespace ThirdLaboratory
{
    class CustomBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly currAsm = Assembly.GetExecutingAssembly();
            return Type.GetType($"{currAsm.GetName().Name}.{typeName.Split('.')[1]}");
        }
    }
}
