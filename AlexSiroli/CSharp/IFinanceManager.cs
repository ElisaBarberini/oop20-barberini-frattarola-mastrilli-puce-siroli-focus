namespace AlexSiroli
{

	/// Interface that models a finance manager,
	/// coordinating the three managers of transactions, accounts and categories.
	public interface IFinanceManager
	{

		/// Saves the account.
		/// <param name="account"> that is added </param>
		void AddAccount(IAccount account);

		/// Delete the account and all its transactions.
		/// <param name="account"> that is removed </param>
		void RemoveAccount(IAccount account);

		/// Saves the category.
		/// <param name="category"> that is added </param>
		void AddCategory(ICategory category);

		/// Only deletes the category if there are no transactions in that category.
		/// <param name="category"> that is removed </param>
		void RemoveCategory(ICategory category);

		/// Saves the transaction.
		/// <param name="transaction"> that is added </param>
		void AddTransaction(ITransaction transaction);

		/// Delete transaction.
		/// <param name="transaction"> that is removed </param>
		void RemoveTransaction(ITransaction transaction);

		/// Returns the current amount of an account.
		/// <param name="account"> whose amount we want to know </param>
		/// <returns> account's current amount </returns>
		int GetAmount(IAccount account);

		/// <returns> account manager </returns>
		IManager<IAccount> AccountManager {get;}

		/// <returns> category manager </returns>
		IManager<ICategory> CategoryManager {get;}

		/// <returns> transaction manager </returns>
		IManager<ITransaction> TransactionManager {get;}
	}

}