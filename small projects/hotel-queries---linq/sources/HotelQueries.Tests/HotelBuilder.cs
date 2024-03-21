using System.Collections.Generic;
using System.Linq;
using iQuest.HotelQueries.DataAccess;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.Tests
{
    public class HotelBuilder
    {
        public static Hotel CreateHotel()
        {
            RoomsRepository roomsRepository = new RoomsRepository();
            List<Room> rooms = roomsRepository.GetAll().ToList();

            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> customers = customerRepository.GetAll().ToList();

            ReservationRepository reservationRepository = new ReservationRepository();
            List<Reservation> reservations = reservationRepository.GetAll(customers, rooms).ToList();

            return new Hotel
            {
                Rooms = rooms,
                Customers = customers,
                Reservations = reservations
            };
        }
    }
}