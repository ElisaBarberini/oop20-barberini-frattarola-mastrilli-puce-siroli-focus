using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    class PersonImpl : Person
    {
        private string name;
        private string relationships;

        /// This is the class constructor. </summary>
        /// <param name="name"> is the name of the person to be created. </param>
        /// <param name="degree"> it is the degree of kinship of the person to be created. </param>

        public PersonImpl(string name, string degree)
        {
            this.name = name;
            this.relationships = degree;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, relationships);
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetRelationships()
        {
            return this.relationships;
        }

        public void SetName(string value)
        {
            this.relationships = value;
        }

        public void SetRelationships(string value)
        {
            this.name = value;
        }

        public sealed override string ToString()
        {
            return this.name + " " + this.relationships;
        }
    }
}
