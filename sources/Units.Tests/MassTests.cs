using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Units.Tests
{
    [TestClass]
    public class MassTests
    {
        [TestMethod]
        public void ConstructorMetersTest()
        {
            var mass = new Mass(1.5d);
            Assert.AreEqual(1.5d, mass.Kilograms);
        }

        [TestMethod]
        public void MassFromKilogramsTest()
        {
            var mass = Mass.FromKilograms(1.5d);
            Assert.AreEqual(1.5d, mass.Kilograms);
        }
        [TestMethod]
        public void MassFromPoundsTest()
        {
            var mass = Mass.FromPounds(1.5d);
            Assert.AreEqual(1.5d, mass.Pounds);
        }
        [TestMethod]
        public void MassFromGramsUnitsTest()
        {
            var mass = Mass.FromGrams(1d);
            Assert.AreEqual(1d, mass.Grams);
        }
        [TestMethod]
        public void MassFromPlanckMassesTest()
        {
            var mass = Mass.FromPlanckMasses(1d);
            Assert.AreEqual(1d, mass.PlanckMasses);
        }
        [TestMethod]
        public void MassFromSlugsTest()
        {
            var mass = Mass.FromSlugs(1d);
            Assert.AreEqual(1d, mass.Slugs);
        }
        [TestMethod]
        public void MassFromSolarMassesTest()
        {
            var mass = Mass.FromSolarMasses(1d);
            Assert.AreEqual(1d, mass.SolarMasses);
        }
        [TestMethod]
        public void MassFromTonnesTest()
        {
            var mass = Mass.FromTonnes(1d);
            Assert.AreEqual(1d, mass.Tonnes);
        }

        [TestMethod]
        public void MassAdditionsTest()
        {
            var mass1 = Mass.FromKilograms(1.5d);
            var mass2 = Mass.FromKilograms(8.5d);
            var mass = mass1 + mass2;
            Assert.AreEqual(10d, mass.Kilograms);
        }
        [TestMethod]
        public void MassSubtractionsTest()
        {
            var mass1 = Mass.FromKilograms(8.5d);
            var mass2 = Mass.FromKilograms(1.5d);
            var mass = mass1 - mass2;
            Assert.AreEqual(7d, mass.Kilograms);
        }
        [TestMethod]
        public void MassDivisionsTest()
        {
            var mass1 = Mass.FromKilograms(1.5d);
            var mass = mass1 / 3;
            Assert.AreEqual(0.5d, mass.Kilograms);
        }
        [TestMethod]
        public void MassMultiplyTest()
        {
            var mass1 = Mass.FromKilograms(1.5d);
            var mass = mass1 * 3;
            Assert.AreEqual(4.5d, mass.Kilograms);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var mass = Mass.FromKilograms(123.456d);
            Assert.AreEqual("123.46 kg", mass.ToString());
            Assert.AreEqual("123.456 kg", mass.ToString(MassUnit.Kilogram, "{0:F3} {1}"));
            Assert.AreEqual("123,456 kg", mass.ToString(MassUnit.Kilogram, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", mass.ToString(MassUnit.Kilogram, new CultureInfo("nl-NL"), "{0:F3}"));
            mass = Mass.FromGrams(123.456d);
            Assert.AreEqual("123.46 g", mass.ToString(MassUnit.Gram));
            Assert.AreEqual("123.46 g", mass.ToString(MassUnit.Gram, CultureInfo.InvariantCulture));
            Assert.AreEqual("123,46 g", mass.ToString(MassUnit.Gram, new CultureInfo("nl-NL")));
            mass = Mass.FromPounds(123.456d);
            Assert.AreEqual("123.46 lb", mass.ToString(MassUnit.Pound));
            Assert.AreEqual("123.46 lb", mass.ToString(MassUnit.Pound, CultureInfo.InvariantCulture));
            mass = Mass.FromPlanckMasses(123.456d);
            Assert.AreEqual("123.46 mP", mass.ToString(MassUnit.PlanckMass));
            Assert.AreEqual("123.46 mP", mass.ToString(MassUnit.PlanckMass, CultureInfo.InvariantCulture));
            mass = Mass.FromSlugs(123.456d);
            Assert.AreEqual("123.46 sl", mass.ToString(MassUnit.Slug));
            Assert.AreEqual("123.46 sl", mass.ToString(MassUnit.Slug, CultureInfo.InvariantCulture));
            mass = Mass.FromSolarMasses(123.456d);
            Assert.AreEqual("123.46 M☉", mass.ToString(MassUnit.SolarMass));
            Assert.AreEqual("123.46 M☉", mass.ToString(MassUnit.SolarMass, CultureInfo.InvariantCulture));
            mass = Mass.FromTonnes(123.456d);
            Assert.AreEqual("123.46 t", mass.ToString(MassUnit.Tonne));
            Assert.AreEqual("123.46 t", mass.ToString(MassUnit.Tonne, CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void MassEqualityTest()
        {
            var mass1 = Mass.FromKilograms(12d);
            var mass2 = Mass.FromGrams(12000d);
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
