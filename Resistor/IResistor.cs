using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistor
{
    public interface IResistor
    {
        ResistorType GetBand(int bandCount);
        void Update(List<int> value);
    }
}