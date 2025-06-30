using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose Event Type: 1. Movie  2. Concert  3. Sports");
        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Event selectedEvent = TicketBookingSystem.CreateEvent(choice);

        TicketBookingSystem.ShowDetails(selectedEvent);

        Console.Write("\nEnter number of tickets to book: ");
        int bookCount = Convert.ToInt32(Console.ReadLine());
        TicketBookingSystem.BookTickets(selectedEvent, bookCount);

        Console.Write("\nDo you want to cancel any tickets? (yes/no): ");
        if (Console.ReadLine().ToLower() == "yes")
        {
            Console.Write("Enter number of tickets to cancel: ");
            int cancelCount = Convert.ToInt32(Console.ReadLine());
            TicketBookingSystem.CancelTickets(selectedEvent, cancelCount);
        }

        Console.WriteLine("\nDetails:");
        TicketBookingSystem.ShowDetails(selectedEvent);
    }
}

public enum EventType
{
    Movie,
    Concert,
    Sports
}

public class Event
{
    public string Name;
    public DateTime Date;
    public string Time;
    public string Venue;
    public int TotalSeats;
    public int AvailableSeats;
    public decimal Price;
    public EventType Type;

    public Event(string name, DateTime date, string time, string venue, int seats, decimal price, EventType type)
    {
        Name = name;
        Date = date;
        Time = time;
        Venue = venue;
        TotalSeats = seats;
        AvailableSeats = seats;
        Price = price;
        Type = type;
    }

    public virtual void DisplayEventDetails()
    {
        Console.WriteLine($"\nEvent: {Name}");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Date: {Date.ToShortDateString()} Time: {Time}");
        Console.WriteLine($"Venue: {Venue}");
        Console.WriteLine($"Available Seats: {AvailableSeats}");
        Console.WriteLine($"Ticket Price: Rs.{Price}");
    }

    public void BookTickets(int count)
    {
        if (count <= AvailableSeats)
        {
            AvailableSeats -= count;
            Console.WriteLine($"{count} tickets booked. Total: Rs.{count * Price}");
        }
        else
        {
            Console.WriteLine("Not enough seats available.");
        }
    }

    public void CancelTickets(int count)
    {
        if (AvailableSeats + count <= TotalSeats)
        {
            AvailableSeats += count;
            Console.WriteLine($"{count} tickets cancelled.");
        }
        else
        {
            Console.WriteLine("Invalid cancel request.");
        }
    }
}

public class Movie : Event
{
    private string Genre;
    private string ActorName;
    private string ActressName;

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
        base.DisplayEventDetails();
        Console.WriteLine($"Movie Genre: {Genre}");
        Console.WriteLine($"Actor: {ActorName}, Actress: {ActressName}");
    }
}


public class Concert : Event
{
    private string Artist;
    private string ConcertType;

    public Concert(string name, DateTime date, string time, string venue, int seats, decimal price,
                   string artist, string concertType)
        : base(name, date, time, venue, seats, price, EventType.Concert)
    {
        Artist = artist;
        ConcertType = concertType;
    }

    public override void DisplayEventDetails()
    {
        base.DisplayEventDetails();
        Console.WriteLine($"Artist: {Artist}, Type: {ConcertType}");
    }
}

public class Sports : Event
{
    private string SportName;
    private string Teams;

    public Sports(string name, DateTime date, string time, string venue, int seats, decimal price,
                  string sportName, string teams)
        : base(name, date, time, venue, seats, price, EventType.Sports)
    {
        SportName = sportName;
        Teams = teams;
    }

    public override void DisplayEventDetails()
    {
        base.DisplayEventDetails();
        Console.WriteLine($"Sport: {SportName}, Match: {Teams}");
    }
}


public static class TicketBookingSystem
{
    public static Event CreateEvent(int choice)
    {
        switch (choice)
        {
            case 1:
                return new Movie("Leo", DateTime.Parse("2025-07-10"), "18:00", "PVR Cinemas", 100, 300,
                                 "Action", "Vijay", "Nayanthara");
            case 2:
                return new Concert("Carnatic Night", DateTime.Parse("2025-08-15"), "19:30", "Open Arena", 80, 250,
                                   "AR Rahman", "Classical");
            case 3:
                return new Sports("Ind vs Pak", DateTime.Parse("2025-09-05"), "15:00", "Chennai Stadium", 150, 400,
                                  "Cricket", "India vs Pakistan");
            default:
                return null;
        }
    }

    public static void BookTickets(Event e, int count)
    {
        e.BookTickets(count);
    }

    public static void CancelTickets(Event e, int count)
    {
        e.CancelTickets(count);
    }

    public static void ShowDetails(Event e)
    {
        e.DisplayEventDetails();
    }
}
