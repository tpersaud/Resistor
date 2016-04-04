using NUnit.Framework;
using Resistor.Bands;
using System.Collections.Generic;

namespace Resistor.Tests
{
   [TestFixture]
    public class ToleranceTests
    {
       [Test]
       public void ShouldValidateBandColorList()
       {
           List<BandCode> toleranceColorList = new List<BandCode>();
           toleranceColorList.Add(new BandCode { Order = 0, Value = 1.00, Color = "Brown" });
           toleranceColorList.Add(new BandCode { Order = 1, Value = 2.00, Color = "Red" });
           toleranceColorList.Add(new BandCode { Order = 2, Value = 0.50, Color = "Green" });
           toleranceColorList.Add(new BandCode { Order = 3, Value = 0.25, Color = "Blue" });
           toleranceColorList.Add(new BandCode { Order = 4, Value = 0.10, Color = "Violet" });
           toleranceColorList.Add(new BandCode { Order = 5, Value = 0.05, Color = "Grey/Gray" });
           toleranceColorList.Add(new BandCode { Order = 6, Value = 5.00, Color = "Gold" });
           toleranceColorList.Add(new BandCode { Order = 7, Value = 10.00, Color = "Silver" });

           var sut = new Tolerance();
           CollectionAssert.AreEqual(sut.Codes, toleranceColorList);
       }
    }
}