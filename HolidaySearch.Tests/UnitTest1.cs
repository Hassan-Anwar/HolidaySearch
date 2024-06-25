using HolidaySearch.Models;
using HolidaySearch.Services;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace HolidaySearch.Tests
{
    public class HolidaySearchServiceTests
    {
        private readonly HolidaySearchService _holidaySearchService;

        public HolidaySearchServiceTests()
        {
            string flightsJsonPath = Path.Combine(AppContext.BaseDirectory, "flights.json");
            string hotelsJsonPath = Path.Combine(AppContext.BaseDirectory, "hotels.json");
            _holidaySearchService = new HolidaySearchService(flightsJsonPath, hotelsJsonPath);
        }
    }
}
