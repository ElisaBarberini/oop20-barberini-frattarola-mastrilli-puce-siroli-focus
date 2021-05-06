using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
    class HotKeyImpl : HotKey
    {
        private string name;
        private HotKeyType hotKeyType;

        public HotKeyImpl(string name, HotKeyType hotKeyType)
        {
            this.name = name;
            this.hotKeyType = hotKeyType;
        }

        public override bool Equals(object obj)
        {
            return obj is HotKeyImpl impl &&
                   name == impl.name &&
                   EqualityComparer<HotKeyType>.Default.Equals(hotKeyType, impl.hotKeyType);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, hotKeyType);
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public void SetType(HotKeyType value)
        {
            this.hotKeyType = value;
        }

        HotKeyType HotKey.GetHotKeyType()
        {
            return this.hotKeyType;
        }
    }
}
