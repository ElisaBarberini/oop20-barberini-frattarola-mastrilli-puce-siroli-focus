using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EdoardoPuce.src
{

    public class CalendarLogic : ICalendarLogic
    {

        //Classes
        private Day day;

        //Variables
        private DateTime today;
        private DateTime current;

        //List
        private List<Day> week;
        private List<Day> month;
        private List<Day> year;

        //Costants
        private const int DAYS_IN_WEEK = 7;

        /// <summary>
        /// Initialize the logic of the calendar. </summary>
        public CalendarLogic() 
        {
            this.today = DateTime.Now;
            this.current = this.today;
            this.week = new List<Day>();
            this.month = new List<Day>();
            this.year = new List<Day>();
        }

        public Day GetDay(DateTime day)
        {
            if (!this.week.Contains(new Day(day)))
            {
                if (!this.month.Contains(new Day(day)))
                {
                    if (!this.year.Contains(new Day(day)))
                    {
                        return this.GenerateDay(day);
                    }
                    return this.Filter(this.year, day);
                }
                return this.Filter(this.month, day);
            }
            return this.Filter(this.week, day);
        }

        /// <summary>
        /// Used for find an specific <seealso cref="Day"/> in a list. </summary>
        /// <param name="time"> : list with the days </param>
        /// <param name="day"> : <seealso cref="DateTime"/> that we are searching </param>
        /// <returns> <seealso cref="Day"/> </returns>
        private Day Filter(List<Day> time, DateTime day)
        {
            Day temp = this.GenerateDay(day);
            Day dayset = time.Find(e => e.Equals(temp));
            return dayset;
        }

        /// <summary>
        /// Used for build a day from a date. </summary>
        /// <param name="day"> : <seealso cref="LocalDate"/> of the day that we want to generate </param>
        /// <returns> Day : an generated <seealso cref="Day"/> </returns>
        private Day GenerateDay(DateTime day)
        {
            if (this.day == null)
            {
                this.day = new Day(this.today);
                return this.day;
            }
            this.day = new Day(day);
            return this.day;
        }

        public  List<Day> GetWeek() {
            if (!this.week.Any())
            {
                this.week = this.GenerateWeek();
            }
            return this.week;
        }

        public List<Day> GetMonth() {
            if (!this.month.Any())
            {
                this.month = this.GenerateMonth();
            }
            return this.month;
        }

        public List<Day> GetYear() {
            if (!this.year.Any())
            {
                this.year = this.GenerateYear();
            }
            return this.year;
        }

        /// <summary>
        /// Used for generate one of the Calendar List. </summary>
        /// <param name="numberOfDays"> : is the number of day of the list </param>
        /// <param name="startingDate"> : is the date of the day from it start to generate the calendar </param>
        /// <returns> List : a generated list of number number of <seealso cref="Day"/>. </returns>
        private List<Day> Generate(int numberOfDays, DateTime startingDate)
        {
            List<Day> time = new List<Day>();
            for (int i = 0; i < numberOfDays; i++)
            {
                time.Add(new Day(startingDate.AddDays(i)));
            }
            return time;
        }

        public List<Day> GenerateWeek() {
            this.week.Clear();
            for (int i = 0; i < DAYS_IN_WEEK; i++)
            {
                this.week.Add(new Day(this.current.AddDays(-((int) this.current.DayOfWeek - 1)).AddDays(i)));
            }
            return this.week;
        }

        public List<Day> GenerateMonth() {
            DateTime day = new DateTime(this.current.Year, this.current.Month, 1);
            this.month = this.Generate(DateTime.DaysInMonth(day.Year, day.Month), day);
            return this.month;
        }

        public List<Day> GenerateYear() {
            DateTime day = new DateTime(this.current.Year, 1, 1);
            this.year = this.Generate(DateTime.IsLeapYear(day.Date.Year) ? 366 : 365, day);
            return this.year;
        }



        public void ChangeWeek(bool change)
        {
            if (change)
            { //previous
                this.current = this.current.Date.AddDays(-DAYS_IN_WEEK);
            }
            else
            { //next
                this.current = this.current.AddDays(DAYS_IN_WEEK);
            }
            this.week = this.GenerateWeek();
        }

        public void ChangeMonth(bool change)
        {
            if (change)
            { //previous
                if (this.current.Month == 1)
                {
                    this.current = new DateTime(this.current.Year - 1, 12, 1);
                }
                else
                {
                    this.current = new DateTime(this.current.Year, this.current.Month - 1, 1);
                }
            }
            else
            { //next
                if (this.current.Month == 12)
                {
                    this.current = new DateTime(this.current.Year + 1, 1, 1);
                }
                else
                {
                    this.current = new DateTime(this.current.Year, this.current.Month + 1, 1);
                }
            }
            this.month = this.GenerateMonth();
        }

        public void ChangeYear(bool change)
        {
            if (change)
            { //previous
                this.current = new DateTime(this.current.Year - 1, this.current.Month, this.current.Day);
            }
            else
            { //next
                this.current = new DateTime(this.current.Year + 1, this.current.Month, this.current.Day);
            }
            this.year = this.GenerateYear();
        }





    }

}
