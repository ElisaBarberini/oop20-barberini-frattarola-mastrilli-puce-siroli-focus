using System;
using System.Linq;
using NodaTime;
using Xunit;

namespace AlexSiroli
{
	/// Class that tests everything related to the logic part of the finance section.
	public class FinanceTest
	{

		private readonly FinanceManager financeManager;

		public FinanceTest()
		{
			financeManager = new FinanceManager();
		}

		[Fact]
		public virtual void TestAccounts()
		{
			// mi salvo quanti conti e quante transazioni sono già salvate nel database
			int numAcc = this.financeManager.AccountManager.Elements.Count();
			int numTra = this.financeManager.TransactionManager.Elements.Count();

			// riferimenti ai conti
			IAccount firstAccount = new Account("Conto1", 150_000);
			IAccount secondAccount = new Account("Conto2", 10_000);

			// salvo i conti
			this.financeManager.AddAccount(firstAccount);
			this.financeManager.AddAccount(secondAccount);

			// aggiungo una transazione
			this.financeManager.AddTransaction(new Transaction("Transazione1", new Category("Spesa"), new LocalDateTime(2020, 1, 1, 0, 0, 0), firstAccount, -250));

			// controlli conti
			Assert.Equal(numAcc + 2, this.financeManager.AccountManager.Elements.Count());

			// controlli transazioni
			Assert.Equal(numTra + 1, this.financeManager.TransactionManager.Elements.Count());

			// elimino un account
			this.financeManager.RemoveAccount(firstAccount);

			// controllo che sia stato eliminato da account
			Assert.Equal(numAcc + 1, this.financeManager.AccountManager.Elements.Count());

			// controllo che le transazioni relativi a quell'account siano state eliminate
			Assert.Equal(numTra, this.financeManager.TransactionManager.Elements.Count());

			// riporto tutto come da principio
			this.financeManager.RemoveAccount(secondAccount);

			// controllo che la rimozione sia andata a buon fine
			Assert.Equal(numAcc, this.financeManager.AccountManager.Elements.Count());
		}

		[Fact]
		public virtual void TestCategories()
		{
			// mi salvo quante categorie, conti e transazioni ho già salvato
			int numCat = this.financeManager.CategoryManager.Elements.Count();
			int numAcc = this.financeManager.AccountManager.Elements.Count();
			int numTra = this.financeManager.TransactionManager.Elements.Count();

			// creo delle categorie
			this.financeManager.AddCategory(new Category("Categoria1"));
			this.financeManager.AddCategory(new Category("Categoria2"));
			this.financeManager.AddCategory(new Category("Categoria3"));

			// creo un conto e una transazione
			this.financeManager.AddAccount(new Account("Conto1", 250));
			this.financeManager.AddTransaction(new Transaction("Transazione1", new Category("Categoria1"), new LocalDateTime(2020, 1, 1, 0, 0, 0), new Account("Conto1", 0), -250));

			// controlli categories
			Assert.Equal(numCat + 3, this.financeManager.CategoryManager.Elements.Count());

			// provo a rimuovere una categoria di cui esistono transazioni
			try
			{
				this.financeManager.RemoveCategory(new Category("Categoria1"));
				Assert.True(false, "Test fallito");
			}
			catch (InvalidOperationException)
			{
			}

			// controllo che non siano state rimosse categorie
			Assert.Equal(numCat + 3, this.financeManager.CategoryManager.Elements.Count());

			// provo a rimuovere le categorie di cui non esistono transazioni
			this.financeManager.RemoveCategory(new Category("Categoria2"));
			this.financeManager.RemoveCategory(new Category("Categoria3"));

			// controllo che siano state rimosse due categorie
			Assert.Equal(numCat + 1, this.financeManager.CategoryManager.Elements.Count());

			// riporto tutto come da principio
			this.financeManager.RemoveAccount(new Account("Conto1", 0));
			this.financeManager.RemoveCategory(new Category("Categoria1"));

			// controllo che la rimozione sia andata a buon fine
			Assert.Equal(numCat, this.financeManager.CategoryManager.Elements.Count());
			Assert.Equal(numAcc, this.financeManager.AccountManager.Elements.Count());
			Assert.Equal(numTra, this.financeManager.TransactionManager.Elements.Count());
		}

		[Fact]
		public virtual void TestTransactions()
		{
			// mi salvo quanti conti e transazioni ho già salvato
			int numAcc = this.financeManager.AccountManager.Elements.Count();
			int numTra = this.financeManager.TransactionManager.Elements.Count();

			// creo un conto
			this.financeManager.AddAccount(new Account("Conto1", 250));

			// creo due transazioni
			this.financeManager.AddTransaction(new Transaction("Transazione1", new Category("Spesa"), new LocalDateTime(2020, 1, 1, 0, 0, 0), new Account("Conto1", 0), -250));
			this.financeManager.AddTransaction(new Transaction("Transazione2", new Category("Spesa"), new LocalDateTime(2020, 1, 1, 0, 0, 0), new Account("Conto1", 0), 1000));

			// controlli transazioni
			Assert.Equal(numTra + 2, this.financeManager.TransactionManager.Elements.Count());

			// referenze al conto
			IAccount account = new Account("Conto1", 0);

			// controllo importo iniziale
			Assert.Equal(1000, this.financeManager.GetAmount(account));

			// eseguo altre transazioni
			this.financeManager.AddTransaction(new Transaction("Transazione3", new Category("Spesa"), new LocalDateTime(2020, 12, 6, 0, 0, 0), account, -2500));
			this.financeManager.AddTransaction(new Transaction("Transazione4", new Category("Spesa"), new LocalDateTime(2020, 12, 6, 0, 0, 0), account, 7500));
			Assert.Equal(numTra + 4, this.financeManager.TransactionManager.Elements.Count());

			// controllo importo
			Assert.Equal(6000, this.financeManager.GetAmount(account));

			// eseguo altre transazioni
			var fifthTransaction = new Transaction("Transazione5", new Category("Spesa"), new LocalDateTime(2020, 12, 6, 0, 0, 0), account, -6000);
			var sixthTransaction = new Transaction("Transazione6", new Category("Spesa"), new LocalDateTime(2020, 12, 6, 0, 0, 0), account, 100000);
			this.financeManager.AddTransaction(fifthTransaction);
			this.financeManager.AddTransaction(sixthTransaction);
			Assert.Equal(numTra + 6, this.financeManager.TransactionManager.Elements.Count());

			// controllo importi
			Assert.Equal(100000, this.financeManager.GetAmount(account));

			// elimino le ultime due transazioni
			this.financeManager.RemoveTransaction(fifthTransaction);
			this.financeManager.RemoveTransaction(sixthTransaction);
			Assert.Equal(numTra + 4, this.financeManager.TransactionManager.Elements.Count());

			// controllo importi
			Assert.Equal(6000, this.financeManager.GetAmount(account));

			// riporto tutto come da principio
			this.financeManager.RemoveAccount(new Account("Conto1", 0));

			// controllo che la rimozione sia andata a buon fine
			Assert.Equal(numAcc, this.financeManager.AccountManager.Elements.Count());
			Assert.Equal(numTra, this.financeManager.TransactionManager.Elements.Count());
		}
	}
}
