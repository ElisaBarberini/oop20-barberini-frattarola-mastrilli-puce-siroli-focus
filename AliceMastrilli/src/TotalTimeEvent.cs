namespace AliceMastrilli.src
{
    class TotalTimeEvent
    {
          private readonly IEvent eventManager;
            public TotalTimeEvent(EventManager eventManager)
            {
                this.eventManager = eventManager;
            }

            public Period ComputePeriod(string labelName)
            {
                return this.eventManager.findByName(labelName).stream().map(s-> new Period(s.getStart().toDateTime(), s.getEnd().
                    toDateTime())).reduce(Period::plus);
            }
        }
     */   
    }
}
