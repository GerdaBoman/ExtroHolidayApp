namespace ExtroHoliday.Domain.DTO
{
    public class GetRedDaysDTO
    {
        public DateOnly Date { get; set; }
        public string? NonWorkingDay { get; set; }
        public string DayOfWeek { get; set; }   
        public string? Holiday { get; set; }
        public int Value { get; set; }
        public bool PotentialDayOff { get; set; }
    }
}
