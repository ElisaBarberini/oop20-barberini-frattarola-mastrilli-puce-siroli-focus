using System.Collections.Generic;
using System.Linq;
using MarcoFrattarola.finance;
using NodaTime;
using Xunit;

namespace MarcoFrattarola
{
    public class TestsDailyExpenses
    {
        private readonly IFinanceManager financeManager = new FinanceManager();
        [Fact]
        public void Test1()
        {
            var dataSource = new FinanceStatisticFactory(this.financeManager);
            var data = dataSource.DailyExpenses();
            // riferimenti ai conti
            var ac1 = new Account("AccountTDaily1", 150_000);
            var ac2 = new Account("AccountTDaily2", 10_000);
            this.financeManager.AddAccount(ac1);
            this.financeManager.AddAccount(ac2);

            this.financeManager.AddTransaction(new Transaction("TransactionT1",
                new Category("Spesa"),
                new LocalDateTime(1960, 7, 1, 0, 0, 0),
                ac1, +2500000));
            this.financeManager.AddTransaction(new Transaction("TransactionT2",
                new Category("Taxi"),
                new LocalDateTime(1960, 7, 5, 0, 0, 0),
                ac2, -2500000));
            this.financeManager.AddTransaction(new Transaction("TransactionT3",
                new Category("Spesa"),
                new LocalDateTime(1960, 7, 6, 0, 0, 0),
                ac1, -2500000));


            Assert.True(data.Get().Select(a=>a.Value)
                .Intersect(new List<int>{-2500000, -2500000, 2500000}.AsEnumerable()).Count() == 2);

            this.financeManager.RemoveAccount(ac1);
            this.financeManager.RemoveAccount(ac2);
        }
    }
}