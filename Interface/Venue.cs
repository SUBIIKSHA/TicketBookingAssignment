namespace Bean
{
    public class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }

        public Venue(string name, string address)
        {
            VenueName = name;
            Address = address;
        }

        public void DisplayVenueDetails()
        {
            Console.WriteLine($"Venue: {VenueName}, Address: {Address}");
        }
    }
}
