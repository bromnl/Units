using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Units.Tests
{
    [TestClass]
    public class TemperatureTests
    {
        private const double MaxDelta = 0.000_000_000_000_1d;

        [TestMethod]
        public void ConstructorSecondsTest()
        {
            var temperature = new Temperature(100d);
            Assert.AreEqual(100d, temperature.Kelvin);
        }

        [TestMethod]
        public void TemperatureFromKelvinTest()
        {
            var temperature = Temperature.FromKelvin(100d);
            Assert.AreEqual(100d, temperature.Kelvin, MaxDelta);
            Assert.AreEqual(-173.15d, temperature.Celsius, MaxDelta);
            Assert.AreEqual(-279.67d, temperature.Fahrenheit, MaxDelta);
        }
        [TestMethod]
        public void TemperatureFromFahrenheitTest()
        {
            var temperature = Temperature.FromFahrenheit(100d);
            Assert.AreEqual(100d, temperature.Fahrenheit, MaxDelta);
            Assert.AreEqual(37.777_777_777_777_78d, temperature.Celsius, MaxDelta);
            Assert.AreEqual(310.927_777_777_777_8d, temperature.Kelvin, MaxDelta);
        }
        [TestMethod]
        public void TemperatureFromCelsiusTest()
        {
            var temperature = Temperature.FromCelsius(100d);
            Assert.AreEqual(100d, temperature.Celsius, MaxDelta);
            Assert.AreEqual(373.15d, temperature.Kelvin, MaxDelta);
            Assert.AreEqual(212d, temperature.Fahrenheit, MaxDelta);
        }
        [TestMethod]
        public void TemperatureFromRankineTest()
        {
            var temperature = Temperature.FromRankine(100d);
            Assert.AreEqual(100, temperature.Rankine, MaxDelta);
        }
        [TestMethod]
        public void TemperatureFromDelisleTest()
        {
            var temperature = Temperature.FromDelisle(100d);
            Assert.AreEqual(100d, temperature.Delisle, MaxDelta);
        }
        [TestMethod]
        public void TemperatureFromNewtonTest()
        {
            var temperature = Temperature.FromNewton(100d);
            Assert.AreEqual(100d, temperature.Newton, MaxDelta);
        }
        [TestMethod]
        public void TemperatureFromRéaumurTest()
        {
            var temperature = Temperature.FromRéaumur(100d);
            Assert.AreEqual(100d, temperature.Réaumur, MaxDelta);
        }
        [TestMethod]
        public void TemperatureFromRømerTest()
        {
            var temperature = Temperature.FromRømer(100d);
            Assert.AreEqual(100d, temperature.Rømer, MaxDelta);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var temperature = Temperature.FromKelvin(123.456d);
            Assert.AreEqual("123.46 K", temperature.ToString());
            Assert.AreEqual("123.456 K", temperature.ToString(TemperatureUnit.Kelvin, "{0:F3} {1}"));
            Assert.AreEqual("123,456 K", temperature.ToString(TemperatureUnit.Kelvin, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", temperature.ToString(TemperatureUnit.Kelvin, new CultureInfo("nl-NL"), "{0:F3}"));
            temperature = Temperature.FromRankine(123.456d);
            Assert.AreEqual("123.46 °R", temperature.ToString(TemperatureUnit.Rankine));
            Assert.AreEqual("123.46 °R", temperature.ToString(TemperatureUnit.Rankine, CultureInfo.InvariantCulture));
            Assert.AreEqual("123,46 °R", temperature.ToString(TemperatureUnit.Rankine, new CultureInfo("nl-NL")));
            temperature = Temperature.FromCelsius(123.456d);
            Assert.AreEqual("123.46 °C", temperature.ToString(TemperatureUnit.Celsius));
            Assert.AreEqual("123.46 °C", temperature.ToString(TemperatureUnit.Celsius, CultureInfo.InvariantCulture));
            temperature = Temperature.FromDelisle(123.456d);
            Assert.AreEqual("123.46 °D", temperature.ToString(TemperatureUnit.Delisle));
            Assert.AreEqual("123.46 °D", temperature.ToString(TemperatureUnit.Delisle, CultureInfo.InvariantCulture));
            temperature = Temperature.FromNewton(123.456d);
            Assert.AreEqual("123.46 °N", temperature.ToString(TemperatureUnit.Newton));
            Assert.AreEqual("123.46 °N", temperature.ToString(TemperatureUnit.Newton, CultureInfo.InvariantCulture));
            temperature = Temperature.FromRéaumur(123.456d);
            Assert.AreEqual("123.46 °Ré", temperature.ToString(TemperatureUnit.Réaumur));
            Assert.AreEqual("123.46 °Ré", temperature.ToString(TemperatureUnit.Réaumur, CultureInfo.InvariantCulture));
            temperature = Temperature.FromRømer(123.456d);
            Assert.AreEqual("123.46 °Rø", temperature.ToString(TemperatureUnit.Rømer));
            Assert.AreEqual("123.46 °Rø", temperature.ToString(TemperatureUnit.Rømer, CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TemperatureEqualityTest()
        {
            var temperature1 = Temperature.FromKelvin(273.15d);
            var temperature2 = Temperature.FromCelsius(0d);
            var otherType = "test";
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(temperature1.Equals(otherType));
            Assert.IsFalse(temperature1.Equals((object)null));
            Assert.IsFalse(temperature1.Equals(null));
            Assert.IsTrue(temperature1.Equals((object)temperature1));
            Assert.IsTrue(temperature1.Equals(temperature1));
            Assert.IsTrue(temperature1.Equals((object)temperature2));
            Assert.IsTrue(temperature1.GetHashCode() == temperature2.GetHashCode());
        }
    }
}
