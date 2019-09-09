using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Units.Tests
{
    [TestClass]
    public class PressureTests
    {
        [TestMethod]
        public void ConstructorPascalTest()
        {
            var pressure = new Pressure(10d);
            Assert.AreEqual(10d, pressure.Pascal, Double.Epsilon);
            Assert.AreEqual(0.0001d, pressure.Bar, Double.Epsilon);
            Assert.AreEqual(0.0014503773773d, pressure.PoundsPerSquareInch, 0.0000000001);
            Assert.AreEqual(0.00010197162d, pressure.Atmosphere, 0.0000000001);
            Assert.AreEqual(0.075006169d, pressure.Torr, 0.0000000001);
        }

        [TestMethod]
        public void ConstructorBarTest()
        {
            var pressure = new Pressure(0.0001d, PressureUnit.Bar);
            Assert.AreEqual(10d, pressure.Pascal, Double.Epsilon);
            Assert.AreEqual(0.0001d, pressure.Bar, Double.Epsilon);
            Assert.AreEqual(0.0014503773773d, pressure.PoundsPerSquareInch, 0.0000000001);
            Assert.AreEqual(0.00010197162d, pressure.Atmosphere, 0.0000000001);
            Assert.AreEqual(0.075006169d, pressure.Torr, 0.0000000001);
        }

        [TestMethod]
        public void ConstructorPsiTest()
        {
            var pressure = new Pressure(0.0014503773773d, PressureUnit.Psi);
            Assert.AreEqual(10d, pressure.Pascal, Double.Epsilon);
            Assert.AreEqual(0.0001d, pressure.Bar, Double.Epsilon);
            Assert.AreEqual(0.0014503773773d, pressure.PoundsPerSquareInch, 0.0000000001);
            Assert.AreEqual(0.00010197162d, pressure.Atmosphere, 0.0000000001);
            Assert.AreEqual(0.075006169d, pressure.Torr, 0.0000000001);
        }

        [TestMethod]
        public void ConstructorAtmTest()
        {
            var pressure = new Pressure(0.00010197162d, PressureUnit.Atmosphere);
            Assert.AreEqual(10d, pressure.Pascal, Double.Epsilon);
            Assert.AreEqual(0.0001d, pressure.Bar, Double.Epsilon);
            Assert.AreEqual(0.0014503773773d, pressure.PoundsPerSquareInch, 0.0000000001);
            Assert.AreEqual(0.00010197162d, pressure.Atmosphere, 0.0000000001);
            Assert.AreEqual(0.075006169d, pressure.Torr, 0.0000000001);
        }

        [TestMethod]
        public void ConstructorTorrTest()
        {
            var pressure = new Pressure(0.075006169d, PressureUnit.Torr);
            Assert.AreEqual(10d, pressure.Pascal, Double.Epsilon);
            Assert.AreEqual(0.0001d, pressure.Bar, Double.Epsilon);
            Assert.AreEqual(0.0014503773773d, pressure.PoundsPerSquareInch, 0.0000000001);
            Assert.AreEqual(0.00010197162d, pressure.Atmosphere, 0.0000000001);
            Assert.AreEqual(0.075006169d, pressure.Torr, 0.0000000001);
        }

        [TestMethod]
        public void OperatorPlusTest()
        {
            var pressure = Pressure.FromBar(10d) + Pressure.FromPoundsPerSquareInch(145.03773773d);
            Assert.AreEqual(20d, pressure.Bar);
        }

        [TestMethod]
        public void OperatorMinTest()
        {
            var pressure = Pressure.FromPascal(10d) - Pressure.FromAtmosphere(0.00010197162d);
            Assert.AreEqual(0d, pressure.Bar);
        }

        [TestMethod]
        public void OperatorDeviceTest()
        {
            var pressure = Pressure.FromTorr(10d) / 2d;
            Assert.AreEqual(5d, pressure.Torr);
        }

        [TestMethod]
        public void OperatorMultiplyTest()
        {
            var pressure = Pressure.FromPascal(10d) * 2d;
            Assert.AreEqual(20d, pressure.Pascal);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var pressure = Pressure.FromPascal(123.456d);
            Assert.AreEqual("123.46 Pa", pressure.ToString());
            Assert.AreEqual("123.456 Pa", pressure.ToString(PressureUnit.Pascal, "{0:F3} {1}"));
            Assert.AreEqual("123,456 Pa", pressure.ToString(PressureUnit.Pascal, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", pressure.ToString(PressureUnit.Pascal, new CultureInfo("nl-NL"), "{0:F3}"));
            pressure = Pressure.FromBar(123.456d);
            Assert.AreEqual("123.46 bar", pressure.ToString(PressureUnit.Bar));
            Assert.AreEqual("123.46 bar", pressure.ToString(PressureUnit.Bar, CultureInfo.InvariantCulture));
            Assert.AreEqual("123,46 bar", pressure.ToString(PressureUnit.Bar, new CultureInfo("nl-NL")));
            pressure = Pressure.FromAtmosphere(123.456d);
            Assert.AreEqual("123.46 atm", pressure.ToString(PressureUnit.Atmosphere));
            Assert.AreEqual("123.46 atm", pressure.ToString(PressureUnit.Atmosphere, CultureInfo.InvariantCulture));
            pressure = Pressure.FromPoundsPerSquareInch(123.456d);
            Assert.AreEqual("123.46 psi", pressure.ToString(PressureUnit.Psi));
            Assert.AreEqual("123.46 psi", pressure.ToString(PressureUnit.Psi, CultureInfo.InvariantCulture));
            pressure = Pressure.FromTorr(123.456d);
            Assert.AreEqual("123.46 Torr", pressure.ToString(PressureUnit.Torr));
            Assert.AreEqual("123.46 Torr", pressure.ToString(PressureUnit.Torr, CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void PressureEqualityTest()
        {
            var pressure1 = Pressure.FromPascal(100000d);
            var pressure2 = new Pressure(100000d);
            var otherType = "test";
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(pressure1.Equals(otherType));
            Assert.IsFalse(pressure1.Equals((object)null));
            Assert.IsFalse(pressure1.Equals(null));
            Assert.IsTrue(pressure1.Equals((object)pressure1));
            Assert.IsTrue(pressure1.Equals(pressure1));
            Assert.IsTrue(pressure1.Equals((object)pressure2));
            Assert.IsTrue(pressure1.GetHashCode() == pressure2.GetHashCode());
        }

    }
}
