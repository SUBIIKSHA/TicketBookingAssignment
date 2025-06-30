using Bean;

namespace Service
{
    public interface IBookingSystemServiceProvider
    {
        decimal CalculateBookingCost(int count, decimal price);
        Booking BookTickets(string eventName, int count, Customer[] customers);
        void CancelBooking(int bookingId);
        Booking GetBookingDetails(int bookingId);
    }
}
