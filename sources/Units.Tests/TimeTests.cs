using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Units.Tests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void ConstructorSecondsTest()
        {
            var time = new Time(3600d);
            Assert.AreEqual(3600d, time.Seconds);
        }
        [TestMethod]
        public void ConstructorHoursMinutesSecondsTest()
        {
            var time = new Time(1d,30d,30d);
            Assert.AreEqual(5430d, time.Seconds);
        }

        [TestMethod]
        public void TimeFromSecondsTest()
        {
            var time = Time.FromSeconds(3600d);
            Assert.AreEqual(3600d, time.Seconds);
            Assert.AreEqual(60d, time.Minutes);
            Assert.AreEqual(1d, time.Hours);
        }
        [TestMethod]
        public void TimeFromMinutesTest()
        {
            var time = Time.FromMinutes(1d);
            Assert.AreEqual(60d, time.Seconds);
            Assert.AreEqual(1d, time.Minutes);
            Assert.AreEqual(1d / 60d, time.Hours);
        }
        [TestMethod]
        public void TimeFromHoursTest()
        {
            var time = Time.FromHours(1d);
            Assert.AreEqual(3600d, time.Seconds);
            Assert.AreEqual(60d, time.Minutes);
            Assert.AreEqual(1d, time.Hours);
        }
        [TestMethod]
        public void TimeFromDaysTest()
        {
            var time = Time.FromDays(1d);
            Assert.AreEqual(86400, time.Seconds);
            Assert.AreEqual(1440d, time.Minutes);
            Assert.AreEqual(24d, time.Hours);
            Assert.AreEqual(1d, time.Days);
        }
        [TestMethod]
        public void TimeFromWeeksTest()
        {
            var time = Time.FromWeeks(1d);
            Assert.AreEqual(604800d, time.Seconds);
            Assert.AreEqual(10080d, time.Minutes);
            Assert.AreEqual(168d, time.Hours);
            Assert.AreEqual(7d, time.Days);
            Assert.AreEqual(1d, time.Weeks);
        }

        [TestMethod]
        public void TimeAdditionsTest()
        {
            var time1 = Time.FromSeconds(1.5d);
            var time2 = Time.FromSeconds(8.5d);
            var time = time1 + time2;
            Assert.AreEqual(10d, time.Seconds);
        }
        [TestMethod]
        public void TimeSubtractionsTest()
        {
            var time1 = Time.FromSeconds(8.5d);
            var time2 = Time.FromSeconds(1.5d);
            var time = time1 - time2;
            Assert.AreEqual(7d, time.Seconds);
        }
        [TestMethod]
        public void TimeDivisionsTest()
        {
            var time1 = Time.FromSeconds(1.5d);
            var time = time1 / 3;
            Assert.AreEqual(0.5d, time.Seconds);
        }
        [TestMethod]
        public void TimeMultiplyTest()
        {
            var time1 = Time.FromSeconds(1.5d);
            var time = time1 * 3;
            Assert.AreEqual(4.5d, time.Seconds);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var time = Time.FromSeconds(123.456d);
            Assert.AreEqual("123.46 s", time.ToString());
            Assert.AreEqual("123.456 s", time.ToString(TimeUnit.Second, "{0:F3} {1}"));
            Assert.AreEqual("123,456 s", time.ToString(TimeUnit.Second, new CultureInfo("nl-NL"), "{0:F3} {1}"));
            Assert.AreEqual("123,456", time.ToString(TimeUnit.Second, new CultureInfo("nl-NL"), "{0:F3}"));
            time = Time.FromMinutes(123.456d);
            Assert.AreEqual("123.46 min", time.ToString(TimeUnit.Minute));
            Assert.AreEqual("123.46 min", time.ToString(TimeUnit.Minute, CultureInfo.InvariantCulture));
            Assert.AreEqual("123,46 min", time.ToString(TimeUnit.Minute, new CultureInfo("nl-NL")));
            time = Time.FromHours(123.456d);
            Assert.AreEqual("123.46 h", time.ToString(TimeUnit.Hour));
            Assert.AreEqual("123.46 h", time.ToString(TimeUnit.Hour, CultureInfo.InvariantCulture));
            time = Time.FromDays(123.456d);
            Assert.AreEqual("123.46 days", time.ToString(TimeUnit.Day));
            Assert.AreEqual("123.46 days", time.ToString(TimeUnit.Day, CultureInfo.InvariantCulture));
            time = Time.FromWeeks(123.456d);
            Assert.AreEqual("123.46 weeks", time.ToString(TimeUnit.Week));
            Assert.AreEqual("123.46 weeks", time.ToString(TimeUnit.Week, CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TimeEqualityTest()
        {
            var time1 = Time.FromMinutes(10d);
            var time2 = Time.FromSeconds(600d);
            var otherType = "test";
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(time1.Equals(otherType));
            Assert.IsFalse(time1.Equals((object)null));
            Assert.IsFalse(time1.Equals(null));
            Assert.IsTrue(time1.Equals((object)time1));
            Assert.IsTrue(time1.Equals(time1));
            Assert.IsTrue(time1.Equals((object)time2));
            Assert.IsTrue(time1.GetHashCode() == time2.GetHashCode());
        }
    }
}
