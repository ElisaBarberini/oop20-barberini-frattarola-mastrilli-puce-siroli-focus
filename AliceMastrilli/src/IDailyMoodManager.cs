using NodaTime;

namespace AliceMastrilli.src
{
    internal interface IDailyMoodManager
    {
        void AddDailyMood(DailyMood mood);

        void ModifyDailyMood(DailyMood mood);

        void DeleteDailyMood(DailyMood mood);

        int GetMoodByDate(LocalDate date);
    }
}

