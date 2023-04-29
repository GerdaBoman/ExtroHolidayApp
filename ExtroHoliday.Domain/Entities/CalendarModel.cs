using Newtonsoft.Json;

namespace ExtroHoliday.Domain.Entities
{
    public class CalendarModel
    {
        [JsonProperty(PropertyName = "datum")]
        public DateOnly Date { get; set; }

        [JsonProperty(PropertyName = "veckodag")]
        public string DayOfWeek { get; set; }

        [JsonProperty(PropertyName = "arbetsfri dag")]
        public string NonWorkingDay { get; set; }

        [JsonProperty(PropertyName = "röd dag")]
        public string RedDay { get; set; }

        [JsonProperty(PropertyName = "vecka")]
        public int WeekNumber { get; set; }

        [JsonProperty(PropertyName = "dag i vecka")]
        public int DayInWeek { get; set; }

        [JsonProperty(PropertyName = "helgdag")]
        public string? Holiday { get; set; }

    }
}
