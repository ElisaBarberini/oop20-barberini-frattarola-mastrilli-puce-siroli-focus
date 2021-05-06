using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    interface HotKeyManager
    {
        /// This method is used to add an hot keys. </summary>
		/// <param name="hotKey"> is the hot key that must be added. </param>
		void add(HotKey hotKey);

        /// This method is used to get the set of all the hot keys(of all categories). </summary>
        /// <returns> a list of hot keys. </returns>
        IList<HotKey> GetAll();

        /// This method is used to get the category of a specific hot key. </summary>
        /// <param name="hotKey"> is the hot key whose category you want to know. </param>
        /// <returns> a member of the HotKeyType enumeration. </returns>
        HotKeyType getCategory(HotKey hotKey);

        /// is used to remove a specific hot key from the collection containing all hot keys. </summary>
        /// <param name="hotKey"> is the hot key that must be remove. </param>
        void remove(HotKey hotKey);
    }
}
