namespace MarcoFrattarola.finance
{

	/// Interface that models a transaction's category.
	/// Each category has a name.
	public interface ICategory
	{

		/// <returns> the category's name </returns>
		string Name {get;}
	}

}