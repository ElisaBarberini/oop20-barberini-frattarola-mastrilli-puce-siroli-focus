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

        public override bool Equals(DailyMood obj)
        {
            return base.Equals(obj.GetDate);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
