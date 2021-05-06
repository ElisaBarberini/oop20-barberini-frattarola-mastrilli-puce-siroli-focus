using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    interface IEventExtension
    {
        /// This method is used to set the event name.
        /// <param name="newValue"> is the new name of the event.
        void SetName(string value);

        /// This method is used to set the start day of the event.
        /// <param name="localDate"> is the new start date. 
        void SetStartDay(string value);

        /// This method is used to set the start time of the event.
        /// <param name="newValue"> is the new start time.
        void SetStartTime(string value);
    }
}
