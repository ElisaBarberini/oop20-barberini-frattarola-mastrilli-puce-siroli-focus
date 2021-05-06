using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    class EventImpl : IEvent
    {
        private string name;
        private LocalDateTime startDate;
        private readonly LocalDateTime endDate;
        private string startDay;
        private string startTime;
        private readonly IList<Person> persons;

        public EventImpl(string name, LocalDateTime startDate, LocalDateTime endDate, IList<Person> persons)
        {
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
            this.persons = persons;
            this.startDay = this.setDay(this.startDate).ToString();
            this.startTime = this.setTime(this.startDate).ToString();
        }

        private LocalTime setTime(LocalDateTime dateTime)
        {
            LocalTime time = new LocalTime(dateTime.Hour, dateTime.Minute);
            return time;
        }

        private LocalDate setDay(LocalDateTime dateTime)
        {
            LocalDate date = new LocalDate(dateTime.Era, dateTime.YearOfEra, dateTime.Month, dateTime.Day);
            return date;
        }

        public EventImpl(string name, LocalDateTime startDate, LocalDateTime endDate)
        {
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
            this.persons = new List<Person>();
        }
        public LocalDateTime GetEnd()
        {
            return this.endDate;
        }

        public LocalDate GetEndDate()
        {
            return this.setDay(this.endDate);
        }

        public LocalTime GetEndHour()
        {
            return this.setTime(this.endDate);
        }

        public string GetName()
        {
            return this.name;
        }

        public IList<Person> GetPersons()
        {
            return this.persons;
        }

        public LocalDateTime GetStart()
        {
            return this.startDate;
        }

        public LocalDate GetStartDate()
        {
            return this.setDay(this.startDate);
        }

        public string GetStartDay()
        {
            return this.startDay;
        }

        public LocalTime GetStartHour()
        {
            return this.setTime(this.startDate);
        }

        public string GetStartTime()
        {
            return this.startTime;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public void SetStartDay(string value)
        {
            this.name = value;
        }

        public void SetStartTime(string value)
        {
            this.startTime = value;
        }
    }
}
