using System;
using System.Collections.Generic;
using System.Globalization;

namespace EdoardoPuce.src
{
    public class Day : IDay
    {

        //Variables
        private DateTime date;

        //Lists
        private List<String> events;
        private List<String> dailyEvents;

        //Classes
        private WeekDays weekDays;
        private Month month;

        /// <summary>
        /// Initialize the Day. </summary>
        /// <param name="date"> : <seealso cref="DateTime"/>} of the day </param>
        public Day(DateTime date)
        {
            this.date = date;
            this.weekDays = new WeekDays();
            this.month = new Month();
            this.events = new List<String>();
            this.dailyEvents = new List<String>();
            this.Events();
        }

        /// <summary>
        ///  Used for fill the events and dailyEvent 
        ///  list for test the class. </summary>
        private void Events() 
        {
            this.events.Add("Universita");
            this.events.Add("Dentista");
            this.events.Add("Spesa");
            this.dailyEvents.Add("Palestra");
        }

        public int GetNumber => this.date.Day;

        public int GetDayOfTheWeek => (int) this.date.DayOfWeek;

        public string GetName => this.weekDays.GetName((int)this.date.DayOfWeek);

        public string GetMonth => this.month.GetName(this.date.Month);

        public int GetMonthNumber => this.date.Month;

        public int GetYear => this.date.Year;

        public List<string> GetEvents => this.events;

        public List<string> GetDailyEvents => this.dailyEvents;


    }
}
