using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query01_GetAllRoomsForTwoPersonsTests
    {
        [TestMethod]
        public void HavingAHotelInstance_WhenRetrievingAllRoomsForTwoPersons_ThenReturnsCorrectList()
        {
            Hotel hotel = HotelBuilder.CreateHotel();

            IEnumerable<Room> rooms = hotel.GetAllRoomsForTwoPersons();
            int[] actualRoomNumbers = rooms
                .Select(x => x.Number)
                .ToArray();

            int[] expectedRoomNumbers = { 1, 3, 4, 5, 6, 12, 14, 25, 26, 27, 28, 29 };

            Trace.WriteLine("Expected room numbers: " + string.Join(", ", expectedRoomNumbers));
            Trace.WriteLine("Actual room numbers:   " + string.Join(", ", actualRoomNumbers));

            CollectionAssert.AreEquivalent(expectedRoomNumbers, actualRoomNumbers);
        }
    }
}