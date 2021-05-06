using System;
using System.Collections.Generic;
using System.Text;

namespace ElisaBarberini
{
	public sealed class HotKeyType
    {
		public static readonly HotKeyType EVENT = new HotKeyType("EVENT", "#eb34b4");
		/// <summary>
		/// The activity hot key is represented from the purple color, the Italian translation of its category and has as identification number the number two.
		/// </summary>
		public static readonly HotKeyType ACTIVITY = new HotKeyType("ACTIVITY", "#dcc5f0");
		/// <summary>
		/// The counter hot key is represented from the blue color, the Italian translation of its category and has as identification number the number three.
		/// </summary>
		public static readonly HotKeyType COUNTER = new HotKeyType("COUNTER", "#42f5d7");

		private readonly string name;
		private readonly string color;

		public HotKeyType(string name, string color)
		{
			this.name = name;
			this.color = color;
		}

		public string GetColor()
		{
			return this.color;
		}

		public string GetName()
		{
			return this.name;
		}
	}
}
