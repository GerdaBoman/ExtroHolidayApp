using ExtroHoliday.Domain.DTO;

namespace ExtroHoliday.Core.Logic.Interface
{
    public interface ICalendar
    {
        Task<List<CalendarForFrontEnd>> DatesToTakeOff(int year);
        Task<List<GetRedDaysDTO>> GetCalendarWithValues(int year);
    }
}
