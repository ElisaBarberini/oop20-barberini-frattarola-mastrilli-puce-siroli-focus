using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    interface HotKey
    {
        string GetName();
        void SetName(string value);

        /// This method is used for getting the type of the HotKey.
        /// <returns> a member of the HotKeyType enumeration.
        HotKeyType GetHotKeyType();

        /// This method is used for getting the type of the HotKey.
        /// <returns> a member of the HotKeyType enumeration.
        void SetType(HotKeyType value);
    }
}
