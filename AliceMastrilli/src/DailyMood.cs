using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    class DailyMood
    {

        public DailyMood(int dailyValue, LocalDate date)
        {
            Value = dailyValue;
            GetDate = date;
        }
        public int Value { get; set; }
        public LocalDate GetDate { get; }
    }
}
