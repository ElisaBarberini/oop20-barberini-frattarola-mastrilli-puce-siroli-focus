namespace MarcoFrattarola.finance
{

	/// Immutable implementation of an account.
	public class Account : IAccount
	{

		private readonly string name;
		private readonly int initialAmount;

		public Account(string name, int initialAmount)
		{
			this.name = name;
			this.initialAmount = initialAmount;
		}

        public string Name
        {
			get
			{
				return this.name;
			}

        }

		public int InitialAmount
		{
			get
			{
				return this.initialAmount;
			}
		}

		public override sealed string ToString()
		{
			return "Name: " + this.name + ", initial amount: " + this.initialAmount;
		}

        public override bool Equals(object obj)
        {
            return obj is Account impl &&
                   name == impl.name;
        }

        protected bool Equals(Account other)
        {
	        return name == other.name && initialAmount == other.initialAmount;
        }

        public override int GetHashCode()
        {
	        unchecked
	        {
		        return ((name != null ? name.GetHashCode() : 0) * 397) ^ initialAmount;
	        }
        }
	}

}