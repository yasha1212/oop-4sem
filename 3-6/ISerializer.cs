using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLaboratory
{
    interface ISerializer
    {
        void Serialize(List<Clothes> list);

        List<Clothes> Deserialize();
    }
}
