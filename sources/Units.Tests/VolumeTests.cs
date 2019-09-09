using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Units.Tests
{
    [TestClass]
    public class VolumeTests
    {
        private const double MaxDelta = 0.000_000_000_001d;

        [TestMethod]
        public void VolumeConstructorTest()
        {
            var mass = new Volume(1.5d);
            Assert.AreEqual(1.5d, mass.CubicMeter, MaxDelta);
        }

        [TestMethod]
        public void VolumeFromKilogramsTest()
        {
            var mass = Volume.FromCubicMeter(1.5d);
            Assert.AreEqual(1.5d, mass.CubicMeter, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromLiterTest()
        {
            var mass = Volume.FromLiter(1.5d);
            Assert.AreEqual(1.5d, mass.Liter, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromFluidOunceTest()
        {
            var mass = Volume.FromFluidOunce(1.5d);
            Assert.AreEqual(1.5d, mass.FluidOunce, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromGallonTest()
        {
            var mass = Volume.FromGallon(1.5d);
            Assert.AreEqual(1.5d, mass.Gallon, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromQuartTest()
        {
            var mass = Volume.FromQuart(1.5d);
            Assert.AreEqual(1.5d, mass.Quart, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromPintTest()
        {
            var mass = Volume.FromPint(1.5d);
            Assert.AreEqual(1.5d, mass.Pint, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromDramTest()
        {
            var mass = Volume.FromDram(1.5d);
            Assert.AreEqual(1.5d, mass.Dram, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromTspTest()
        {
            var mass = Volume.FromTsp(1.5d);
            Assert.AreEqual(1.5d, mass.Tsp, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromCubicInchTest()
        {
            var mass = Volume.FromCubicInch(1.5d);
            Assert.AreEqual(1.5d, mass.CubicInch, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromCubicYardTest()
        {
            var mass = Volume.FromCubicYard(1.5d);
            Assert.AreEqual(1.5d, mass.CubicYard, MaxDelta);
        }
        [TestMethod]
        public void VolumeFromBarrelTest()
        {
            var mass = Volume.FromBarrel(1.5d);
            Assert.AreEqual(1.5d, mass.Barrel, MaxDelta);
        }

        [TestMethod]
        public void VolumeAdditionsTest()
        {
            var mass1 = Volume.FromCubicMeter(1.5d);
            var mass2 = Volume.FromCubicMeter(8.5d);
            var mass = mass1 + mass2;
            Assert.AreEqual(10d, mass.CubicMeter);
        }
        [TestMethod]
        public void VolumeSubtractionsTest()
        {
            var mass1 = Volume.FromCubicMeter(8.5d);
            var mass2 = Volume.FromCubicMeter(1.5d);
            var mass = mass1 - mass2;
            Assert.AreEqual(7d, mass.CubicMeter);
        }
        [TestMethod]
        public void VolumeDivisionsTest()
        {
            var mass1 = Volume.FromCubicMeter(1.5d);
            var mass = mass1 / 3;
            Assert.AreEqual(0.5d, mass.CubicMeter);
        }
        [TestMethod]
        public void VolumeMultiplyTest()
        {
            var mass1 = Volume.FromCubicMeter(1.5d);
            var mass = mass1 * 3;
            Assert.AreEqual(4.5d, mass.CubicMeter);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var mass = Volume.FromCubicMeter(123.456d);
            Assert.AreEqual("123.46 m³", mass.ToString());
            Assert.AreEqual("123.456 m³", mass.ToString(VolumeUnit.CubicMeter, "{0:F3} {1}"));
            Assert.AreEqual("123,456 m³", mass.ToString(VolumeUnit.CubicMeter, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", mass.ToString(VolumeUnit.CubicMeter, new CultureInfo("nl-NL"), "{0:F3}"));
            mass = Volume.FromLiter(123.456d);
            Assert.AreEqual("123.46 L", mass.ToString(VolumeUnit.Liter));
            mass = Volume.FromFluidOunce(123.456d);
            Assert.AreEqual("123.46 fl oz", mass.ToString(VolumeUnit.FluidOunce));
            mass = Volume.FromGallon(123.456d);
            Assert.AreEqual("123.46 gal", mass.ToString(VolumeUnit.Gallon));
            mass = Volume.FromQuart(123.456d);
            Assert.AreEqual("123.46 qt", mass.ToString(VolumeUnit.Quart));
            mass = Volume.FromPint(123.456d);
            Assert.AreEqual("123.46 pt", mass.ToString(VolumeUnit.Pint));
            mass = Volume.FromTsp(123.456d);
            Assert.AreEqual("123.46 tsp", mass.ToString(VolumeUnit.Tsp));
            mass = Volume.FromDram(123.456d);
            Assert.AreEqual("123.46 dr", mass.ToString(VolumeUnit.Dram));
            mass = Volume.FromCubicInch(123.456d);
            Assert.AreEqual("123.46 in³", mass.ToString(VolumeUnit.CubicInch));
            mass = Volume.FromCubicYard(123.456d);
            Assert.AreEqual("123.46 yd³", mass.ToString(VolumeUnit.CubicYard));
            mass = Volume.FromBarrel(123.456d);
            Assert.AreEqual("123.46 barrel", mass.ToString(VolumeUnit.Barrel));
        }

        [TestMethod]
        public void VolumeEqualityTest()
        {
            var mass1 = Volume.FromCubicMeter(1d);
            var mass2 = Volume.FromLiter(1000d);
            var otherType = "test";
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(mass1.Equals(otherType));
            Assert.IsFalse(mass1.Equals((object)null));
            Assert.IsFalse(mass1.Equals(null));
            Assert.IsTrue(mass1.Equals((object)mass1));
            Assert.IsTrue(mass1.Equals(mass1));
            Assert.IsTrue(mass1.Equals((object)mass2), $"{mass1} <> {mass2}");
            Assert.IsTrue(mass1.GetHashCode() == mass2.GetHashCode());
        }
    }
}
