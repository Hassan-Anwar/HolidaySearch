using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace HolidaySearch.Models
{
    public class Hotel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("arrival_date")]
        public DateTime ArrivalDate { get; set; }

        [JsonProperty("price_per_night")]
        public decimal PricePerNight { get; set; }

        [JsonProperty("local_airports")]
        public List<string> LocalAirports { get; set; } = new List<string>();

        [JsonProperty("nights")]
        public int Nights { get; set; }
    }
}
