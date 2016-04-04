using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistor.Bands;

namespace Resistor
{
    public class Interval
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public void BuildInterval(long ohm, double tolerancePercentage)
        {
            this.Min = (ohm - (ohm * tolerancePercentage));
            this.Max = (ohm + (ohm * tolerancePercentage));
        }
    }

    public class Resistor: IResistor
    {
        public int Digit { get; set; }
        public int Multiplier { get; set; }
        public double? Tolerance { get; set; }
        public double? Temperature { get; set; }
        public long Ohm { get; set; }
        public Interval Confidence { get; set; }

        public Resistor()
        {
            this.Digit = 0;
            this.Multiplier = 0;
            this.Tolerance = null;
            this.Temperature = null;
            this.Ohm = 0;
            this.Confidence = new Interval();
        }

        public ResistorType GetBand(int bandCount)
        {
            return new ResistorType(bandCount);
        }

        public void Update(List<int> value)
        {
            try
            {
                Validate.ValidateCalculationParameters(value);
                ParseResistor(value);
                CalculateResults();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ParseResistor(List<int> value)
        {
            this.Digit = Parse.ParseDigits(value);
            this.Multiplier = Parse.ParseMultiplier(value);

            if (value.Count > 3)
            {
                this.Tolerance = Parse.ParseTolerance(value);

                if (value.Count == 6)
                    this.Temperature = Parse.ParseTolerance(value);
            }
        }

        private void CalculateResults()
        {            
            this.Ohm = (Digit * 10 ^ Multiplier);

            if (Tolerance == null)
                this.Tolerance = 0.2;

            this.Confidence.BuildInterval(this.Ohm, (double) this.Tolerance);
        }
    }

    internal static class Validate
    {
        public static void ValidateCalculationParameters(List<int> value)
        {
            try
            {
                Validate.ValidateCount(value.Count);

                Digit digit = new Digit();
                Multiplier multiplier = new Multiplier();
                digit.Validate(value[0]);
                digit.Validate(value[1]);

                if (value.Count < 5)
                {
                    multiplier.Validate(value[2]);

                    if (value.Count == 4)
                    {
                        Tolerance tolerance = new Tolerance();
                        tolerance.Validate(value[3]);
                    }
                }
                else
                {
                    digit.Validate(value[2]);
                    multiplier.Validate(value[3]);
                    Tolerance tolerance = new Tolerance();
                    tolerance.Validate(value[4]);

                    if (value.Count == 6)
                    {
                        Temperature temperature = new Temperature();
                        temperature.Validate(value[5]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ValidateCount(int count)
        {
            if (count < 3)
                throw new InvalidOperationException("Too Few Numbers");

            if (count > 6)
                throw new InvalidOperationException("Too Many Numbers");
        }
    }

    internal static class Parse
    {
        public static int ParseDigits(List<int> value)
        {
            int result = 0;
            int max = 2;

            Digit digit = new Digit();

            if (value.Count > 4)
                max = 3;

            for (int i = 0; i < max; i++)
            {
                var exp = max - i - 1;
                result += (Convert.ToInt32(digit.GetValue(value[i])) * 10 ^ (exp));
            }

            return result;
        }

        public static int ParseMultiplier(List<int> value)
        {
            int result = 0;
            Multiplier multiplier = new Multiplier();

            if (value.Count < 5)
                result = Convert.ToInt32(multiplier.GetValue(value[2]));
            else
                result = Convert.ToInt32(multiplier.GetValue(value[3]));

            return result;
        }

        public static double ParseTolerance(List<int> value)
        {
            double result = 0;
            Tolerance tolerance = new Tolerance();

            if (value.Count == 4)
                result = tolerance.GetValue(value[3]);
            else
                result = tolerance.GetValue(value[4]);

            return result;
        }

        public static double ParseTemperature(List<int> value)
        {
            double result = 0;

            if (value.Count == 6)
            {
                Temperature temperature = new Temperature();
                result = temperature.GetValue(value[5]);
            }

            return result;
        }
    }
}