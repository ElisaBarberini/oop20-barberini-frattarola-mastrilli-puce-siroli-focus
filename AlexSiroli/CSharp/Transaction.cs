using NodaTime;
using System;
using System.Collections.Generic;

namespace AlexSiroli
{

	/// Class that considers the characteristics of a single transaction.
	public class Transaction : ITransaction
	{

		private readonly string description;
		private readonly ICategory category;
		private readonly LocalDateTime date;
		private readonly IAccount account;
		private readonly int amount;

		public Transaction(string description, ICategory category, LocalDateTime localDateTime, IAccount account, int amount)
		{
			this.description = description;
			this.category = category;
			this.date = localDateTime;
			this.account = account;
			this.amount = amount;
		}

		public string Description
		{
			get
			{
				return this.description;
			}
		}

		public ICategory Category
		{
			get
			{
				return this.category;
			}
		}

		public LocalDateTime Date
		{
			get
			{
				return this.date;
			}
		}

		public IAccount Account
		{
			get
			{
				return this.account;
			}
		}

		public int Amount
		{
			get
			{
				return this.amount;
			}
		}

        public override bool Equals(object obj)
        {
            return obj is Transaction transaction &&
                   description == transaction.description &&
                   EqualityComparer<ICategory>.Default.Equals(category, transaction.category) &&
                   date.Equals(transaction.date) &&
                   EqualityComparer<IAccount>.Default.Equals(account, transaction.account) &&
                   amount == transaction.amount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(description, category, date, account, amount);
        }

        public override sealed string ToString()
		{
			return "Description: " + this.description + ", category: " + this.category.Name
				+ ", date: " + this.date + ", account: " + this.account.Name + ", amount: " + this.amount;
		}
	}

}