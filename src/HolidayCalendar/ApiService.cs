using System.Net.Http.Headers;
using System.Text.Json;


namespace HolidayCalendar {

    public class ApiService {

        private readonly string API_URL = "https://api.sallinggroup.com/v1/holidays";
        private readonly string BEARER_TOKEN;
        private HttpClient client;

        public ApiService() {
            //Token saved as environment variable
            BEARER_TOKEN = Environment.GetEnvironmentVariable("BEARER_TOKEN");
            if (string.IsNullOrEmpty(BEARER_TOKEN))
                throw new InvalidOperationException("BEARER_TOKEN environment variable is not set");
            
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BEARER_TOKEN);
        }

        public bool IsHoliday(string date) {            
            var responseBody = SendGetRequest($"{API_URL}/is-holiday?date={date}");
            return responseBody == "true";
        }
        
        public List<DateTime> GetHolidays(string startDate, string endDate) {            
            var responseBody = SendGetRequest($"{API_URL}/?startDate={startDate}&endDate={endDate}");
            var holidays = JsonSerializer.Deserialize<List<HolidayDTO>>(responseBody);
            var dates = holidays?
                .Where(holiday => holiday.nationalHoliday)
                .Select(holiday =>
                {
                    var dateParts = holiday.date.Split('-').Select(int.Parse).ToArray();
                    return new DateTime(dateParts[0], dateParts[1], dateParts[2]);
                })
                .ToList() ?? new List<DateTime>();
            
            return dates;
        }

        private string SendGetRequest(string url) {
            var response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        
    }
}