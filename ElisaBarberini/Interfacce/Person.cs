using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    interface Person
    {
        ///  This method is used for get the degree of kinship of the person. </summary>
        ///  <returns> a String. </returns>
        string GetRelationships();

        ///  This method is used for get the degree of kinship of the person. </summary>
        ///  <returns> a String. </returns>
        void SetRelationships(string value);

        ///  This method is used for get the name of the person. </summary>
        ///  <returns> a String. </returns>
        string GetName();

        ///  This method is used for get the name of the person. </summary>
        ///  <returns> a String. </returns>
        void SetName(string value);

        /// This method is used to get a string that contains the name and the degree of kinship of the person. </summary>
        /// <returns> String that represent the name and the degree of kinship of the person. </returns>
        string ToString();
    }
}
