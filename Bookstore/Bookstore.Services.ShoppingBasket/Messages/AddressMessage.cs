namespace Bookstore.Services.ShoppingBasket.Messages
{
    public class AddressMessage
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}