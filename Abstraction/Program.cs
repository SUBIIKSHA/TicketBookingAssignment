using System;

class Program
{
    static void Main(string[] args)
    {
        TicketBookingSystem system = new TicketBookingSystem();
        string choice;

        do
        {
            Console.WriteLine("Ticket Booking");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Cancel Tickets");
            Console.WriteLine("4. View Available Seats");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": system.CreateEvent(); break;
                case "2": system.BookTickets(); break;
                case "3": system.CancelTickets(); break;
                case "4": system.GetAvailableSeats(); break;
                case "5": Console.WriteLine("Thank you!"); break;
                default: Console.WriteLine("Invalid choice."); break;
            }

        } while (choice != "5");
    }
}

public enum EventType
{
    Movie,
    Concert,
    Sports
}

public abstract class Event
{
    public string EventName { get; set; }
    public DateTime EventDate { get; set; }
    public string EventTime { get; set; }
    public string VenueName { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public decimal TicketPrice { get; set; }
    public EventType EventType { get; set; }

    public Event(string name, DateTime date, string time, string venue, int seats, decimal price, EventType type)
    {
        EventName = name;
        EventDate = date;
        EventTime = time;
        VenueName = venue;
        TotalSeats = seats;
        AvailableSeats = seats;
        TicketPrice = price;
        EventType = type;
    }

    public abstract void DisplayEventDetails();

    public void BookTickets(int count)
    {
        if (AvailableSeats >= count)
        {
            AvailableSeats -= count;
            Console.WriteLine($"{count} tickets booked.");
        }
        else
        {
            Console.WriteLine("Not enough seats.");
        }
    }

    public void CancelTickets(int count)
    {
        if ((AvailableSeats + count) <= TotalSeats)
        {
            AvailableSeats += count;
            Console.WriteLine($"{count} tickets cancelled.");
        }
        else
        {
            Console.WriteLine("Cannot cancel more than booked.");
        }
    }

    public int GetAvailableSeats()
    {
        return AvailableSeats;
    }
}

public class Movie : Event
{
    public string Genre { get; set; }
    public string ActorName { get; set; }
    public string ActressName { get; set; }

    public Movie(string name, DateTime date, string time, string venue, int seats, decimal price,
                 string genre, string actor, string actress)
        : base(name, date, time, venue, seats, price, EventType.Movie)
    {
        Genre = genre;
        ActorName = actor;
        ActressName = actress;
    }

    public override void DisplayEventDetails()
    {
        Console.WriteLine($"\n[Movie] {EventName} | Date: {EventDate.ToShortDateString()} | Time: {EventTime} | Venue: {VenueName}");
        Console.WriteLine($"Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}");
        Console.WriteLine($"Available Seats: {AvailableSeats} | Price: Rs.{TicketPrice}");
    }
}

public class Concert : Event
{
    public string Artist { get; set; }
    public string ConcertType { get; set; }

    public Concert(string name, DateTime date, string time, string venue, int seats, decimal price,
                   string artist, string concertType)
        : base(name, date, time, venue, seats, price, EventType.Concert)
    {
        Artist = artist;
        ConcertType = concertType;
    }

    public override void DisplayEventDetails()
    {
        Console.WriteLine($"\n[Concert] {EventName} | Date: {EventDate.ToShortDateString()} | Time: {EventTime} | Venue: {VenueName}");
        Console.WriteLine($"Artist: {Artist}, Type: {ConcertType}");
        Console.WriteLine($"Available Seats: {AvailableSeats} | Price: Rs.{TicketPrice}");
    }
}

public class Sports : Event
{
    public string SportName { get; set; }
    public string TeamsName { get; set; }

    public Sports(string name, DateTime date, string time, string venue, int seats, decimal price,
                  string sport, string teams)
        : base(name, date, time, venue, seats, price, EventType.Sports)
    {
        SportName = sport;
        TeamsName = teams;
    }

    public override void DisplayEventDetails()
    {
        Console.WriteLine($"\n[Sports] {EventName} | Date: {EventDate.ToShortDateString()} | Time: {EventTime} | Venue: {VenueName}");
        Console.WriteLine($"Game: {SportName}, Match: {TeamsName}");
        Console.WriteLine($"Available Seats: {AvailableSeats} | Price: Rs.{TicketPrice}");
    }
}

public abstract class BookingSystem
{
    public abstract void CreateEvent();
    public abstract void BookTickets();
    public abstract void CancelTickets();
    public abstract void GetAvailableSeats();
}

public class TicketBookingSystem : BookingSystem
{
    private List<Event> events = new List<Event>();

    public override void CreateEvent()
    {
        Console.Write("Enter Event Type (Movie/Concert/Sports): ");
        string type = Console.ReadLine();

        Console.Write("Event Name: ");
        string name = Console.ReadLine();
        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Time: ");
        string time = Console.ReadLine();
        Console.Write("Venue: ");
        string venue = Console.ReadLine();
        Console.Write("Total Seats: ");
        int seats = int.Parse(Console.ReadLine());
        Console.Write("Ticket Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Event e = null;

        if (type== "movie")
        {
            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            Console.Write("Actor: ");
            string actor = Console.ReadLine();
            Console.Write("Actress: ");
            string actress = Console.ReadLine();
            e = new Movie(name, date, time, venue, seats, price, genre, actor, actress);
        }
        else if (type== "concert")
        {
            Console.Write("Artist: ");
            string artist = Console.ReadLine();
            Console.Write("Concert Type: ");
            string concertType = Console.ReadLine();
            e = new Concert(name, date, time, venue, seats, price, artist, concertType);
        }
        else if (type== "sports")
        {
            Console.Write("Sport Name: ");
            string sport = Console.ReadLine();
            Console.Write("Teams: ");
            string teams = Console.ReadLine();
            e = new Sports(name, date, time, venue, seats, price, sport, teams);
        }

        if (e != null)
        {
            events.Add(e);
            Console.WriteLine("Event created successfully.");
            e.DisplayEventDetails();
        }
        else
        {
            Console.WriteLine("Invalid event type.");
        }
    }

    public override void BookTickets()
    {
        Console.Write("Enter Event Name: ");
        string name = Console.ReadLine();
        Console.Write("Number of tickets to book: ");
        int count = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].EventName==name)
            {
                events[i].BookTickets(count);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Event not found.");
        }
    }

    public override void CancelTickets()
    {
        Console.Write("Enter Event Name: ");
        string name = Console.ReadLine();
        Console.Write("Number of tickets to cancel: ");
        int count = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].EventName==name)
            {
                events[i].CancelTickets(count);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Event not found.");
        }
    }

    public override void GetAvailableSeats()
    {
        Console.Write("Enter Event Name: ");
        string name = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].EventName==name)
            {
                Console.WriteLine($"Available Seats: {events[i].GetAvailableSeats()}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Event not found.");
        }
    }
}
