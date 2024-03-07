
namespace HolidayCalendar;
public class HolidayCalendar : IHolidayCalendar {
	
	private readonly ApiService apiService = new();
	
	public bool IsHoliday(DateTime date) {
		var stringDate = date.ToString("yyyy-MM-dd");
		return apiService.IsHoliday(stringDate);
  	}

	public ICollection<DateTime> GetHolidays(DateTime startDate, DateTime endDate) {
		var stringStartDate = startDate.ToString("yyyy-MM-dd");
		var stringEndDate = endDate.ToString("yyyy-MM-dd");
		return apiService.GetHolidays(stringStartDate, stringEndDate);
	}
}