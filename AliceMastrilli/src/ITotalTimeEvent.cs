using ElisaBarberini;
using NodaTime;


namespace AliceMastrilli.src
{
    internal interface ITotalTimeEvent
    {
        Period ComputePeriod(IEvent evento);
    }
}
