using NodaTime;

namespace oop
{
    interface IDailyMoodManager
    {
        void AddDailyMood(DailyMood mood);

        void ModifyDailyMood(DailyMood mood);

        void DeleteDailyMood(DailyMood mood);

        int getMoodByDate(LocalDate date);
    }
}

