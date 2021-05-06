using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdoardoPuce.src
{
	/// <summary>
	/// The Days interface models the object day.
	/// It defines the standard methods for manage the days of Calendar
	/// </summary>
	public interface IDay
    {
		/// <summary>
		/// Can be used to get the number of month of the day. </summary>
		/// <returns> the number of the day of the month </returns>
		int GetNumber { get; }

		/// <summary>
		/// Can be used to get the day of the week. </summary>
		/// <returns> the day of the week 
		///  </returns>
		int GetDayOfTheWeek { get; }


		/// <summary>
		/// Can be used to get the name of the day. </summary>
		/// <returns> the name of the day  </returns>
		string GetName { get; }

		/// <summary>
		/// Can be used to get the Month of the day. </summary>
		/// <returns> the name of the Month  </returns>
		string GetMonth { get; }

		/// <summary>
		/// Can be used to get the number of the Month of the day. </summary>
		/// <returns> the number of the Month  </returns>
		int GetMonthNumber { get; }

		/// <summary>
		/// Can be used to get the Year of the day. </summary>
		/// <returns> the number of the Year  </returns>
		int GetYear { get; }

		/// <summary>
		/// Can be used to get the list of the events of the day. </summary>
		/// <returns> List : the list of event of the day </returns>
		List<String> GetEvents { get; }


		/// <summary>
		/// Can be used to get the list of the daily events of the day. </summary>
		/// <returns> List : the list of the daily event of the day </returns>
		List<String> GetDailyEvents { get; }
	}
}
