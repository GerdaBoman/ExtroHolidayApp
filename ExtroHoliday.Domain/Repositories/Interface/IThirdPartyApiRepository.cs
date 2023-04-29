using ExtroHoliday.Domain.Entities;

namespace ExtroHoliday.Domain.Repositories.Interface
{
    public interface IThirdPartyApiRepository
    {
        Task<List<CalendarModel>> GetWholeYearCalendar(int year);
    }
}
