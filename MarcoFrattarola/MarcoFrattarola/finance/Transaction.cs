using System.Collections.Generic;
using NodaTime;

namespace MarcoFrattarola.finance
{

	/// Class that considers the characteristics of a single transaction.
	public class Transaction : ITransaction
	{
		private readonly LocalDateTime date;

		public Transaction(string description, ICategory category, LocalDateTime localDateTime, IAccount account, int amount)
		{
			this.Description = description;
			this.Category = category;
			this.date = localDateTime;
			this.Account = account;
			this.Amount = amount;
		}

		public string Description { get; }

		public ICategory Category { get; }

		public LocalDateTime Date => this.date;

		public IAccount Account { get; }

		public int Amount { get; }

		public override bool Equals(object obj)
        {
            return obj is Transaction transaction &&
                   Description == transaction.Description &&
                   EqualityComparer<ICategory>.Default.Equals(Category, transaction.Category) &&
                   date.Equals(transaction.date) &&
                   EqualityComparer<IAccount>.Default.Equals(Account, transaction.Account) &&
                   Amount == transaction.Amount;
        }

		protected bool Equals(Transaction other)
		{
			return date.Equals(other.date) && Description == other.Description && Equals(Category, other.Category) && Equals(Account, other.Account) && Amount == other.Amount;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = date.GetHashCode();
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Account != null ? Account.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Amount;
				return hashCode;
			}
		}


		public sealed override string ToString()
		{
			return "Description: " + this.Description + ", category: " + this.Category.Name
				+ ", date: " + this.date + ", account: " + this.Account.Name + ", amount: " + this.Amount;
		}
	}

}