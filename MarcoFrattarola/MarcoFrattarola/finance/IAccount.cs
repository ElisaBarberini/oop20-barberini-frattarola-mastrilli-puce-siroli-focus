namespace MarcoFrattarola.finance
{

	/// Interface that models an account.
	/// Each account has a name and its initial amount.
	public interface IAccount
	{

        /// <returns> the account's name </returns>
        string Name {get;}

		/// <returns> the account's amount </returns>
		int InitialAmount {get;}
	}

}