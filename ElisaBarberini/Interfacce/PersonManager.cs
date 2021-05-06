using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    interface IPersonManager
    {
        /// This method is used to add new Person to the database. </summary>
		/// <param name="person"> is the person to add. </param>
		void addPerson(Person person);

        /// This method is used to get all the saved persons. </summary>
        /// <returns> a list of persons. </returns>
        IList<Person> GetPersons();

        /// This method is used to remove a person from the database if it's already saved. </summary>
        /// <param name="person"> is the person to remove from the database. </param>
        void removePerson(Person person);
    }
}
