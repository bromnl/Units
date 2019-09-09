using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Units.Tests
{
    [TestClass]
    public class ElectricCurrentTests
    {
        [TestMethod]
        public void ConstructorMetersTest()
        {
            var electricCurrent = new ElectricCurrent(1.5d);
            Assert.AreEqual(1.5d, electricCurrent.Amperes);
        }

        [TestMethod]
        public void ElectricCurrentFromAmperesTest()
        {
            var electricCurrent = ElectricCurrent.FromAmperes(1.5d);
            Assert.AreEqual(1.5d, electricCurrent.Amperes);
        }
        [TestMethod]
        public void ElectricCurrentAdditionsTest()
        {
            var electricCurrent1 = ElectricCurrent.FromAmperes(1.5d);
            var electricCurrent2 = ElectricCurrent.FromAmperes(8.5d);
            var electricCurrent = electricCurrent1 + electricCurrent2;
            Assert.AreEqual(10d, electricCurrent.Amperes);
        }
        [TestMethod]
        public void ElectricCurrentSubtractionsTest()
        {
            var electricCurrent1 = ElectricCurrent.FromAmperes(8.5d);
            var electricCurrent2 = ElectricCurrent.FromAmperes(1.5d);
            var electricCurrent = electricCurrent1 - electricCurrent2;
            Assert.AreEqual(7d, electricCurrent.Amperes);
        }
        [TestMethod]
        public void ElectricCurrentDivisionsTest()
        {
            var electricCurrent1 = ElectricCurrent.FromAmperes(1.5d);
            var electricCurrent = electricCurrent1 / 3;
            Assert.AreEqual(0.5d, electricCurrent.Amperes);
        }
        [TestMethod]
        public void ElectricCurrentMultiplyTest()
        {
            var electricCurrent1 = ElectricCurrent.FromAmperes(1.5d);
            var electricCurrent = electricCurrent1 * 3;
            Assert.AreEqual(4.5d, electricCurrent.Amperes);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var electricCurrent = ElectricCurrent.FromAmperes(123.456d);
            Assert.AreEqual("123.46 A", electricCurrent.ToString());
            Assert.AreEqual("123.456 A", electricCurrent.ToString(ElectricCurrentUnit.Ampere, "{0:F3} {1}"));
            Assert.AreEqual("123,456 A", electricCurrent.ToString(ElectricCurrentUnit.Ampere, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", electricCurrent.ToString(ElectricCurrentUnit.Ampere, new CultureInfo("nl-NL"), "{0:F3}"));
        }

        [TestMethod]
        public void ElectricCurrentEqualityTest()
        {
            var electricCurrent1 = ElectricCurrent.FromAmperes(12d);
            var electricCurrent2 = new ElectricCurrent(12d);
            var otherType = "test";
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(electricCurrent1.Equals(otherType));
            Assert.IsFalse(electricCurrent1.Equals((object)null));
            Assert.IsFalse(electricCurrent1.Equals(null));
            Assert.IsTrue(electricCurrent1.Equals((object)electricCurrent1));
            Assert.IsTrue(electricCurrent1.Equals(electricCurrent1));
            Assert.IsTrue(electricCurrent1.Equals((object)electricCurrent2), $"{electricCurrent1} <> {electricCurrent2}");
            Assert.IsTrue(electricCurrent1.GetHashCode() == electricCurrent2.GetHashCode());
        }
    }
}
