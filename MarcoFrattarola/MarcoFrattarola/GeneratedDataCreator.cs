using System;
using System.Collections.Generic;

namespace MarcoFrattarola
{    /// <summary>
     /// Implementation of IDataCreator that re-creates the dataset each time the Get() method is called.
     /// </summary>
     /// <typeparam name="TX">The input type</typeparam>
     /// <typeparam name="TY">The output type</typeparam>
    public class GeneratedDataCreator<TX,TY> : DataCreator<TX,TY>
    {
        private readonly Func<IEnumerable<TX>, IEnumerable<TX>> generator;

        public GeneratedDataCreator(Func<IEnumerable<TX>, IEnumerable<TX>> generator, Func<IEnumerable<TX>, IEnumerable<TY>> func) : base(new List<TX>(), func)
        {
            this.generator = generator;
        }

        public override IEnumerable<TY> Get()
        {
            Dataset = generator.Invoke(Dataset);
            return base.Get();
        }
    }
}