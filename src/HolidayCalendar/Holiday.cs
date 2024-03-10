

namespace HolidayCalendar {

    public class HolidayDTO {
        public string date { get; set; }
        public string name { get; set; }
        public bool nationalHoliday { get; set; }

        public HolidayDTO(string date, string name, bool nationalHoliday) {
            this.date = date;
            this.name = name;
            this.nationalHoliday = nationalHoliday;
        }
    }
}