using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdoardoPuce.src
{
	/// <summary>
	/// The interface models the Calendar Logic.
	/// It defines the standard methods for manage the Calendar List
	/// that are Month, Week and Year
	/// </summary>
	interface ICalendarLogic
    {
		/// <summary>
		/// Used for get an Day from a list. </summary>
		/// <param name="day"> : <seealso cref="DateTime"/> of the day that we want to generate </param>
		/// <returns>  Day : all the information about a day. </returns>
		Day GetDay(DateTime day);

		/// <summary>
		/// Used for get the week list. </summary>
		/// <returns> a list of 7 <seealso cref="Day"/> </returns>
		List<Day> GetWeek();

		/// <summary>
		/// Used for get the month list. </summary>
		/// <returns> a list of X <seealso cref="Day"/> </returns>
		List<Day> GetMonth();

		/// <summary>
		/// Used for get the year list. </summary>
		/// <returns> a list of 365 <seealso cref="Day"/> </returns>
		List<Day> GetYear();

		/// <summary>
		/// Generate a list of 7 day. </summary>
		/// <returns> Set of 7 generated days  </returns>
		List<Day> GenerateWeek();

		/// <summary>
		/// Generate a list of x <seealso cref="Day"/>. </summary>
		/// <returns> Set of x generated days  </returns>
		List<Day> GenerateMonth();

		/// <summary>
		/// Generate a list of 365 <seealso cref="Day"/>. </summary>
		/// <returns> Set of 365 generated days  </returns>
		List<Day> GenerateYear();

		/// <summary>
		/// Used for change week. </summary>
		/// <param name="change"> , if is true get the previous week, if is false the next one </param>
		void ChangeWeek(bool change);


		/// <summary>
		/// Used for change month. </summary>
		/// <param name="change"> , if is true get the previous month, if is false the next one </param>
		void ChangeMonth(bool change);


		/// <summary>
		/// Used for change year. </summary>
		/// <param name="change"> , if is true get the previous year, if is false the next one </param>
		void ChangeYear(bool change);

	}
}
