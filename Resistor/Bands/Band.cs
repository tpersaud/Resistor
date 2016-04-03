using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistor.Bands
{
    public abstract class Band
    {
        public List<BandCode> Codes { get; set; }

        public void Validate(int order)
        { 
            if(!this.Codes.Any(r => r.Order == order))
                throw new InvalidOperationException("Invalid Selection");
        }

        public double GetValue(int order)
        {
            return this.Codes.Where(r => r.Order == order).FirstOrDefault().Value;
        }

    }
}