using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries
{
    public class Hotel
    {
        public IEnumerable<Room> Rooms { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }

        /// <summary>
        /// 1) Return a collection with all rooms that can accomodate exactly 2 persons.
        /// </summary>
        public IEnumerable<Room> GetAllRoomsForTwoPersons()
        {
            return Rooms
                   .Where(x => x.MaxPersonCount == 2);
        }

        /// <summary>
        /// 2) Return all customers whose full name contains the specified searched text.
        /// The search must be case insensitive.
        /// </summary>
        public IEnumerable<Customer> FindCustomerByName(string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if(text.Length == 0)
            {
                return Enumerable.Empty<Customer>();
            }

            return Customers
                   .Where(x => x.FullName.IndexOf(text, StringComparison.OrdinalIgnoreCase) > -1 && 
                   !string.IsNullOrEmpty(text));
        }

        /// <summary>
        /// 3) Return all reservations made by companies.
        /// </summary>
        public IEnumerable<Reservation> GetCompanyReservations()
        {
            return Reservations
                    .Where(x => x.Customer is CompanyCustomer);
        }

        /// <summary>
        /// 4) Return all women customers that last checked in a specific period of time.
        /// </summary>
        public IEnumerable<Customer> FindWomen(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new ArgumentException($"{nameof(startTime)}-{nameof(endTime)}");
            }

            return Customers
                .OfType<PersonCustomer>()
                .Where(x => x.Gender == PersonGender.Female && 
                            x.LastAccommodation <= endTime && 
                            x.LastAccommodation >= startTime);
        }

        /// <summary>
        /// 5) Calculate how many persons can the hotel accomodate.
        /// </summary>
        public int CalculateHotelCapacity()
        {
            return Rooms
                    .Sum(x => x.MaxPersonCount);
        }

        /// <summary>
        /// 6) Having the Rooms sorted by surface, return a single page containing a number of exactly pageSize Rooms.
        /// The pageNumber starts from 0.
        ///
        /// This is useful when paginating a large number of items in order to display them in a webpage.
        /// </summary>
        public IEnumerable<Room> GetPageOfRoomsOrderedBySurface(int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return new List<Room>();
            return Rooms
                    .OrderBy(x => x.Surface)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize);
        }

        /// <summary>
        /// 7) Return the rooms sorted by <see cref="Room.MaxPersonCount"/> in a descending order.
        /// If two rooms have the same number of max persons, sort them further by <see cref="Room.Number"/> in ascending order.
        /// </summary>
        public IEnumerable<Room> GetRoomsOrderedByCapacity()
        {
            return Rooms
                    .OrderByDescending(x => x.MaxPersonCount)
                    .ThenBy(x => x.Number);
        }

        /// <summary>
        /// 8) Return all reservations for the specified customer.
        /// The reservations must be ordered from the most recent one to the oldest one.
        /// </summary>
        public IEnumerable<Reservation> GetReservationsOrderedByDateFor(int customerId)
        {
            return Reservations
                    .OrderByDescending(x => x.EndDate)
                    .Where(x => x.Customer.Id == customerId);
        }

        /// <summary>
        /// 9) Return a dictionary with the customers grouped by the last accommodation's year.
        /// The years must be enumerated in descending order.
        /// Customers must be ordered by full name.
        /// </summary>
        public List<KeyValuePair<int, Customer[]>> GetCustomersGroupedByYear()
        {
            return Customers
                .GroupBy(x => x.LastAccommodation.Year)
                .OrderByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.OrderBy(x => x.FullName).ToArray())
                .ToList();
        }

        /// <summary>
        /// 10) Calculate the average number of reservation per month.
        /// Consider the start date as the date of the reservation.
        /// </summary>
        public double CalculateAverageReservationsPerMonth()
        {
            return Reservations
                    .GroupBy(x => x.StartDate.Month)
                    .Average(x => x.Count());
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            return Reservations
                .Select(x => new
                {
                    Reservation = x,
                    Conflicts = Reservations.Where(y => y.ConflictsWith(x))
                })
                .Where(x => x.Conflicts.Any())
                .ToDictionary(x => x.Reservation, x => x.Conflicts.ToList());
        }

        /// <summary>
        /// 12) We have a reservation for a room, but there is a conflict: there is another reservation for the same room.
        /// Your task is to propose another similar room for the reservation.
        /// 
        /// Note: A similar room is a room that has the same number of maximum occupants or grater, has air conditioner if
        /// the original reserved room had, is disabled-friendly if the original reserved room was and
        /// has balcony if the original reserved room had one.
        /// </summary>
        public Room FindNewFreeRoomFor(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }

            if (reservation.Room == null)
            {
                throw new ArgumentException(nameof(reservation.Room));
            }

            return Rooms
                   .Where(x => x.OffersSameConditionsOrBetterThen(reservation.Room) &&
                               !Reservations.Any(y => y.ConflictsWith(reservation.StartDate , reservation.EndDate) &&
                               y.Room.Equals(x)))
                   .FirstOrDefault();
        }
    }
}