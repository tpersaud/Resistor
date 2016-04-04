using System.Collections.Generic;

namespace Resistor
{
    public interface IResistor
    {
        ResistorType GetBand(int bandCount);
        void Update(List<int> value);
    }
}