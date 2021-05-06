using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ElisaBarberini.Test
{
    public class PersonTest
    {
        private readonly Person p1 = new PersonImpl("n1", "r1");
        private readonly Person p2 = new PersonImpl("n2", "r2");
        private readonly Person p3 = new PersonImpl("n3", "r3");
        private readonly IPersonManager manager = new PersonManagerImpl();

        [Fact]
        public void TestPerson()
        {
            Assert.Equal("r1", p1.GetRelationships());
            Assert.Equal("n1", p1.GetName());
            Assert.Equal("r2", p2.GetRelationships());
            Assert.Equal("n2", p2.GetName());

            Assert.False(p1.Equals(p2));
            Assert.False(p2.Equals(p3));
        }

        [Fact]
        public void TestManagerPerson()
        {
            manager.addPerson(p1);
            Assert.Contains(p1, manager.GetPersons());
            manager.addPerson(p2);
            Assert.Contains(p2, manager.GetPersons());
            manager.addPerson(p3);
            Assert.Contains(p3, manager.GetPersons());
            manager.removePerson(p1);
            manager.removePerson(p2);
            manager.removePerson(p3);
            Assert.Empty(manager.GetPersons());

        }
    }
}
