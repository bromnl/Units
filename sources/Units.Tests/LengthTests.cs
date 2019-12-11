using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Units.Tests
{
    [TestClass]
    public class LengthTests
    {
        [TestMethod]
        public void ConstructorMetersTest()
        {
            var length = new Length(1.5d);
            Assert.AreEqual(1.5d, length.Meters);
        }

        [TestMethod]
        public void LengthFromMetersTest()
        {
            var length = Length.FromMeters(1.5d);
            Assert.AreEqual(1.5d, length.Meters);
        }
        [TestMethod]
        public void LengthFromAstronomicalUnitsTest()
        {
            var length = Length.FromAstronomicalUnits(1d);
            Assert.AreEqual(1d, length.AstronomicalUnits);
        }
        [TestMethod]
        public void LengthFromFeetTest()
        {
            var length = Length.FromFeet(1d);
            Assert.AreEqual(1d, length.Feet);
        }
        [TestMethod]
        public void LengthFromDaysTest()
        {
            var length = Length.FromInches(1d);
            Assert.AreEqual(1d, length.Inches);
        }
        [TestMethod]
        public void LengthFromLightYearsTest()
        {
            var length = Length.FromLightYears(1d);
            Assert.AreEqual(1d, length.LightYears);
        }
        [TestMethod]
        public void LengthFromMilesTest()
        {
            var length = Length.FromMiles(1d);
            Assert.AreEqual(1d, length.Miles);
        }
        [TestMethod]
        public void LengthFromYardsTest()
        {
            var length = Length.FromYards(1d);
            Assert.AreEqual(1d, length.Yards);
        }
        [TestMethod]
        public void LengthFromParsecsTest()
        {
            var length = Length.FromParsecs(1d);
            Assert.AreEqual(1d, length.Parsecs);
        }

        [TestMethod]
        public void LengthFromFurlongsTest()
        {
            var length = Length.FromFurlong(1d);
            Assert.AreEqual(1d, length.Furlongs);
        }

        [TestMethod]
        public void LengthAdditionsTest()
        {
            var length1 = Length.FromMeters(1.5d);
            var length2 = Length.FromMeters(8.5d);
            var length = length1 + length2;
            Assert.AreEqual(10d, length.Meters);
        }
        [TestMethod]
        public void LengthSubtractionsTest()
        {
            var length1 = Length.FromMeters(8.5d);
            var length2 = Length.FromMeters(1.5d);
            var length = length1 - length2;
            Assert.AreEqual(7d, length.Meters);
        }
        [TestMethod]
        public void LengthDivisionsTest()
        {
            var length1 = Length.FromMeters(1.5d);
            var length = length1 / 3;
            Assert.AreEqual(0.5d, length.Meters);
        }
        [TestMethod]
        public void LengthMultiplyTest()
        {
            var length1 = Length.FromMeters(1.5d);
            var length = length1 * 3;
            Assert.AreEqual(4.5d, length.Meters);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var length = Length.FromMeters(123.456d);
            Assert.AreEqual("123.46 m", length.ToString());
            Assert.AreEqual("123.456 m", length.ToString(LengthUnit.Meter, "{0:F3} {1}"));
            Assert.AreEqual("123,456 m", length.ToString(LengthUnit.Meter, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", length.ToString(LengthUnit.Meter, new CultureInfo("nl-NL"), "{0:F3}"));
            length = Length.FromInches(123.456d);
            Assert.AreEqual("123.46 in", length.ToString(LengthUnit.Inch));
            Assert.AreEqual("123.46 in", length.ToString(LengthUnit.Inch, CultureInfo.InvariantCulture));
            Assert.AreEqual("123,46 in", length.ToString(LengthUnit.Inch, new CultureInfo("nl-NL")));
            length = Length.FromAstronomicalUnits(123.456d);
            Assert.AreEqual("123.46 au", length.ToString(LengthUnit.AstronomicalUnit));
            Assert.AreEqual("123.46 au", length.ToString(LengthUnit.AstronomicalUnit, CultureInfo.InvariantCulture));
            length = Length.FromFeet(123.456d);
            Assert.AreEqual("123.46 ft", length.ToString(LengthUnit.Foot));
            Assert.AreEqual("123.46 ft", length.ToString(LengthUnit.Foot, CultureInfo.InvariantCulture));
            length = Length.FromLightYears(123.456d);
            Assert.AreEqual("123.46 ly", length.ToString(LengthUnit.LightYear));
            Assert.AreEqual("123.46 ly", length.ToString(LengthUnit.LightYear, CultureInfo.InvariantCulture));
            length = Length.FromYards(123.456d);
            Assert.AreEqual("123.46 yd", length.ToString(LengthUnit.Yard));
            Assert.AreEqual("123.46 yd", length.ToString(LengthUnit.Yard, CultureInfo.InvariantCulture));
            length = Length.FromMiles(123.456d);
            Assert.AreEqual("123.46 mi", length.ToString(LengthUnit.Mile));
            Assert.AreEqual("123.46 mi", length.ToString(LengthUnit.Mile, CultureInfo.InvariantCulture));
            length = Length.FromParsecs(123.456d);
            Assert.AreEqual("123.46 pc", length.ToString(LengthUnit.Parsec));
            Assert.AreEqual("123.46 pc", length.ToString(LengthUnit.Parsec, CultureInfo.InvariantCulture));
            length = Length.FromFurlong(123.456d);
            Assert.AreEqual("123.46 fur", length.ToString(LengthUnit.Furlong));
            Assert.AreEqual("123.46 fur", length.ToString(LengthUnit.Furlong, CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void LengthEqualityTest()
        {
            var length1 = Length.FromInches(12d);
            var length2 = Length.FromFeet(1d);
            var otherType = "test";
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(length1.Equals(otherType));
            Assert.IsFalse(length1.Equals((object)null));
            Assert.IsFalse(length1.Equals(null));
            Assert.IsTrue(length1.Equals((object)length1));
            Assert.IsTrue(length1.Equals(length1));
            Assert.IsTrue(length1.Equals((object)length2), $"{length1} <> {length2}");
            Assert.IsTrue(length1.GetHashCode() == length2.GetHashCode());
        }
    }
}
