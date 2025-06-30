using Bean;

namespace Bean
{
    public enum EventType { Movie, Sports, Concert }

    public abstract class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTime { get; set; }
        public Venue Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public EventType Type { get; set; }

        public Event() { }

        public Event(string name, DateTime date, string time, Venue venue, int totalSeats, decimal price, EventType type)
        {
            EventName = name;
            EventDate = date;
            EventTime = time;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = price;
            Type = type;
        }

        public abstract void DisplayEventDetails();

        public int GetAvailableTickets()
        {
            return AvailableSeats;
        }

        public int GetBookedTickets()
        {
            return TotalSeats - AvailableSeats;
        }

        public decimal CalculateTotalRevenue()
        {
            return GetBookedTickets() * TicketPrice;
        }

        public void BookTickets(int count)
        {
            if (AvailableSeats >= count)
            {
                AvailableSeats -= count;
                Console.WriteLine("Tickets booked successfully.");
            }
            else
            {
                Console.WriteLine("Not enough tickets available.");
            }
        }

        public void CancelBooking(int count)
        {
            if (AvailableSeats + count <= TotalSeats)
            {
                AvailableSeats += count;
                Console.WriteLine("Tickets cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Invalid cancel count.");
            }
        }
    }

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie(string name, DateTime date, string time, Venue venue, int totalSeats, decimal price,
                     string genre, string actor, string actress)
            : base(name, date, time, venue, totalSeats, price, EventType.Movie)
        {
            Genre = genre;
            ActorName = actor;
            ActressName = actress;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"[Movie] {EventName}, Date: {EventDate.ToShortDateString()} {EventTime}, " +
                              $"Seats: {AvailableSeats}/{TotalSeats}, Price: Rs.{TicketPrice}, Genre: {Genre}, " +
                              $"Actors: {ActorName} & {ActressName}");
        }
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; }

        public Concert(string name, DateTime date, string time, Venue venue, int totalSeats, decimal price,
                       string artist, string concertType)
            : base(name, date, time, venue, totalSeats, price, EventType.Concert)
        {
            Artist = artist;
            ConcertType = concertType;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"[Concert] {EventName}, Artist: {Artist}, Type: {ConcertType}, " +
                              $"Seats: {AvailableSeats}/{TotalSeats}, Price: Rs.{TicketPrice}");
        }
    }

    public class Sports : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sports(string name, DateTime date, string time, Venue venue, int totalSeats, decimal price,
                      string sportName, string teamsName)
            : base(name, date, time, venue, totalSeats, price, EventType.Sports)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"[Sports] {EventName}, Match: {TeamsName}, Sport: {SportName}, " +
                              $"Seats: {AvailableSeats}/{TotalSeats}, Price: Rs.{TicketPrice}");
        }
    }
}
