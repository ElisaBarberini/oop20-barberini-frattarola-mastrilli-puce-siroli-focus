using AliceMastrilli.src;
using NodaTime;
using Xunit;

namespace AliceMastrilli
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
            Assert.Equal(2, dailyMoodManager1.GetMoodByDate(localDate));
        }
    }
}
