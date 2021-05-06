using System;
using System.Collections.Generic;
using System.Text;

namespace EdoardoPuce
{
    class Month
    {
        private Dictionary<int, String> month = new Dictionary<int, String>();

        public Month()
        {
         this.month.Add(1, "Gennaio");
         this.month.Add(2, "Febbraio");
         this.month.Add(3, "Marzo");
         this.month.Add(4, "Aprile");
         this.month.Add(5, "Maggio");
         this.month.Add(6, "Giugno");
         this.month.Add(7, "Luglio");
         this.month.Add(8, "Agosto");
         this.month.Add(9, "Settembre");
         this.month.Add(10, "Ottobre");
         this.month.Add(11, "Novembre");
         this.month.Add(12, "Dicembre");
        }
        public String GetName(int month)
        {
           return this.month[month];
        }
    }
}
