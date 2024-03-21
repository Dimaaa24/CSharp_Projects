using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query03_GetCompanyReservationsTests
    {
        [TestMethod]
        public void HavingAHotelInstance_WhenRetrievingAllReservationsMadeByCompanies_ThenReturnsCorrectList()
        {
            Hotel hotel = HotelBuilder.CreateHotel();

            IEnumerable<Reservation> reservations = hotel.GetCompanyReservations();
            int[] actualReservationIds = reservations
                .Select(x => x.Id)
                .ToArray();

            int[] expectedReservationIds = { 1, 2, 10, 12, 13, 17, 18, 21, 22, 23, 25, 27, 28, 29, 34, 44, 55, 57, 59, 62, 64, 65, 67, 68, 69, 72, 73, 79, 82, 86, 88, 92, 100, 104, 113, 114, 115, 118, 125, 127, 128, 135, 137, 142, 151, 154, 157, 160, 167, 180, 181, 182, 183, 184, 187, 188 };

            Trace.WriteLine("Expected reservation ids: " + string.Join(", ", expectedReservationIds));
            Trace.WriteLine("Actual reservation ids:   " + string.Join(", ", actualReservationIds));

            CollectionAssert.AreEquivalent(expectedReservationIds, actualReservationIds);
        }
    }
}