using System.Collections.Generic;
using MarcoFrattarola.finance;
using NodaTime;

namespace MarcoFrattarola
{
    /// <summary>
    /// The interface Statistic factory provides methods to create different DataCreators
    /// elements for the finances context.
    /// </summary>
    public interface IFinanceStatisticFactory
    {
        /// <summary>
        /// Creates a DataCreator that maps each Account to a KeyValuePair of IAccount and int.
        /// Each pair represents the balance for a specific Account.
        /// </summary>
        /// <returns>The data creator</returns>
        IDataCreator<IAccount, KeyValuePair<IAccount, int>> AccountBalances();
        /// <summary>
        /// Creates a DataCreator that maps each Transaction to a KeyValuePair of LocalDate and int.
        /// Each pair represents the balance for a specific day.
        /// </summary>
        /// <returns>The data creator</returns>
        IDataCreator<ITransaction, KeyValuePair<LocalDate, int>> DailyExpenses();
        /// <summary>
        /// Creates a DataCreator that maps each Transaction of a specific account to a KeyValuePair of LocalDate
        /// and int. Each pair represents the balance for a specific day.
        /// </summary>
        /// <param name="account">The account</param>
        /// <returns>The data creator </returns>
        DataCreator<ITransaction, KeyValuePair<LocalDate, int>> DailyAccountExpenses(IAccount account);
    }
}