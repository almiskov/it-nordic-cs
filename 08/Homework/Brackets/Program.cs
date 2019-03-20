using System;
using System.Collections.Generic;
using System.Linq;

namespace Brackets
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите любую последовательность из скобок ( ) { } [ ] < > или \"exit\" для выхода.");

			string inputString;
			bool isSequenceCorrect;

			do
			{
				inputString = Console.ReadLine().Trim().ToLower();

				if(inputString == "exit")
				{
					break;
				}
				else if(string.IsNullOrWhiteSpace(inputString))
				{
					Console.WriteLine("Ничего не введено. Повторите ввод.");
				}
				else
				{
					isSequenceCorrect = IsSequenceCorrect(inputString);

					Console.WriteLine(isSequenceCorrect ? 
						"Последовательность верная." : 
						"Последовательность НЕ верная. Возможно присутствуют лишние символы.");
				}

			} while (true);
		}

		static bool IsSequenceCorrect(string bracketSequence)
		{
			Stack<char> stack = new Stack<char>(bracketSequence.Length);

			bool isAnythingInStack;
			char topBracketInStack;

			bool isBracketClosesTopBracketInStack;
			/*
			"закрывает ли текущая скобка верхнюю скобку в стэке?".
			Зависит в том числе от метода расширения TurnIntoOpeningBracketOrDefault() для char,
			который превращает закрывающуюся скобку в открывающуюся, но если не может этого сделать, возвращает \u0000.
			*/

			foreach (char bracket in bracketSequence)
			{
				isAnythingInStack = stack.TryPeek(out topBracketInStack);

				isBracketClosesTopBracketInStack =  // тут что-то с названием надо переосмыслить
					topBracketInStack == bracket.TurnIntoOpeningBracketOrDefault() &&
					topBracketInStack != default(char);
				/*
				В принципе можно обойтись и без проверки на дефолт, но тогда существует возможность получить true,
				когда стэк пустой и текущая скобка в строке открывающаяся. Хоть в этом случае isAnythingInStack будет false,
				и дальнейшее условие всё равно не даст вытащить что бы то ни было из стэка,
				но более осмысленной переменной в голову не приходит, поэтому лучше, наверное, так оставить
				*/

				if (isAnythingInStack && isBracketClosesTopBracketInStack)
					stack.Pop();
				else
					stack.Push(bracket);
			}

			return stack.Count == 0 ? true : false;
		}
	}

	public static class CharExtension
	{
		public static char TurnIntoOpeningBracketOrDefault(this char closingBracket)
		{
			switch (closingBracket)
			{
				case ')':
					return '(';
				case ']':
					return '[';
				case '}':
					return '{';
				case '>':
					return '<';
				default:
					return default(char);
			}
		}
	}
}
