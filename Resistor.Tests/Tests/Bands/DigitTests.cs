using NUnit.Framework;
using System.Collections.Generic;
using Resistor.Bands;

namespace Resistor.Tests
{
    [TestFixture]
    public class DigitTests
    {
        [Test]
        public void ShouldValidateBandColorList()
        {
            List<BandCode> digitColorList = new List<BandCode>();
            digitColorList.Add(new BandCode { Order = 0, Value = 0.00, Color = "Black" });
            digitColorList.Add(new BandCode { Order = 1, Value = 1.00, Color = "Brown" });
            digitColorList.Add(new BandCode { Order = 2, Value = 2.00, Color = "Red" });
            digitColorList.Add(new BandCode { Order = 3, Value = 3.00, Color = "Orange" });
            digitColorList.Add(new BandCode { Order = 4, Value = 4.00, Color = "Yellow" });
            digitColorList.Add(new BandCode { Order = 5, Value = 5.00, Color = "Green" });
            digitColorList.Add(new BandCode { Order = 6, Value = 6.00, Color = "Blue" });
            digitColorList.Add(new BandCode { Order = 7, Value = 7.00, Color = "Violet" });
            digitColorList.Add(new BandCode { Order = 8, Value = 8.00, Color = "Grey/Gray" });
            digitColorList.Add(new BandCode { Order = 9, Value = 9.00, Color = "White" });

            var sut = new Digit();
            CollectionAssert.AreEqual(sut.Codes, digitColorList);
        }
    }
}