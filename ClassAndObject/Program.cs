//Task 4
using System;
class Program
{
    static void Main(string[] args)
    {
        Event ev = new Event("Live Concert", new DateTime(2025, 8, 10), "19:00", "Music Arena", 100, 500, EventType.Concert);
        Booking booking = new Booking(ev);

        booking.GetEventDetails();
        booking.BookTickets(3);
        booking.CancelBooking(1);

        Console.WriteLine($"\nAvailable Tickets: {booking.GetAvailableNoOfTickets()}");
        Console.WriteLine($"Total Revenue: Rs.{ev.CalculateTotalRevenue()}");
    }
}

public enum EventType
{
    Movie,
    Sports,
    Concert
}
public class Event
{
    public string EventName { get; set; }
    public DateTime EventDate { get; set; }
    public string EventTime { get; set; }
    public string VenueName { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public decimal TicketPrice { get; set; }
    public EventType EventType { get; set; }

    public Event(string eventName, DateTime eventDate, string eventTime, string venueName, int totalSeats, decimal ticketPrice, EventType eventType)
    {
        EventName = eventName;
        EventDate = eventDate;
        EventTime = eventTime;
        VenueName = venueName;
        TotalSeats = totalSeats;
        AvailableSeats = totalSeats;
        TicketPrice = ticketPrice;
        EventType = eventType;
    }
    public decimal CalculateTotalRevenue()
    {
        return (TotalSeats - AvailableSeats) * TicketPrice;
    }
    public int GetBookedNoOfTickets()
    {
        return TotalSeats - AvailableSeats;
    }
    public void BookTickets(int numTickets)
    {
        if (numTickets <= AvailableSeats)
        {
            AvailableSeats -= numTickets;
            Console.WriteLine($"{numTickets} tickets booked.");
        }
        else
        {
            Console.WriteLine("Not enough tickets available.");
        }
    }
    public void CancelBooking(int numTickets)
    {
        if (AvailableSeats + numTickets <= TotalSeats)
        {
            AvailableSeats += numTickets;
            Console.WriteLine($"{numTickets} tickets cancelled.");
        }
        else
        {
            Console.WriteLine("Invalid cancel request.");
        }
    }
    public void DisplayEventDetails()
    {
        Console.WriteLine($"\nEvent: {EventName}");
        Console.WriteLine($"Date: {EventDate.ToShortDateString()}, Time: {EventTime}");
        Console.WriteLine($"Venue: {VenueName}");
        Console.WriteLine($"Available Seats: {AvailableSeats}");
        Console.WriteLine($"Ticket Price: Rs.{TicketPrice}, Type: {EventType}");
    }
}

public class Venue
{
    public string VenueName { get; set; }
    public string Address { get; set; }
    public Venue(string venueName, string address)
    {
        VenueName = venueName;
        Address = address;
    }

    public void DisplayVenueDetails()
    {
        Console.WriteLine($"Venue: {VenueName}, Address: {Address}");
    }
}
public class Customer
{
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Customer(string name, string email, string phone)
    {
        CustomerName = name;
        Email = email;
        PhoneNumber = phone;
    }
    public void DisplayCustomerDetails()
    {
        Console.WriteLine($"Customer: {CustomerName}, Email: {Email}, Phone: {PhoneNumber}");
    }
}
public class Booking
{
    public Event BookedEvent { get; set; }
    public int BookedTickets { get; set; }
    public decimal TotalCost { get; set; }

    public Booking(Event bookedEvent)
    {
        BookedEvent = bookedEvent;
        BookedTickets = 0;
        TotalCost = 0;
    }

    public void CalculateBookingCost(int numTickets)
    {
        TotalCost = numTickets * BookedEvent.TicketPrice;
        Console.WriteLine($"Total Booking Cost: Rs.{TotalCost}");
    }

    public void BookTickets(int numTickets)
    {
        BookedEvent.BookTickets(numTickets);
        BookedTickets += numTickets;
        CalculateBookingCost(BookedTickets);
    }

    public void CancelBooking(int numTickets)
    {
        BookedEvent.CancelBooking(numTickets);
        BookedTickets -= numTickets;
        CalculateBookingCost(BookedTickets);
    }

    public int GetAvailableNoOfTickets()
    {
        return BookedEvent.AvailableSeats;
    }

    public void GetEventDetails()
    {
        BookedEvent.DisplayEventDetails();
    }
}
