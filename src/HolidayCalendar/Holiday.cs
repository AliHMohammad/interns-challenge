

namespace HolidayCalendar {

    public class Holiday {
        public string date { get; set; }
        public string name { get; set; }
        public bool nationalHoliday { get; set; }

        public Holiday(string date, string name, bool nationalHoliday) {
            this.date = date;
            this.name = name;
            this.nationalHoliday = nationalHoliday;
        }
    }
}