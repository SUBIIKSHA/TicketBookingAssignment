namespace Bean
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer() { }

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
}
