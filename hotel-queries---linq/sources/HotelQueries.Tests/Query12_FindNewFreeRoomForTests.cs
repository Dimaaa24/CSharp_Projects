using System;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query12_FindNewFreeRoomForTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchForEquivalentRoomForNullReservation_ThenThrows()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                hotel.FindNewFreeRoomFor(null);
            });
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchForEquivalentRoomForReservationWithNullRoom_ThenThrows()
        {
            Reservation reservation = new Reservation();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                hotel.FindNewFreeRoomFor(reservation);
            });
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchForEquivalentRoomForReservation23_ThenReturnsOneOfThe3CorrectAnswers()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 23);
            PerformTest(reservationWithConflicts, new[] { 13, 19, 25 });
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchForEquivalentRoomForReservation160_ThenReturnsNull()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 160);
            PerformTest(reservationWithConflicts, null);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchForEquivalentRoomForReservation167_ThenReturnsOneOfThe4CorrectAnswers()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 167);
            PerformTest(reservationWithConflicts, new[] { 11, 14, 18, 30 });
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchForEquivalentRoomForReservation112_ThenReturnsNull()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 112);
            PerformTest(reservationWithConflicts, null);
        }

        [TestMethod]
        public void HavingAHotelInstance_WhenSearchForEquivalentRoomForReservation194_ThenReturnsNull()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 194);
            PerformTest(reservationWithConflicts, null);
        }

        private static void PerformTest(Reservation reservationWithConflicts, int[] validRoomNumbers)
        {
            Room actualRoom = hotel.FindNewFreeRoomFor(reservationWithConflicts);

            if (validRoomNumbers == null || validRoomNumbers.Length == 0)
            {
                Trace.WriteLine("Valid room numbers: <none>");
                Trace.WriteLine("Actual room number (proposed): " + (actualRoom?.Number.ToString() ?? "<null>"));

                Assert.IsNull(actualRoom);
            }
            else
            {
                Trace.WriteLine("Valid room numbers: " + string.Join(", ", validRoomNumbers));
                Trace.WriteLine("Actual room number (proposed): " + (actualRoom?.Number.ToString() ?? "<null>"));

                Assert.IsNotNull(actualRoom);
                CollectionAssert.Contains(validRoomNumbers, actualRoom.Number);
            }
        }
    }
}