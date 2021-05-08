using ElisaBarberini;
using NodaTime;

namespace AliceMastrilli.src
{
    class TotalTimeEvent : ITotalTimeEvent
    {
        public Period ComputePeriod(IEvent evento) => Period.Between(evento.GetStart(), evento.GetEnd());
    }
}
