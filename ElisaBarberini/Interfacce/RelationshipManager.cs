using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    interface IRelationshipManager
    {
        /// This method is used to add a new degree of kinship. </summary>
		/// <param name="degree"> is the degree of kinship to add. </param>
		void add(string degree);

        /// This method is used to get all degrees of relationship saved. </summary>
        /// <returns> a set of string that represent all the saved degrees of relationship. </returns>
        IList<string> GetAll();

        /// This method is used to remove a degree of kinship from all the saved degrees of kinship. </summary>
        /// <param name="degree"> is the degree to remove. </param>
        void remove(string degree);
    }
}
