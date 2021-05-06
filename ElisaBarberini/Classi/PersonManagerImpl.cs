using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    class PersonManagerImpl : IPersonManager
    {
        private IList<Person> listOfPersons;

        public PersonManagerImpl()
        {
            this.listOfPersons = new List<Person>();
        }

        public void addPerson(Person person)
        {
            this.listOfPersons.Add(person);
        }

        public void removePerson(Person person)
        {
            this.listOfPersons.Remove(person);
        }

        public IList<Person> GetPersons()
        {
            return this.listOfPersons;
        }
    }
}
