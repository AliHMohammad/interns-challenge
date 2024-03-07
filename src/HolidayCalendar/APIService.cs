using System.Net.Http.Headers;
using System.Text.Json;



namespace HolidayCalendar {

    class APIService {

        private readonly string API_URL = "https://api.sallinggroup.com/v1/holidays";
        private readonly string BEARER_TOKEN = "6829b007-0619-4f05-8949-eaf8842b8ffb";
        private HttpClient client;

        public APIService() {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BEARER_TOKEN);
        }

        public bool IsHoliday(string date) {            
            var responseTask = client.GetAsync($"{API_URL}/is-holiday?date={date}");
            responseTask.Wait();

            var response = responseTask.Result;
            
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return responseBody == "true";
        }
        
        public List<DateTime> GetHolidays(string startDate, string endDate) {            
            var responseTask = client.GetAsync($"{API_URL}/?startDate={startDate}&endDate={endDate}");
            responseTask.Wait();

            var response = responseTask.Result;
            
            var responseBodyTask = response.Content.ReadAsStringAsync();
            responseBodyTask.Wait();

            var responseBody = responseBodyTask.Result;
            
            var holidays = JsonSerializer.Deserialize<List<Holiday>>(responseBody);
            var dates = new List<DateTime>();
            
            if (holidays?.Count > 0) {
                foreach (var holiday in holidays) {
                    if (!holiday.nationalHoliday) continue;
                    var dateParts = holiday.date.Split('-').Select(int.Parse).ToArray();
                    dates.Add(new DateTime(dateParts[0], dateParts[1], dateParts[2]));
                }
            } 
            
            return dates;
        }
    }
}