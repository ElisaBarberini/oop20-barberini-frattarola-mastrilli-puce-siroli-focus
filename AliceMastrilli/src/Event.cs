using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    interface IEvent
    {
        /// This method is used to know both the end date and the end time of an event.
        /// <returns> LocalDateTime.
        LocalDateTime GetEnd();

        /// This method is used for get the event end day.
        ///  <returns> a LocalDate.
        LocalDate GetEndDate();

        /// This method is used for get the event end hour.
        ///  <returns> a LocalDateTime.
        LocalTime GetEndHour();

        /// This method is used for get the event name.
        /// <returns> a String.
        string GetName();


        /// This method is used to know both the start date and the start time of an event.
        /// <returns> LocalDateTime.
        LocalDateTime GetStart();

        /// This method is used for get the event start day.
        ///  <returns> a LocalDate. 
        LocalDate GetStartDate();

        /// This method is used for get the event start hour.
        /// <returns> a LocalDateTime.
        LocalTime GetStartHour();

        /// This method is used to get the start time of the event. 
        /// <returns> String that represent the start time of the event. 
        string GetStartTime();

        /// This method is used to get the start day of the event.
        /// <returns> String that represent the start day of the event.
        string GetStartDay();
    }
}
