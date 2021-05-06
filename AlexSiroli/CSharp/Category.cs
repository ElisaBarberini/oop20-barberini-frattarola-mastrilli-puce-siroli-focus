using System;

namespace AlexSiroli
{

	/// Immutable implementation of a category.
	public class Category : ICategory
	{

		private readonly string name;

		public Category(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

        public override bool Equals(object obj)
        {
            return obj is Category impl &&
                   name == impl.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name);
        }

        public override sealed string ToString()
		{
			return "Name: " + this.name;
		}
	}

}