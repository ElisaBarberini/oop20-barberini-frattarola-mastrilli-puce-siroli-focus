using System.Collections.Generic;
using System.Linq;
using MarcoFrattarola.finance;
using NodaTime;
using Xunit;

namespace MarcoFrattarola
{
    public class TestAccountDailyExpences
    {
        private readonly IFinanceManager financeManager = new FinanceManager();
        [Fact]
        public void Test()
        {
            var dataSource = new FinanceStatisticFactory(this.financeManager);

            // riferimenti ai conti
            var ac1 = new Account("AccountT1", 150_000);
            var ac2 = new Account("AccountT2", 10_000);
            var data = dataSource.DailyAccountExpenses(ac1);
            this.financeManager.AddAccount(ac1);
            this.financeManager.AddAccount(ac2);

            this.financeManager.AddTransaction(new Transaction("TransactionT1",
                new Category("Spesa"),
                new LocalDateTime(1960, 7, 1, 0, 0, 0),
                ac1, +250));
            this.financeManager.AddTransaction(new Transaction("TransactionT2",
                new Category("Taxi"),
                new LocalDateTime(1960, 7, 5, 0, 0, 0),
                ac2, -250));
            this.financeManager.AddTransaction(new Transaction("TransactionT3",
                new Category("Spesa"),
                new LocalDateTime(1960, 7, 1, 0, 0, 0),
                ac1, -250));


            var d = data.Get();
            Assert.True(data.Get().Select(a=>a.Value)
                .Intersect(new List<int>{0}.AsEnumerable()).Count() == 1);

            this.financeManager.RemoveAccount(ac1);
            this.financeManager.RemoveAccount(ac2);
        }
    }
}