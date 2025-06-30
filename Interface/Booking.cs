namespace Bean
{
    public class Booking
    {
        private static int idCounter = 1;

        public int BookingId { get; private set; }
        public Event BookedEvent { get; set; }
        public Customer[] Customers { get; set; }
        public int TicketCount { get; set; }
        public decimal TotalCost { get; set; }

        public Booking(Event e, Customer[] customers, int ticketCount)
        {
            BookingId = idCounter++;
            BookedEvent = e;
            Customers = customers;
            TicketCount = ticketCount;
            TotalCost = ticketCount * e.TicketPrice;
        }

        public void DisplayBooking()
        {
            Console.WriteLine($"Booking ID: {BookingId}, Event: {BookedEvent.EventName}, Tickets: {TicketCount}, Total: {TotalCost}");
        }
    }
}
