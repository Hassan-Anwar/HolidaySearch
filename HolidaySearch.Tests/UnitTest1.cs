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
            string flightsJsonPath = Path.Combine(AppContext.BaseDirectory, "shared", "flight.json");
            string hotelsJsonPath = Path.Combine(AppContext.BaseDirectory, "shared", "hotels.json");
            _holidaySearchService = new HolidaySearchService(flightsJsonPath, hotelsJsonPath);
        }
        [Fact]
        public void Test_Customer1()
        {
            var results = _holidaySearchService.SearchHolidays("MAN", "AGP", new DateTime(2023, 7, 1), 7);
            Assert.NotEmpty(results);
            var bestHoliday = results.First();
            Assert.Equal(2, bestHoliday.Flight.Id);
            Assert.Equal(9, bestHoliday.Hotel.Id);
        }
    }
}
