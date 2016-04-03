using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistor.Bands
{
    /// <summary>
    /// NOTE: NUMBER OF ZEROS IN 10^X
    /// </summary>
    public class Multiplier:Band
    {
        public Multiplier()
        {
            List<BandCode> spectrum = new List<BandCode>();
            spectrum.Add(new BandCode { Order = 0, Value = 0.00, Color = "Black" });
            spectrum.Add(new BandCode { Order = 1, Value = 1.00, Color = "Brown" });
            spectrum.Add(new BandCode { Order = 2, Value = 2.00, Color = "Red" });
            spectrum.Add(new BandCode { Order = 3, Value = 3.00, Color = "Orange" });
            spectrum.Add(new BandCode { Order = 4, Value = 4.00, Color = "Yellow" });
            spectrum.Add(new BandCode { Order = 5, Value = 5.00, Color = "Green" });
            spectrum.Add(new BandCode { Order = 6, Value = 6.00, Color = "Blue" });
            spectrum.Add(new BandCode { Order = 7, Value = 7.00, Color = "Violet" });
            spectrum.Add(new BandCode { Order = 8, Value = 8.00, Color = "Grey/Gray" });
            spectrum.Add(new BandCode { Order = 9, Value = 9.00, Color = "White" });
            spectrum.Add(new BandCode { Order = 10, Value = 0.10, Color = "Gold" });
            spectrum.Add(new BandCode { Order = 11, Value = 0.01, Color = "Silver" });
            this.Codes = spectrum;
        }
    }
}