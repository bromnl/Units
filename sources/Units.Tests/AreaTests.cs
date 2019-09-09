using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Units.Tests
{
    [TestClass]
    public class AreaTests
    {
        private const double MaxDelta = 0.000_000_000_001d;

        [TestMethod]
        public void AreaConstructorTest()
        {
            var area = new Area(1.5d);
            Assert.AreEqual(1.5d, area.SquareMeter, MaxDelta);
        }

        [TestMethod]
        public void AreaFromSquareMeterTest()
        {
            var area = Area.FromSquareMeters(1.5d);
            Assert.AreEqual(1.5d, area.SquareMeter, MaxDelta);
        }
        [TestMethod]
        public void AreaFromSquareFootTest()
        {
            var area = Area.FromSquareFoot(1.5d);
            Assert.AreEqual(1.5d, area.SquareFoot, MaxDelta);
        }
        [TestMethod]
        public void AreaFromSquareYardTest()
        {
            var area = Area.FromSquareYard(1.5d);
            Assert.AreEqual(1.5d, area.SquareYard, MaxDelta);
        }
        [TestMethod]
        public void AreaFromSquareMileTest()
        {
            var area = Area.FromSquareMile(1.5d);
            Assert.AreEqual(1.5d, area.SquareMile, MaxDelta);
        }
        [TestMethod]
        public void AreaFromSquareInchTest()
        {
            var area = Area.FromSquareInch(1.5d);
            Assert.AreEqual(1.5d, area.SquareInch, MaxDelta);
        }
        [TestMethod]
        public void AreaFromAreTest()
        {
            var area = Area.FromAre(1.5d);
            Assert.AreEqual(1.5d, area.Are, MaxDelta);
        }
        [TestMethod]
        public void AreaFromDramTest()
        {
            var area = Area.FromAcre(1.5d);
            Assert.AreEqual(1.5d, area.Acre, MaxDelta);
        }
        [TestMethod]
        public void AreaFromTspTest()
        {
            var area = Area.FromBarn(1.5d);
            Assert.AreEqual(1.5d, area.Barn, MaxDelta);
        }

        [TestMethod]
        public void AreaAdditionsTest()
        {
            var area1 = Area.FromSquareMeters(1.5d);
            var area2 = Area.FromSquareMeters(8.5d);
            var area = area1 + area2;
            Assert.AreEqual(10d, area.SquareMeter);
        }
        [TestMethod]
        public void AreaSubtractionsTest()
        {
            var area1 = Area.FromSquareMeters(8.5d);
            var area2 = Area.FromSquareMeters(1.5d);
            var area = area1 - area2;
            Assert.AreEqual(7d, area.SquareMeter);
        }
        [TestMethod]
        public void AreaDivisionsTest()
        {
            var area1 = Area.FromSquareMeters(1.5d);
            var area = area1 / 3;
            Assert.AreEqual(0.5d, area.SquareMeter);
        }
        [TestMethod]
        public void AreaMultiplyTest()
        {
            var area1 = Area.FromSquareMeters(1.5d);
            var area = area1 * 3;
            Assert.AreEqual(4.5d, area.SquareMeter);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var area = Area.FromSquareMeters(123.456d);
            Assert.AreEqual("123.46 m²", area.ToString());
            Assert.AreEqual("123.456 m²", area.ToString(AreaUnit.SquareMeter, "{0:F3} {1}"));
            Assert.AreEqual("123,456 m²", area.ToString(AreaUnit.SquareMeter, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", area.ToString(AreaUnit.SquareMeter, new CultureInfo("nl-NL"), "{0:F3}"));
            area = Area.FromSquareFoot(123.456d);
            Assert.AreEqual("123.46 ft²", area.ToString(AreaUnit.SquareFoot));
            area = Area.FromSquareYard(123.456d);
            Assert.AreEqual("123.46 yd²", area.ToString(AreaUnit.SquareYard));
            area = Area.FromSquareMile(123.456d);
            Assert.AreEqual("123.46 ml²", area.ToString(AreaUnit.SquareMile));
            area = Area.FromSquareInch(123.456d);
            Assert.AreEqual("123.46 in²", area.ToString(AreaUnit.SquareInch));
            area = Area.FromAre(123.456d);
            Assert.AreEqual("123.46 are", area.ToString(AreaUnit.Are));
            area = Area.FromAcre(123.456d);
            Assert.AreEqual("123.46 acre", area.ToString(AreaUnit.Acre));
            area = Area.FromBarn(123.456d);
            Assert.AreEqual("123.46 b", area.ToString(AreaUnit.Barn));
        }

        [TestMethod]
        public void AreaEqualityTest()
        {
            var area1 = Area.FromSquareMeters(1d);
            var area2 = Area.FromSquareMeters(1d);
            var otherType = "test";
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(area1.Equals(otherType));
            Assert.IsFalse(area1.Equals((object)null));
            Assert.IsFalse(area1.Equals(null));
            Assert.IsTrue(area1.Equals((object)area1));
            Assert.IsTrue(area1.Equals(area1));
            Assert.IsTrue(area1.Equals((object)area2), $"{area1} <> {area2}");
            Assert.IsTrue(area1.GetHashCode() == area2.GetHashCode());
        }
    }
}
