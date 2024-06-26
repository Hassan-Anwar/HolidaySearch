using HolidaySearch.Models;
using Newtonsoft.Json;

namespace HolidaySearch.Services
{
    public class HolidaySearchService
    {
        private List<Flight> Flights { get; set; }
        private List<Hotel> Hotels { get; set; }

        public HolidaySearchService(string flightsJsonPath, string hotelsJsonPath)
        {
            Flights = JsonConvert.DeserializeObject<List<Flight>>(File.ReadAllText(flightsJsonPath));
            Hotels = JsonConvert.DeserializeObject<List<Hotel>>(File.ReadAllText(hotelsJsonPath));
        }

        public List<Package> SearchHolidays(string departingFrom, string travelingTo, DateTime departureDate, int duration)
        {

            if (Flights == null || Hotels == null)
            {
                throw new InvalidOperationException("Flights or Hotels data is not loaded.");
            }

            var matchingFlights = Flights.Where(f => (departingFrom == "Any" || f.From == departingFrom)
                            && f.To == travelingTo
                            && f.DepartureDate == departureDate).ToList();

            var matchingHotels = Hotels.Where(h => h.LocalAirports.Contains(travelingTo)
                            && h.ArrivalDate == departureDate
                            && h.Nights == duration).ToList();

            var holidays = new List<Package>();

            foreach (var flight in matchingFlights)
            {
                foreach (var hotel in matchingHotels)
                {
                    holidays.Add(new Package { Flight = flight, Hotel = hotel });
                }
            }

            return holidays.OrderBy(h => h.TotalPrice).ToList();
        }
    }
}

