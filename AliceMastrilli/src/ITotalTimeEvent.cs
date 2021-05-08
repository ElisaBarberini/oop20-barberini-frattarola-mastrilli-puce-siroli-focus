using NodaTime;


namespace AliceMastrilli.src
{
    internal interface ITotalTimeEvent
    {
        Period ComputePeriod(string labelName);
    }
}
