using NUnit.Framework;
using Resistor.Bands;
using System.Collections.Generic;

namespace Resistor.Tests
{
    [TestFixture]
    public class MultiplierTests
    {
        [Test]
        public void ShouldValidateBandColorList()
        {
            List<BandCode> multiplierColorList = new List<BandCode>();
            multiplierColorList.Add(new BandCode { Order = 0, Value = 0.00, Color = "Black" });
            multiplierColorList.Add(new BandCode { Order = 1, Value = 1.00, Color = "Brown" });
            multiplierColorList.Add(new BandCode { Order = 2, Value = 2.00, Color = "Red" });
            multiplierColorList.Add(new BandCode { Order = 3, Value = 3.00, Color = "Orange" });
            multiplierColorList.Add(new BandCode { Order = 4, Value = 4.00, Color = "Yellow" });
            multiplierColorList.Add(new BandCode { Order = 5, Value = 5.00, Color = "Green" });
            multiplierColorList.Add(new BandCode { Order = 6, Value = 6.00, Color = "Blue" });
            multiplierColorList.Add(new BandCode { Order = 7, Value = 7.00, Color = "Violet" });
            multiplierColorList.Add(new BandCode { Order = 8, Value = 8.00, Color = "Grey/Gray" });
            multiplierColorList.Add(new BandCode { Order = 9, Value = 9.00, Color = "White" });
            multiplierColorList.Add(new BandCode { Order = 10, Value = 0.10, Color = "Gold" });
            multiplierColorList.Add(new BandCode { Order = 11, Value = 0.01, Color = "Silver" });

            var sut = new Multiplier();
            CollectionAssert.AreEqual(sut.Codes, multiplierColorList);
        }
    }
}