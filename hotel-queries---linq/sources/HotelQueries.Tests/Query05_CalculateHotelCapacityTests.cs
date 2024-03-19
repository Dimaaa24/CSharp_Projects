using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query05_CalculateHotelCapacityTests
    {
        [TestMethod]
        public void HavingAHotelInstance_WhenCalculatingCapacity_ThenReturns64()
        {
            Hotel hotel = HotelBuilder.CreateHotel();

            int actual = hotel.CalculateHotelCapacity();

            Assert.AreEqual(64, actual);
        }
    }
}