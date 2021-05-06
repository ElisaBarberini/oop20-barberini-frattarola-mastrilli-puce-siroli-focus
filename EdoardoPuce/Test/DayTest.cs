using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EdoardoPuce.src;

namespace EdoardoPuce.Test
{
    [TestClass()]
    public class DayTest
    {

        private IDay day;
        private IDay day2;
        private IDay day3;
        private DateTime date;
        private DateTime date2;
        private DateTime date3;
        private const int YEAR = 2021;

        public DayTest() 
        {
            this.date = new DateTime(YEAR, 3, 26);
            this.date2 = new DateTime(YEAR, 4, 10);
            this.date3 = new DateTime(YEAR, 2, 14);
            day = new Day(date);
            day2 = new Day(date2);
            day3 = new Day(date3);
        }

        [TestMethod()]
        public void TestDay()
        {
            //Test sulla creazione del giorno venerdi 26 marzo 2021 
            Assert.AreEqual(day.GetNumber, 26);
            Assert.AreEqual(day.GetMonth, "Marzo");
            Assert.AreEqual(day.GetYear, YEAR);

            //Test sulla creazione del giorno sabato 10 aprile 2021 
            Assert.AreEqual(day2.GetNumber, 10);
            Assert.AreEqual(day2.GetMonth, "Aprile");
            Assert.AreEqual(day2.GetName, "Sabato");
            Assert.AreEqual(day2.GetYear, YEAR);

            //Test sulla creazione del giorno domenica 14 febbraio 2021 
            Assert.AreEqual(day3.GetNumber, 14);
            Assert.AreEqual(day3.GetMonth, "Febbraio");
            Assert.AreEqual(day3.GetName, "Domenica");
            Assert.AreEqual(day3.GetYear, YEAR);
        }

        public void TestEvents()
        {
            //Controllo che siano presenti gli eventi
            Assert.AreEqual(day.GetEvents[0], "Universita");
            Assert.AreEqual(day.GetEvents[1], "Dentista");
            Assert.AreEqual(day.GetEvents[2], "Spesa");

            //Controllo che siano presenti gli eventi giornalieri
            Assert.AreEqual(day.GetDailyEvents[0], "Palestra");
        }

    }
}
