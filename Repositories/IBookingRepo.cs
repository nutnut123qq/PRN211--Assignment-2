using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IBookingRepo
    {
        void AddBooking(BookingReservation booking);
        IEnumerable<BookingReservation> GetBookingsByCustomer(int customerId);
        IEnumerable<int> GetBookedRooms(DateTime checkIn, DateTime checkOut);
        IEnumerable<BookingReservation> GetAllBookings();
    }
}
