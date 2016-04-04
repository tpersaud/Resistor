using System;

namespace Resistor.Bands
{
    public class BandCode
    {
        public string Color { get; set; }
        public double Value { get; set; }
        public short Order { get; set; }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            BandCode p = obj as BandCode;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Value == p.Value) && (Order == p.Order) && (String.Equals(Color, p.Color));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}