using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistor
{
    public interface IResistor
    {
        public ResistorType GetBand(int bandCount);
        public void Update(List<int> value);
        public string CalculateResult();
    }
}