using System;
using System.Collections.Generic;

namespace _HashSet
{
	class Program
	{
		static void Main(string[] args)
		{
			Stack<object> plates = new Stack<object>();

			Console.WriteLine("Wash - положить тарелку в стопку; dry - забрать тарелку из стопки и вытереть; exit - выход.");
			string command;

			while (true)
			{
				command = Console.ReadLine().ToLower();

				if (command == "wash")
				{
					plates.Push(new object());
					Console.WriteLine($"В стопке {plates.Count} тарелок.");
				}
				else if (command == "dry")
				{
					if (plates.Count > 0)
					{
						plates.Pop();
						Console.WriteLine($"В стопке {plates.Count} тарелок.");
					}
					else
					{
						Console.WriteLine("Стопка тарелок пуста!");
					}
				}
				else if (command == "exit")
				{
					Console.WriteLine($"В стопке осталось {plates.Count} тарелок.");
					break;
				}
			}
		}
	}
}
