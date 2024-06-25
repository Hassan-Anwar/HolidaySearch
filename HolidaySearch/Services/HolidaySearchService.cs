using HolidaySearch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            
        }
    }
}
