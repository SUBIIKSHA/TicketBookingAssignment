using Bean;
using Service;

namespace Bean
{
    public class EventServiceProviderImpl : IEventServiceProvider
    {
        protected Event[] events = new Event[10];
        protected int eventCount = 0;

        public virtual Event CreateEvent()
        {
            if (eventCount >= events.Length)
            {
                Console.WriteLine("Event limit reached.");
                return null;
            }

            Console.Write("Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Time: ");
            string time = Console.ReadLine();
            Console.Write("Venue Name: ");
            string venueName = Console.ReadLine();
            Console.Write("Venue Address: ");
            string address = Console.ReadLine();
            Console.Write("Total Seats: ");
            int seats = int.Parse(Console.ReadLine());
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Type (Movie/Sports/Concert): ");
            string type = Console.ReadLine();

            Venue venue = new Venue(venueName, address);
            Event e = null;

            if (type == "Movie")
            {
                Console.Write("Genre: ");
                string genre = Console.ReadLine();
                Console.Write("Actor: ");
                string actor = Console.ReadLine();
                Console.Write("Actress: ");
                string actress = Console.ReadLine();

                e = new Movie(name, date, time, venue, seats, price, genre, actor, actress);
            }
            else if (type == "Concert")
            {
                Console.Write("Artist: ");
                string artist = Console.ReadLine();
                Console.Write("Concert Type: ");
                string concertType = Console.ReadLine();

                e = new Concert(name, date, time, venue, seats, price, artist, concertType);
            }
            else if (type == "Sports")
            {
                Console.Write("Sport Name: ");
                string sport = Console.ReadLine();
                Console.Write("Teams: ");
                string teams = Console.ReadLine();

                e = new Sports(name, date, time, venue, seats, price, sport, teams);
            }

            events[eventCount++] = e;
            return e;
        }

        public Event[] GetEventDetails() => events;

        public int GetAvailableNoOfTickets(string eventName)
        {
            foreach (var e in events)
            {
                if (e != null && e.EventName == eventName)
                    return e.AvailableSeats;
            }
            return -1;
        }
    }
}
