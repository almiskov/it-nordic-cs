using System;

namespace L02_HW
{
	class Program
	{
		static char[] allowedOperators = { '+', '-', '*', '/', '%', '^' };
		static string exitExpression = "exit";

		static void Main(string[] args)
		{
			ShowHeader(); // показываем пользователю заголовок с общей информацией

			double result = 0;
			string expression = "";

			while(expression != exitExpression)
			{
				expression = Console.ReadLine();

				if (TryFindOperator(expression.Replace(" ", ""), out char? op))
				{
					string[] operands = expression.Split(op.Value);

					if (double.TryParse(operands[0], out double a) &&
						double.TryParse(operands[1], out double b) &&
						expression.IndexOf(op.Value) == expression.LastIndexOf(op.Value))   // если индекс первого вхождения найденного оператора НЕ равен
					{                                                                       // индексу последнего, значит оператор в выражении не повторяется два раза
						switch (op.Value)
						{
							case '+':
								result = a + b;
								break;
							case '-':
								result = a - b;
								break;
							case '*':
								result = a * b;
								break;
							case '/':
								result = Math.Round(a / b, 5);
								break;
							case '%':
								result = a % b;
								break;
							case '^':
								result = Math.Pow(a, b);
								break;
						}
						Console.SetCursorPosition(expression.Length, Console.CursorTop - 1);
						Console.WriteLine(" = " + result);
					}
					else
					{
						Console.WriteLine("There is some error. Try again.");
					}
				}
				else
				{
					if(expression != exitExpression)
						Console.WriteLine("There is not allowed operator in the expression. Try again.");
				}
			}
		}

		static void ShowHeader()
		{
			Console.WriteLine("Type a simple expression without equal sign and press Enter to get result.");

			string s = "Allowed operators:";

			foreach(char ch in allowedOperators)
			{
				s += " " + ch;
			}
			Console.WriteLine(s);

			Console.WriteLine($"Input \"{exitExpression}\" to exit.");
		}

		/// <summary>
		/// Пробует найти в выражении один из доступных операторов. При нахождении возвращает true и выпускает его на волю
		/// </summary>
		/// <param name="expression">Выражение, в котором нужно производить поиск</param>
		/// <param name="op">Найденный оператор (при наличии)</param>
		/// <returns></returns>
		static bool TryFindOperator(string expression, out char? op)
		{
			bool isExpressionContainsOperator = false;
			op = null;

			for(int i = 0; i < allowedOperators.Length; i++)
			{
				if (expression.Contains(allowedOperators[i]))
				{
					isExpressionContainsOperator = true;
					op = allowedOperators[i];
				}
			}

			return isExpressionContainsOperator;
		}

	}
}
