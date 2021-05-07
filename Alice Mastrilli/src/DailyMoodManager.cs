using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oop
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
            if (!this.set.Contains(mood))
            {
                this.set.Add(mood);
            }
        }

        public void DeleteDailyMood(DailyMood mood)
        {
            if (this.set.Contains(mood)) {
                this.set.Remove(mood);
            }
        }

        public int getMoodByDate(LocalDate date)
        {
            ISet<DailyMood> mood = this.set.Where(x => x.GetDate == date).ToHashSet();
            if (mood.Count > 0) {
                return mood.FirstOrDefault().Value;
            }
            return -1;
        }

        public void ModifyDailyMood(DailyMood mood)
        {
            ISet<DailyMood> moodToUpdate = this.set.Where(x => x.GetDate.Equals(mood.
                GetDate)).ToHashSet();
            if (moodToUpdate.Count > 0)
            {
                moodToUpdate.First().Value = mood.Value;
            }
        }
    }
}
