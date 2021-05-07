using NodaTime;
using oop;
using System;
using Xunit;

namespace Alice_Mastrilli
{
    public class DailyMoodTest
    {
        [Fact]
        public void Test1()
        {
            DailyMoodManager dailyMoodManager1 = new DailyMoodManager();
            LocalDate localDate = new LocalDate(20, 10, 10);
            LocalDate date1 = new LocalDate(20, 10, 11);
            DailyMood mood1 = new DailyMood(2, localDate);
            DailyMood mood2 = new DailyMood(3, localDate);
            DailyMood mood3 = new DailyMood(4, date1);
            dailyMoodManager1.AddDailyMood(mood1);
            Assert.Equal(2, dailyMoodManager1.getMoodByDate(localDate));
            dailyMoodManager1.ModifyDailyMood(mood2);
            Assert.Equal(3, dailyMoodManager1.getMoodByDate(localDate));

        }
    }
}