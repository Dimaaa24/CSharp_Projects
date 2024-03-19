using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query10_CalculateAverageReservationsPerMonthTests
    {
        [TestMethod]
        public void Test()
        {
            Hotel hotel = HotelBuilder.CreateHotel();

            double actual = hotel.CalculateAverageReservationsPerMonth();
            const double expected = 64.66;

            Trace.WriteLine($"Expected value: {expected}");
            Trace.WriteLine($"Actual value:   {actual}");

            Assert.AreEqual(expected, actual, 0.01);
        }
    }
}