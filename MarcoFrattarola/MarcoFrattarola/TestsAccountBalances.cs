using System.Collections.Generic;
using System.Linq;
using MarcoFrattarola.finance;
using NodaTime;
using Xunit;

namespace MarcoFrattarola
{
    public class TestAccountBalances
    {
        private readonly IFinanceManager financeManager = new FinanceManager();
        [Fact]
        public void TestAccount1()
        {
            var dataSource = new FinanceStatisticFactory(this.financeManager);
            var data = dataSource.AccountBalances();
            // riferimenti ai conti
            var ac1 = new Account("AccountBalanceT1", 1_500_000);
            var ac2 = new Account("AccountBalanceT2", 1_000_000);
            this.financeManager.AddAccount(ac1);
            this.financeManager.AddAccount(ac2);
            
            this.financeManager.AddTransaction(new Transaction("Transazione1",
                new Category("Spesa"),
                new LocalDateTime(1960, 1, 1, 0, 0, 0),
                ac1, -250));
            
            this.financeManager.AddTransaction(new Transaction("Transazione2",
                new Category("Spesa"),
                new LocalDateTime(1960, 1, 1, 0, 0, 0),
                ac2, -250));
            
            Assert.True(data.Get().Count() == 2);
            Assert.True(data.Get().Select(a => a.Value)
                .Intersect(new List<int>{1_499_750, 999_750}.AsEnumerable()).Count() == 2);

            
            this.financeManager.RemoveAccount(ac1);
            this.financeManager.RemoveAccount(ac2);
        }
    }
}