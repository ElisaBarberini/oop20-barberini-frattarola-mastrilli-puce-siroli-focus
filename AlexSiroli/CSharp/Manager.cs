using System.Collections.Generic;

namespace AlexSiroli
{

	/// Immutable implementation of a manager.
	/// @param <X> type of elements it manages. </param>
	public class Manager<X> : IManager<X>
	{

		private readonly ISet<X> elements;

        public Manager()
        {
            this.elements = new HashSet<X>();
        }

		/// {@inheritDoc}
		public void Add(X elem)
		{
			this.elements.Add(elem);
		}

		/// {@inheritDoc}
		public void Remove(X elem)
		{
			this.elements.Remove(elem);
		}

		public ISet<X> Elements
		{
			get
			{
				return this.elements;
			}
		}
    }
}
