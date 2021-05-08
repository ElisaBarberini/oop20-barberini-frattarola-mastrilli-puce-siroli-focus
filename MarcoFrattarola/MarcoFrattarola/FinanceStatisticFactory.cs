using System;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using MarcoFrattarola.finance;

namespace MarcoFrattarola
{
    public class FinanceStatisticFactory : IFinanceStatisticFactory
    {
        private readonly IFinanceManager manager;

        public FinanceStatisticFactory(IFinanceManager manager)
        {
            this.manager = manager;
        }

        public IDataCreator<IAccount, KeyValuePair<IAccount, int>> AccountBalances()
        {
            Console.WriteLine(this.manager.AccountManager.Elements.Count);
            return new DataCreator<IAccount, KeyValuePair<IAccount, int>>(this.manager.AccountManager.Elements,
                a => a.Select(elem => 
                    new KeyValuePair<IAccount, int>(elem, manager.GetAmount(elem))));
        }

        public IDataCreator<ITransaction, KeyValuePair<LocalDate, int>> DailyExpenses()
        {
            return new DataCreator<ITransaction, KeyValuePair<LocalDate, int>>(this.manager.TransactionManager.Elements,
                a => a
                    .Select(elem => new KeyValuePair<LocalDate, int>(elem.Date.Date, elem.Amount))
                    .GroupBy(elem => elem.Key,
                        elem => elem.Value,
                        (e1, e2) => new KeyValuePair<LocalDate, int>(e1, e2.Sum())));
        }

        public DataCreator<ITransaction, KeyValuePair<LocalDate, int>> DailyAccountExpenses(IAccount account)
        {
            return new GeneratedDataCreator<ITransaction, KeyValuePair<LocalDate, int>>(
                a =>  this.manager.TransactionManager.Elements
                    .Where(elem => elem.Account.Equals(account)),
                a => a
                    .Select(elem => new KeyValuePair<LocalDate, int>(elem.Date.Date, elem.Amount))
                    .GroupBy(elem => elem.Key,
                        elem => elem.Value,
                        (e1, e2) => new KeyValuePair<LocalDate, int>(e1, e2.Sum())));
        }
    }
}