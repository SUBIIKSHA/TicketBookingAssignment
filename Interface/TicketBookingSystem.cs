using Bean;

class Program
{
    static void Main(string[] args)
    {
        BookingSystemServiceProviderImpl system = new BookingSystemServiceProviderImpl();
        string choice;

        do
        {
            Console.WriteLine("\n1. Create Event\n2. View Events\n3. Book Tickets\n4. Cancel Booking\n5. Get Booking Details\n6. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": system.CreateEvent(); break;
                case "2":
                    foreach (var e in system.GetEventDetails())
                        e?.DisplayEventDetails();
                    break;
                case "3":
                    Console.Write("Event Name: ");
                    string eventName = Console.ReadLine();
                    Console.Write("Tickets: ");
                    int count = int.Parse(Console.ReadLine());

                    Customer[] customers = new Customer[count];
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write($"Customer {i + 1} Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();
                        customers[i] = new Customer(name, email, phone);
                    }

                    Booking b = system.BookTickets(eventName, count, customers);
                    b?.DisplayBooking();
                    break;
                case "4":
                    Console.Write("Enter Booking ID to cancel: ");
                    int bid = int.Parse(Console.ReadLine());
                    system.CancelBooking(bid);
                    break;
                case "5":
                    Console.Write("Enter Booking ID: ");
                    int bid2 = int.Parse(Console.ReadLine());
                    Booking booking = system.GetBookingDetails(bid2);
                    if (booking != null)
                        booking.DisplayBooking();
                    else
                        Console.WriteLine("Booking not found.");
                    break;
                case "6": Console.WriteLine("Exiting."); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        } while (choice != "6");
    }
}
