using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    class RelationshipManagerImpl : IRelationshipManager
    {
        IList<String> listOfRelationships;

        public RelationshipManagerImpl()
        {
            this.listOfRelationships = new List<String>();
        }

        public void add(string degree)
        {
            this.listOfRelationships.Add(degree);
        }

        public IList<string> GetAll()
        {
            return this.listOfRelationships;
        }

        public void remove(string degree)
        {
            this.listOfRelationships.Remove(degree);
        }
    }
}
