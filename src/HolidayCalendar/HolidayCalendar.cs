
namespace HolidayCalendar;
public class HolidayCalendar : IHolidayCalendar {
	
	private readonly APIService apiService = new();
	
	public bool IsHoliday(DateTime date) {
		var stringDate = date.ToString("yyyy-MM-dd");
		
		return apiService.IsHoliday(stringDate);
  	}

	public ICollection<DateTime> GetHolidays(DateTime startDate, DateTime endDate) {
		// TODO - replace the below exception with your own implementation
		var stringStartDate = startDate.ToString("yyyy-MM-dd");
		var stringEndDate = endDate.ToString("yyyy-MM-dd");

		return null;
		//return apiService.GetHolidays(stringStartDate, stringEndDate);
	}

	

    
  
  
}
