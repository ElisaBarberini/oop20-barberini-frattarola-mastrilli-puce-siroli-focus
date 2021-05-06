using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ElisaBarberini
{
    public class EventTest
    {
        private IEvent first = new EventImpl("Shopping", new LocalDateTime(2021, 5, 4, 15, 00), new LocalDateTime(2021, 5, 4, 17, 00));

        [Fact]
        public void TestEvent()
        {
            Assert.Equal("Shopping", first.GetName());
            Assert.Empty(first.GetPersons());
            Assert.Equal(new LocalDate(2021, 5, 4), first.GetStartDate());
            Assert.Equal(new LocalTime(15, 00), first.GetStartHour());
        }
    }
}
