using ExtroHoliday.Domain.DTO;

namespace ExtroHoliday.Core.Mapper.Interface
{
    public interface ICalendarValueMapper
    {
        CalendarForFrontEnd AddValuesToDay(CalendarDTO model, string colour);
        CalendarForFrontEnd MapGetRedDaysForFrontend(GetRedDaysDTO model, string? colour);
        GetRedDaysDTO AddValuesToDate(CalendarDTO model, int value, bool potential);
    }
}
