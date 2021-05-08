using System.Collections.Generic;

namespace MarcoFrattarola
{    /// <summary>
     /// The interface Data creator represents an object that, given a collection of
     /// type X elements can generate a collection of Type Y elements.
     /// </summary>
     /// <typeparam name="TX">The type of the inout elements</typeparam>
     /// <typeparam name="TY">The type of the output elements</typeparam>
    public interface IDataCreator<TX, TY>
    {   /// <summary>
        /// Generate and returns the output collection of type Y.
        /// </summary>
        /// <returns>The IEnumerable with the result</returns>
        IEnumerable<TY> Get();
    }
}