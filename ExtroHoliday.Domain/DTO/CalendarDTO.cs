namespace ExtroHoliday.Domain.DTO
{
    public class CalendarDTO
    {

        public DateOnly Date { get; set; }
        public string DayOfWeek { get; set; }

        public string NonWorkingDay { get; set; }

        public string? Holiday { get; set; }
    }
}
