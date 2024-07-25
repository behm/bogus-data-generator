namespace BogusDataDemo.Models
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public Contact Contact { get; set; }
        public string ContactEmail { get; set; }
        public Address Address { get; set; }
    }
}
