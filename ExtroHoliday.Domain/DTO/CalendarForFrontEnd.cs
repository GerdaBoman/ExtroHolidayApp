namespace ExtroHoliday.Domain.DTO
{
    public class CalendarForFrontEnd
    {
        public DateOnly Date { get; set; }
        public string DayOfWeek { get; set; }
        public string? Title { get; set; }
        public string? BackgroundColor { get; set; }

    }
}
