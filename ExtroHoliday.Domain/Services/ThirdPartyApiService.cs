using ExtroHoliday.Domain.DTO;
using ExtroHoliday.Domain.Repositories.Interface;
using ExtroHoliday.Domain.Services.Interface;
using Mapster;

namespace ExtroHoliday.Domain.Services
{
    public class ThirdPartyApiService : IThirdPartyApiService
    {
        private IThirdPartyApiRepository _repo;

        public ThirdPartyApiService(IThirdPartyApiRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CalendarDTO>> GetCalender(int year)
        {
            return (await _repo.GetWholeYearCalendar(year)).AsQueryable().ProjectToType<CalendarDTO>().ToList();
        }



    }
}
