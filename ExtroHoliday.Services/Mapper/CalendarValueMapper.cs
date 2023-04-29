using ExtroHoliday.Core.Mapper.Interface;
using ExtroHoliday.Domain.DTO;

namespace ExtroHoliday.Core.Mapper;

public class CalendarValueMapper : ICalendarValueMapper
{
    public CalendarForFrontEnd AddValuesToDay(CalendarDTO model, string? colour)
    {
        if (model == null)
        {
            return null;
        }
        else
        {
            return new CalendarForFrontEnd
            {
                Date = model.Date,
                DayOfWeek = model.DayOfWeek,
                Title = CheckTitleContent(model.Holiday),
                BackgroundColor = colour
            };
        }
    }
    public CalendarForFrontEnd MapGetRedDaysForFrontend(GetRedDaysDTO model, string? colour)
    {
        if (model == null)
        {
            return null;
        }
        else
        {
            return new CalendarForFrontEnd
            {
                Date = model.Date,
                DayOfWeek = model.DayOfWeek,
                Title = CheckTitleContent(model.Holiday),
                BackgroundColor = colour
            };
        }
    }

    public GetRedDaysDTO AddValuesToDate(CalendarDTO model, int value, bool potential)
    {
        if (model == null)
        {
            return null;
        }
        else
        {
            return new GetRedDaysDTO
            {
                Date = model.Date,
                DayOfWeek = model.DayOfWeek,
                NonWorkingDay = CheckTitleContent(model.NonWorkingDay),
                Holiday = CheckTitleContent(model.Holiday),
                Value = value,
                PotentialDayOff = potential

            };
        }
    }

    public string? CheckTitleContent(string? title)
    {
        return title ?? string.Empty;
    }
}

