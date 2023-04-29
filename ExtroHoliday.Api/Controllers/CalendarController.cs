using ExtroHoliday.Core.Logic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExtroHoliday.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendar _calendar;

        public CalendarController(ICalendar calendar)
        {
            _calendar = calendar;
        }
        [HttpGet]
        public async Task<IActionResult> GetCalendar(int year)
        {
            var result = await _calendar.DatesToTakeOff(year);

            return result.Count == 0 ? NotFound() : Ok(result);
        }
    }
}
