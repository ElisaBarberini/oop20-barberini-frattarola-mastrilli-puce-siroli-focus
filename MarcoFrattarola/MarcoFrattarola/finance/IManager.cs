using System.Collections.Generic;

namespace MarcoFrattarola.finance
{

	/// Interface that models a generic manager working on all elements.
	/// <typeparam name="X"> type of elements it manages. </typeparam>
	public interface IManager<X>
	{

		/// Saves the element.
		/// <param name="element"> that is saved </param>
		void Add(X element);

		/// Removes the element.
		/// <param name="element"> being deleted </param>
		void Remove(X element);

		/// <returns> the set of all elements. </returns>
		ISet<X> Elements {get;}
	}

}