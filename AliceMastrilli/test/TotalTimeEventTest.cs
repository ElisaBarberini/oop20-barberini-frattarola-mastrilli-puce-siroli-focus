using AliceMastrilli.src;
using ElisaBarberini;
using NodaTime;
using Xunit;
namespace AliceMastrilli
{
    public class TotalTimeEventTest
    {
        [Fact]
        public void Test1()
        {
            ITotalTimeEvent computer = new TotalTimeEvent();
            IEvent first = new EventImpl("test1", new LocalDateTime(2021, 9, 26, 9,
                    30), new LocalDateTime(2021, 9, 26, 10, 30));
            IEvent second = new EventImpl("test2", new LocalDateTime(2021, 9, 25, 8,
                    30), new LocalDateTime(2021, 9, 25, 10, 00));
            Assert.Equal(1, computer.ComputePeriod(first).Hours);
            Assert.Equal(0, computer.ComputePeriod(first).Minutes);
            Assert.Equal(1, computer.ComputePeriod(second).Hours);
            Assert.Equal(30, computer.ComputePeriod(second).Minutes);
        }
    }
}