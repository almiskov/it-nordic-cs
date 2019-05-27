using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Stack<int> dishes = new Stack<int>();
			var i = 0;
			while (true)
			{
				Console.WriteLine("Введите что нужно сделать:");
				var input = Console.ReadLine();
				if (input == "wash")
				{
					dishes.Push(1);
					i++;
					Console.WriteLine(i);
				}
				else if (input == "dry")
				{
					if (dishes.Count > 0)
					{
						Console.WriteLine($"{dishes.Pop()}");
					}
				}
				else if (input == "exit")
				{
					Console.WriteLine("Пока!");
					break;
				}
			}
			Console.ReadKey();
		}
	}
}
