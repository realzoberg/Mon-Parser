using System;
using Operators;

namespace Parser
{

	class Parser
	{
		private string currentStr;

		private string[] result;

		readonly private string[] operatorSymbols;

		public string[] Result {get {return result;}}

		private readonly Operator[] operators;

		public Parser(Operator[]ops)
		{
			operators = ops;
			operatorSymbols = operators[0].Symbols;
			for(var i = 1; i < operators.Length; i++)
				// не уверен, что Append правильное слово
				operatorSymbols.Append(operators[i].Symbols);
			// TODO: проверить, что не может быть двух одинаковых символов в operatorSymbols, а если есть, то хуйня получилась и надо падать.
		}

		private bool Valid()
		{
			// TODO: чето так западлень...
			// а, ну да, это метод, который определить должен, является ли currentStr валидным словом.
		}

		public void PutChar(char c)
		{
			// сольем накопленное
			if(c == '\0')
			{
				if(!Valid(currentStr))
					throw new Exception("FFFFUUUUUUUUU!!!!!11111111");
				result += currentStr;
				currentStr = "";
				return;
			}

			currentStr += c;
			// если валидна, просто ничего не делаем
			if(Valid(currentStr))
				return;
			// как только невалидна - откатываемся
			// TODO: проверить, что правильно отсекаю последний символ, ато я каждый раз забываю как
			currentStr = currentStr.Substring(0,currentStr.Length - 1);
			result += currentStr;
			currentStr = c;
		}


	}

}
