using System.Net.Http.Headers;


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
            var response = client.GetAsync($"{API_URL}/is-holiday?date={date}").Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return responseBody == "true";
        }
        
        public bool GetHolidays(string startDate, string endDate) {            
            var response = client.GetAsync($"{API_URL}/?startDate={startDate}&endDate={endDate}").Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return true;
        }
    }
}