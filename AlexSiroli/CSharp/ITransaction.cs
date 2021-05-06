using NodaTime;

namespace AlexSiroli
{

	/// Interface that models a transaction.
	/// Each transaction has a description, the category to which it belongs,
	/// the date in which it is carried out, the account in which it is carried outand the amount.
	public interface ITransaction
	{
		/// <returns> transaction's description </returns>
		string Description {get;}

		/// <returns> transaction's category </returns>
		ICategory Category {get;}

		/// <returns> transaction's date </returns>
		LocalDateTime Date {get;}

		/// <returns> transaction's account </returns>
		IAccount Account {get;}

		/// <returns> transaction's amount </returns>
		int Amount {get;}
	}

}