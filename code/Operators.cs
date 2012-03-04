using System;

namespace Parser
{

	class Operator
	{
		private readonly uint priority;
		private readonly string[] symbols;

		public uint Prior {get {return priority;}}
		public string[] Symbols {get {return symbols;}}

		public Operator(string[] syms, uint pr)
		{
			priority = pr;
			symbols = syms;
		}

		protected string Arg(uint i)
		{
			return string.Format("#{0}", i);
		}
	}

	class UnaryOperator : Operator
	{
		public UnaryOperator(string sym, uint pr) : base(new [] {sym}, pr) {}

		public string Symbol {get {return symbols[0];}}
	}

	class PrefixOperator : UnaryOperator
	{
		public PrefixOperator(string sym, uint pr) : base(sym, pr) {}

		public override string ToString()
		{
			return Symbol + Arg(1);
		}
	}

	class PostfixOperator : UnaryOperator
	{
		public PostfixOperator(string sym, uint pr) : base(sym, pr) {}

		public override string ToString()
		{
			return Arg(1) + Symbol;
		}
	}


	class RepeatedOperator : UnaryOperator
	{
		public RepeatedOperator(string sym, uint pr) : base(sym, pr) {}

		public override string ToString()
		{
			return Symbol;
		}
	}

	class NAryOperator : Operator
	{
		public NAryOperator(string[] syms, uint pr) : base(syms, pr) {}

		public override string ToString()
		{
			var res = Arg(1);
			for(var i = 0; i < symbols.Length - 1; i++)
				res += symbols[i] + Arg(i+2);
			return res;
		}

		public string this[uint n]
		{
			get
			{
				if(n > symbols.Length - 1)
					// тут надо какой-нибудь OutOfRangeException, не помню как он называется правильно
					throw new Exception("WTF?!");
				return symbols[n];
			}
		}
	}

	class ScobesOperator : Operator
	{
		public ScobesOperator(string lft, string rgh, uint pr) : base(new [] {lft, rgh}, pr) {}

		public override string ToString()
		{
			return Left + Arg(1) + Right;
		}

		public string Left {get {return symbols[0];}}
		public string Right {get {return symbols[1];}}
	}

}


