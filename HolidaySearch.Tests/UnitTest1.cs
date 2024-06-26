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
        
        [Fact]
        public void Test_Customer2()
        {
            var results = _holidaySearchService.SearchHolidays("Any", "PMI", new DateTime(2023, 6, 15), 10);
            Assert.NotEmpty(results);
            var bestHoliday = results.First();
            Assert.Equal(6, bestHoliday.Flight.Id);
            Assert.Equal(5, bestHoliday.Hotel.Id);
        }

        [Fact]
        public void Test_Customer3()
        {
            var results = _holidaySearchService.SearchHolidays("Any", "LPA", new DateTime(2022, 11, 10), 14);
            Assert.NotEmpty(results);
            var bestHoliday = results.First();
            Assert.Equal(7, bestHoliday.Flight.Id);
            Assert.Equal(6, bestHoliday.Hotel.Id);
        }

        [Fact]
        public void Test_NoMatchingFlights()
        {
            var results = _holidaySearchService.SearchHolidays("XYZ", "AGP", new DateTime(2023, 7, 1), 7);
            Assert.Empty(results);
        }

        [Fact]
        public void Test_NoMatchingHotels()
        {
            var results = _holidaySearchService.SearchHolidays("MAN", "AGP", new DateTime(2023, 7, 1), 24);
            Assert.Empty(results);
        }
    }
}
