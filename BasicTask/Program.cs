using System;

class Program
{
    static void Main(string[] args)
    {
        int availableTickets = 50;
        string input="";

        do
        {
            // Task 1: Conditional Statement
            Console.Write("Enter number of tickets to book: ");
            int noOfBooking = Convert.ToInt32(Console.ReadLine());

            if (noOfBooking <= availableTickets)
            {
                availableTickets -= noOfBooking;
                Console.WriteLine("Remaining tickets: " + availableTickets);

                // Task 2: Nested Conditional Statements
                Console.WriteLine("Choose Ticket Type: Silver / Gold / Diamond");
                string ticketType = Console.ReadLine();
                int ticketPrice = 0;

                if (ticketType == "Silver")
                {
                    ticketPrice = 150;
                }
                else if (ticketType == "Gold")
                {
                    ticketPrice = 250;
                }
                else if (ticketType == "Diamond")
                {
                    ticketPrice = 400;
                }
                else
                {
                    Console.WriteLine("Invalid ticket type selected.");
                    continue;
                }

                int totalAmount = ticketPrice * noOfBooking;
                Console.WriteLine($"Total cost for {noOfBooking} {ticketType} tickets: Rs.{totalAmount}");
            }
            else
            {
                Console.WriteLine($"Not enough tickets available. Only {availableTickets} left");
            }

            // Task 3: Looping
            Console.Write("\nType 'Exit' to stop or press Enter to continue booking: ");
            input = Console.ReadLine();

        } while (input!="exit");
    }
}
