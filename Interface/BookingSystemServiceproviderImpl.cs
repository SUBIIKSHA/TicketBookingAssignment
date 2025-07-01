using Bean;
using Service;
using exceptions;
namespace Bean
{
    public class BookingSystemServiceProviderImpl : EventServiceProviderImpl, IBookingSystemServiceProvider
    {
        private Booking[] bookings = new Booking[10];
        private int bookingCount = 0;

        public decimal CalculateBookingCost(int count, decimal price) => count * price;

        public Booking BookTickets(string eventName, int count, Customer[] customers)
        {
            foreach (var e in events)
            {
                if (e != null && e.EventName == eventName)
                {
                    e.BookTickets(count);
                    Booking booking = new Booking(e, customers, count);
                    bookings[bookingCount++] = booking;
                    return booking;
                }
            }
            Console.WriteLine("Event not found.");
            return null;
        }

        public void CancelBooking(int bookingId)
        {
            for (int i = 0; i < bookingCount; i++)
            {
                if (bookings[i].BookingId == bookingId)
                {
                    bookings[i].BookedEvent.CancelBooking(bookings[i].TicketCount);
                    bookings[i] = null;
                    Console.WriteLine("Booking cancelled.");
                    return;
                }
            }
            throw new InvalidBookingIDException($"Booking ID '{bookingId}' is invalid.");
        }

        public Booking GetBookingDetails(int bookingId)
        {
            for (int i = 0; i < bookingCount; i++)
            {
                if (bookings[i] != null && bookings[i].BookingId == bookingId)
                    return bookings[i];
            }
            throw new InvalidBookingIDException($"Booking ID '{bookingId}' does not exist.");
        }
    }
}
