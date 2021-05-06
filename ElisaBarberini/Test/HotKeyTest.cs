using ElisaBarberini.Classi;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ElisaBarberini
{
    public class HotKeyTest
    {
        private readonly HotKeyType type1 = HotKeyType.COUNTER;
        private readonly HotKeyType type2 = HotKeyType.ACTIVITY;
        private readonly HotKeyType type3 = HotKeyType.EVENT;

        private readonly HotKey first = new HotKeyImpl("Attività", HotKeyType.ACTIVITY);
        private readonly HotKey second = new HotKeyImpl("Contatore", HotKeyType.COUNTER);
        private readonly HotKey third = new HotKeyImpl("Evento", HotKeyType.EVENT);

        private readonly HotKeyManager manager = new HotKeyManagerImpl();

        [Fact]
        public void TestType()
        {
            Assert.Equal("COUNTER", type1.GetName());
            Assert.Equal("ACTIVITY", type2.GetName());
            Assert.Equal("EVENT", type3.GetName());
        }

        [Fact]
        public void TestHotKey()
        {
            Assert.False(first.Equals(second));
            Assert.False(second.Equals(third));
        }

        [Fact]
        public void TestManager()
        {
            manager.add(first);
            Assert.Contains(first, manager.GetAll());
            manager.add(second);
            Assert.Contains(second, manager.GetAll());
            manager.add(third);
            Assert.Contains(third, manager.GetAll());

            manager.remove(first);
            manager.remove(second);
            manager.remove(third);
            Assert.Empty(manager.GetAll());
        }
    }
}
