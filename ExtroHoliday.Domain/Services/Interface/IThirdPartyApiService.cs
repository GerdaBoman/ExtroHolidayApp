using ExtroHoliday.Domain.DTO;

namespace ExtroHoliday.Domain.Services.Interface
{
    public interface IThirdPartyApiService
    {
        Task<List<CalendarDTO>> GetCalender(int year);


    }
}
