using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ElisaBarberini
{
    public class RelationshipTest
    {
        private readonly IRelationshipManager manager = new RelationshipManagerImpl();
        private readonly string r1 = "r1";
        private readonly string r2 = "r2";
        private readonly string r3 = "r3";

        [Fact]
        public void Test1()
        {
            manager.add(r1);
            Assert.Contains(r1, manager.GetAll());
            manager.add(r2);
            Assert.Contains(r2, manager.GetAll());
            manager.add(r3);
            Assert.Contains(r3, manager.GetAll());

            manager.remove(r1);
            manager.remove(r2);
            manager.remove(r3);
            Assert.Empty(manager.GetAll());
        }
    }
}
