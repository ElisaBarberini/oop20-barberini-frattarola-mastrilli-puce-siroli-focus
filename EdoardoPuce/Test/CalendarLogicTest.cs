using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EdoardoPuce.src;
namespace EdoardoPuce.Test
{
    [TestClass()]
    public class CalendarLogicTest
    {

        private ICalendarLogic logic;
        private DateTime today;

        public CalendarLogicTest() {
            this.logic = new CalendarLogic();
            this.today = DateTime.Now;
        }

        [TestMethod()]
        public void TestWeek()
        {
            this.logic.GenerateWeek(); //genero la settimana corrente

            //controllo che mi abbia generato la settimana corrente
            Assert.AreEqual(this.logic.GetWeek()[0].GetNumber, new Day(today.AddDays(-((int) today.DayOfWeek - 1))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[1].GetNumber, new Day(today.AddDays(-((int) today.DayOfWeek - 2))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[2].GetNumber, new Day(today.AddDays(-((int) today.DayOfWeek - 3))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[3].GetNumber, new Day(today.AddDays(-((int) today.DayOfWeek - 4))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[4].GetNumber, new Day(today.AddDays(-((int) today.DayOfWeek - 5))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[5].GetNumber, new Day(today.AddDays(-((int) today.DayOfWeek - 6))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[6].GetNumber, new Day(today.AddDays(-((int) today.DayOfWeek - 7))).GetNumber);

            //cambio settimana, genero quella precedente
            this.logic.ChangeWeek(true);

            // controllo che abbia generato la settimana precedente
            Assert.AreEqual(this.logic.GetWeek()[0].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek + 6))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[1].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek + 5))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[2].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek + 4))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[3].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek + 3))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[4].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek + 2))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[5].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek + 1))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[6].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek))).GetNumber);

            //controllo che il giorno corrente non ci sia nella settimana precedente
            Assert.IsFalse(this.logic.GetWeek().Contains(this.logic.GetDay(this.today)));

            //torno alla settimana attuale
            this.logic.ChangeWeek(false);

            //controllo che abbia cambiato la settimana       
            Assert.AreEqual(this.logic.GetWeek()[0].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek - 1))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[1].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek - 2))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[2].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek - 3))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[3].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek - 4))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[4].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek - 5))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[5].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek - 6))).GetNumber);
            Assert.AreEqual(this.logic.GetWeek()[6].GetNumber, new Day(today.AddDays(-((int)today.DayOfWeek - 7))).GetNumber);

        }

        [TestMethod()]
        public void TestMonth()
        {
            this.logic.GenerateMonth(); //genero il mese corrente

            //controllo che mi abbia generato il mese corrente
            for (int i = 0; i < DateTime.DaysInMonth(this.today.Year, this.today.Month); i++)
            {
                Assert.AreEqual(this.logic.GetMonth()[i].GetNumber, new Day(this.today.AddDays(-(this.today.Day - (i + 1)))).GetNumber);
            }

            //cambio mese, genero quello precedente
            this.logic.ChangeMonth(true);

            //controllo che mi abbia generato il mese precedente
            for (int i = 0; i < DateTime.DaysInMonth(this.today.Year, this.today.AddMonths(-1).Month); i++)
            {
                Assert.AreEqual(this.logic.GetMonth()[i].GetNumber, new Day(this.today.AddDays(-(this.today.Day + DateTime.DaysInMonth(this.today.Year, this.today.AddMonths(-1).Month) - (1 + i)))).GetNumber);
            }
            
        }

        [TestMethod()]
        public void TestYear()
        {
            this.logic.GenerateYear(); //genero l'anno corrente
            int daysInYear = DateTime.IsLeapYear(this.today.Date.Year) ? 366 : 365;

            //controllo che mi abbia generato l'anno corrente
            for (int i = 0; i < daysInYear; i++)
            {
                Assert.AreEqual(this.logic.GetYear()[i].GetNumber, new Day(this.today.AddDays(-(this.today.DayOfYear - (i + 1)))).GetNumber);
            }

            //cambio anno, genero quello precedente
            this.logic.ChangeYear(true);
            daysInYear = DateTime.IsLeapYear(this.today.AddYears(-1).Date.Year) ? 366 : 365;

            //controllo che mi abbia generato l'anno precedente
            for (int i = 0; i < daysInYear; i++)
            {
                Assert.AreEqual(this.logic.GetYear()[i].GetNumber, new Day(this.today.AddDays(-(this.today.DayOfYear + daysInYear - (1 + i)))).GetNumber);
            }

        }
    }

}
