using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLaboratory
{
    public interface IFunctionalPlugin
    {
        byte[] ProcessOutput(byte[] data);

        byte[] ProcessInput(byte[] data);
    }
}
