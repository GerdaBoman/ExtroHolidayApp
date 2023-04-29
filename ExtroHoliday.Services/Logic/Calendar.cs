using ExtroHoliday.Core.Logic.Interface;
using ExtroHoliday.Core.Mapper.Interface;
using ExtroHoliday.Domain.DTO;

using ExtroHoliday.Domain.Services.Interface;

namespace ExtroHoliday.Core.Logic
{
    public class Calendar : ICalendar
    {
        private IThirdPartyApiService _service;
        private ICalendarValueMapper _mapper;

        public Calendar(IThirdPartyApiService service, ICalendarValueMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<GetRedDaysDTO>> GetCalendarWithValues(int year)
        {
            List<GetRedDaysDTO> listWithValues = new List<GetRedDaysDTO>();

            var results = await _service.GetCalender(year);


            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].NonWorkingDay == "Ja")
                {
                    var day = _mapper.AddValuesToDate(results[i], 5, true);
                    listWithValues.Add(day);
                }

                else if (results[i + 1].Holiday == "Ja" && results[i - 1].NonWorkingDay == "Ja")
                {
                    var day = _mapper.AddValuesToDate(results[i], 4, true);
                    listWithValues.Add(day);
                }

                else if (results[i - 1].NonWorkingDay == "Ja" || results[i + 1].NonWorkingDay == "Ja")
                {
                    var day = _mapper.AddValuesToDate(results[i], 3, true);
                    listWithValues.Add(day);
                }
                else if (results[i - 2].NonWorkingDay == "Ja" && results[i + 2].NonWorkingDay == "Ja")
                {
                    var day = _mapper.AddValuesToDate(results[i], 3, true);
                    listWithValues.Add(day);
                }
                else
                {
                    var day = _mapper.AddValuesToDate(results[i], 0, false);
                    listWithValues.Add(day);
                }
            }

            return listWithValues;

        }

        public async Task<List<CalendarForFrontEnd>> DatesToTakeOff(int year)
        {
            var results = await GetCalendarWithValues(year);
            var potentialDays = new List<GetRedDaysDTO>();

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].PotentialDayOff == true)
                {
                    int sequenceLength = 1;
                    int j = i + 1;
                    while (j < results.Count && results[j].PotentialDayOff == true)
                    {
                        sequenceLength++;
                        j++;
                    }

                    if (sequenceLength >= 5)
                    {
                        potentialDays.AddRange(results.GetRange(i, sequenceLength));
                        i = j - 1;
                    }
                }
            }

            var recommendedList = new List<CalendarForFrontEnd>();

            for (int i = 0; i < potentialDays.Count; i++)
            {
                if (potentialDays[i].NonWorkingDay == "Nej" && potentialDays[i].Value != 2)
                {
                    var day = _mapper.MapGetRedDaysForFrontend(potentialDays[i], "yellow");
                    recommendedList.Add(day);
                }
                else
                {
                    var day = _mapper.MapGetRedDaysForFrontend(potentialDays[i], "red");
                    recommendedList.Add(day);
                }
            }
            return recommendedList;
        }
    }
}
