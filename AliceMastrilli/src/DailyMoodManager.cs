using NodaTime;
using System.Collections.Generic;
using System.Linq;

namespace AliceMastrilli.src
{
    class DailyMoodManager : IDailyMoodManager
    {
        private readonly ISet<DailyMood> set;
        public DailyMoodManager()
        {
            set = new HashSet<DailyMood>();
        }

        public void AddDailyMood(DailyMood mood)
        {
            if (!set.Contains(mood))
            {
                set.Add(mood);
            }
        }

        public void DeleteDailyMood(DailyMood mood)
        {
            if (set.Contains(mood))
            {
                set.Remove(mood);
            }
        }

        public int GetMoodByDate(LocalDate date)
        {
            ISet<DailyMood> mood = set.Where(x => x.Date == date).ToHashSet();
            return mood.Count <= 0 ? -1 : mood.FirstOrDefault().Value;
        }

        public void ModifyDailyMood(DailyMood mood)
        {
            ISet<DailyMood> moodToUpdate = set.Where(x => x.Date.Equals(mood.
                Date)).ToHashSet();
            if (moodToUpdate.Count > 0)
            {
                moodToUpdate.First().Value = mood.Value;
            }
        }
    }
}
