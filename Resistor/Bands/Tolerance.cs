using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistor.Bands
{
    //NOTE: None is 20%
    //
    //Tolerance is % (Confidence interval)
    public class Tolerance:Band
    {
        public Tolerance()
        {
            List<BandCode> spectrum = new List<BandCode>();
            spectrum.Add(new BandCode { Order = 0, Value = 1.00, Color = "Brown" });
            spectrum.Add(new BandCode { Order = 1, Value = 2.00, Color = "Red" });
            spectrum.Add(new BandCode { Order = 2, Value = 0.50, Color = "Green" });
            spectrum.Add(new BandCode { Order = 3, Value = 0.25, Color = "Blue" });
            spectrum.Add(new BandCode { Order = 4, Value = 0.10, Color = "Violet" });
            spectrum.Add(new BandCode { Order = 5, Value = 0.05, Color = "Grey/Gray" });
            spectrum.Add(new BandCode { Order = 6, Value = 5.00, Color = "Gold" });
            spectrum.Add(new BandCode { Order = 7, Value = 10.00, Color = "Silver" });
            this.Codes = spectrum;
        }
    }
}