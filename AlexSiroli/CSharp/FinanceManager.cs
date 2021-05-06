using System;
using System.Linq;

namespace AlexSiroli
{

	/// Immutable implementation of a finance manager.
	public class FinanceManager : IFinanceManager
	{

		private readonly IManager<IAccount> accounts;
		private readonly IManager<ICategory> categories;
		private readonly IManager<ITransaction> transactions;

		public FinanceManager()
		{
			this.accounts = new Manager<IAccount>();
			this.categories = new Manager<ICategory>();
			this.transactions = new Manager<ITransaction>();
		}

		/// {@inheritDoc}
		public void AddAccount(IAccount account)
		{
			this.accounts.Add(account);
		}

		/// {@inheritDoc}
		public void RemoveAccount(IAccount account)
		{
			var tmp = this.transactions.Elements.Where(t => t.Account.Equals(account)).ToList();
			foreach (var elem in tmp)
            {
				this.RemoveTransaction(elem);
            }
			this.accounts.Remove(account);
		}

		/// {@inheritDoc}
		public void AddCategory(ICategory category)
		{
			this.categories.Add(category);
		}

		/// {@inheritDoc}
		public void RemoveCategory(ICategory category)
		{
			if (!this.transactions.Elements.Select<ITransaction, ICategory>(t => t.Category).Contains(category))
			{
				this.categories.Remove(category);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		/// {@inheritDoc}
		public void AddTransaction(ITransaction transaction)
		{
			this.transactions.Add(transaction);
		}

		/// {@inheritDoc}
		public int GetAmount(IAccount account)
		{
			var acc = this.accounts.Elements.Where(a => a.Equals(account)).ToList().First();
			return acc.InitialAmount + this.transactions.Elements
				.Where(t => t.Account.Equals(acc)).Select<ITransaction, int>(t => t.Amount).Aggregate((t1, t2) => t1 + t2);
		}

		/// {@inheritDoc}
		public void RemoveTransaction(ITransaction transaction)
		{
			if (this.transactions.Elements.Contains(transaction))
			{
				this.transactions.Remove(transaction);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public IManager<IAccount> AccountManager
		{
			get
			{
				return this.accounts;
			}
		}

		public IManager<ICategory> CategoryManager
		{
			get
			{
				return this.categories;
			}
		}

		public IManager<ITransaction> TransactionManager
		{
			get
			{
				return this.transactions;
			}
		}
	}

}