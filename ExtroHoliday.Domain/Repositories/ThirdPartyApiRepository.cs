using ExtroHoliday.Domain.Entities;
using ExtroHoliday.Domain.Repositories.Interface;
using Newtonsoft.Json.Linq;

namespace ExtroHoliday.Domain.Repositories
{
    public class ThirdPartyApiRepository : IThirdPartyApiRepository
    {

        private static readonly HttpClient _client;

        static ThirdPartyApiRepository()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://sholiday.faboul.se/")
            };
        }

        public async Task<List<CalendarModel>> GetWholeYearCalendar(int year)
        {
            string url = string.Format("dagar/v2.1/{0}", year);

            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var content = JObject.Parse(stringResponse)["dagar"].ToObject<CalendarModel[]>().ToList(); ;

                return content;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

    }
}
