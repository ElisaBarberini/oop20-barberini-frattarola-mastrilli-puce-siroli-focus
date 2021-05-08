using System.Collections.Generic;

namespace MarcoFrattarola.finance
{

	/// Immutable implementation of a manager.
	/// <typeparam name="X"> type of elements it manages. </typeparam>
	public class Manager<X> : IManager<X>
	{

		private readonly ISet<X> elements;

        public Manager()
        {
            this.elements = new HashSet<X>();
        }

		/// <inheritdoc/>
		public void Add(X elem)
		{
			this.elements.Add(elem);
		}

		/// <inheritdoc/>
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
