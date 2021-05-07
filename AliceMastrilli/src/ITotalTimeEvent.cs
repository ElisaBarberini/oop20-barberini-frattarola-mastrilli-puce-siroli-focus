using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    interface ITotalTimeEvent
    {
        Period ComputePeriod(String labelName);
    }
}
