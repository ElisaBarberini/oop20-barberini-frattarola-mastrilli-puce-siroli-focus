using NodaTime;
using System;

namespace AliceMastrilli.src
{
    class DailyMood
    {
        public DailyMood(int dailyValue, LocalDate date)
        {
            Value = dailyValue;
            Date = date;
        }
        public int Value { get; set; }
        public LocalDate Date { get; }

        public override bool Equals(object obj)
        {
            return obj is DailyMood mood &&
                   Date.Equals(mood.Date);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Date);
        }
    }
}