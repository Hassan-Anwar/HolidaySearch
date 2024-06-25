namespace HolidaySearch.Models
{
    public class Package
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice => (Hotel.PricePerNight * Hotel.Nights) + Flight.Price;
    }
}
