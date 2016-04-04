using NUnit.Framework;
using Resistor.Bands;
using System.Collections.Generic;

namespace Resistor.Tests
{
    [TestFixture]
    public class TemperatureTests
    {
        [Test]
        public void ShouldValidateBandColorList()
        {
            List<BandCode> temperatureColorList = new List<BandCode>();
            temperatureColorList.Add(new BandCode { Order = 0, Value = 100.00, Color = "Brown" });
            temperatureColorList.Add(new BandCode { Order = 1, Value = 50.00, Color = "Red" });
            temperatureColorList.Add(new BandCode { Order = 2, Value = 15.00, Color = "Orange" });
            temperatureColorList.Add(new BandCode { Order = 3, Value = 25.00, Color = "Yellow" });

            var sut = new Temperature();
            CollectionAssert.AreEqual(sut.Codes, temperatureColorList);
        }
    }
}