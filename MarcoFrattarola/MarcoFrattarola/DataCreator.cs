using System;
using System.Collections.Generic;

namespace MarcoFrattarola
{    /// <summary>
     /// Implementation of IDataCreator
     /// </summary>
     /// <typeparam name="TX">The input type</typeparam>
     /// <typeparam name="TY">The output type</typeparam>
    public class DataCreator<TX,TY> : IDataCreator<TX,TY>
    {
        private readonly Func<IEnumerable<TX>, IEnumerable<TY>> func;
        protected IEnumerable<TX> Dataset;

        public DataCreator(IEnumerable<TX> dataset, Func<IEnumerable<TX>,IEnumerable<TY>> func)
        {
            this.Dataset = dataset;
            this.func = func;
        }
        public virtual IEnumerable<TY> Get()
        {
            return func.Invoke(Dataset);
        }
    }
}