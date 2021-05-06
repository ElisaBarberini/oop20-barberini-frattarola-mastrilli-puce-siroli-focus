using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini.Classi
{
    class HotKeyManagerImpl : HotKeyManager
    {
        private readonly IList<HotKey> hotKeyList;

        public HotKeyManagerImpl()
        {
            this.hotKeyList = new List<HotKey>();
        }

        public void add(HotKey hotKey)
        {
            this.hotKeyList.Add(hotKey);
        }

        public IList<HotKey> GetAll()
        {
            return this.hotKeyList;
        }

        public HotKeyType getCategory(HotKey hotKey)
        {
            return hotKey.GetHotKeyType();
        }

        public void remove(HotKey hotKey)
        {
            this.hotKeyList.Remove(hotKey);
        }
    }
}
