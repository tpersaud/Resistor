using System;
using System.Collections.Generic;
using Resistor.Bands;

namespace Resistor
{
    //NOTE: count is number of bands in resistor
    public class ResistorType
    {
        public List<Band> Bands { get; set; }

        public ResistorType(int count)
        {
            Validate.ValidateCount(count);

            Bands.AddRange(ConstructDigitBands(count));
            Bands.Add(new Multiplier());

            if(count > 3)
                Bands.Add(new Tolerance());

            if(count > 5)
                Bands.Add(new Temperature());
        }

        private List<Digit> ConstructDigitBands(int count)
        {
            List<Digit> digitBands = new List<Digit>();
            digitBands.Add(new Digit(0));
            digitBands.Add(new Digit(1));

            if (count > 4)
                digitBands.Add(new Digit(2));

            return digitBands;
        }
    }
}