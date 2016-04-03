using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistor.Bands
{
    //NOTE: SI Unit is ppm/C
    public class Temperature:Band
    {
        public Temperature()
        {
            List<BandCode> spectrum = new List<BandCode>();
            spectrum.Add(new BandCode { Order = 0, Value = 100.00, Color = "Brown" });
            spectrum.Add(new BandCode { Order = 1, Value = 50.00, Color = "Red" });
            spectrum.Add(new BandCode { Order = 2, Value = 15.00, Color = "Orange" });
            spectrum.Add(new BandCode { Order = 3, Value = 25.00, Color = "Yellow" });
            this.Codes = spectrum;
        }
    }
}