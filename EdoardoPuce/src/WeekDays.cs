using System;
using System.Collections.Generic;
using System.Text;

namespace EdoardoPuce
{
    class WeekDays
    {
        private Dictionary<int, String> week = new Dictionary<int, String>();

        public WeekDays() 
        {
            this.week.Add(1, "Lunedi");
            this.week.Add(2, "Martedi");
            this.week.Add(3, "Mercoledi");
            this.week.Add(4, "Giovedi");
            this.week.Add(5, "Venerdi");
            this.week.Add(6, "Sabato");
            this.week.Add(0, "Domenica");
        }
        public String GetName(int day)
        {
            return this.week[day];
        }
    }

}
