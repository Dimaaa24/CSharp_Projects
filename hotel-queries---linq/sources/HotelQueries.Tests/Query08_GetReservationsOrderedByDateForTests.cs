using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query08_GetReservationsOrderedByDateForTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer828_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 5, 106 };
            PerformTest(828, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer1020_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 23, 69 };
            PerformTest(1020, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer561_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 31, 152 };
            PerformTest(561, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer784_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 50, 45 };
            PerformTest(784, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer1311_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 57, 92 };
            PerformTest(1311, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer835_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 83, 133 };
            PerformTest(835, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer1219_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 118, 183 };
            PerformTest(1219, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer153_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 161, 166 };
            PerformTest(153, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer1040_ThenReturnsCorrectList()
        {
            int[] expectedReservationIds = { 12 };
            PerformTest(1040, expectedReservationIds);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchReservationsForCustomer1000000_ThenReturnsEmptyList()
        {
            int[] expectedReservationIds = { };
            PerformTest(1000000, expectedReservationIds);
        }

        private static void PerformTest(int customerId, int[] expectedReservationIds)
        {
            IEnumerable<Reservation> reservations = hotel.GetReservationsOrderedByDateFor(customerId);
            int[] actualReservationIds = reservations
                .Select(x => x.Id)
                .ToArray();

            Trace.WriteLine("Expected reservation ids: " + string.Join(", ", expectedReservationIds));
            Trace.WriteLine("Actual reservation ids:   " + string.Join(", ", actualReservationIds));

            CollectionAssert.AreEqual(expectedReservationIds, actualReservationIds);
        }
    }
}