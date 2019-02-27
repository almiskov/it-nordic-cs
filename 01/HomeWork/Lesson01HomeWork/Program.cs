using System;
using System.Threading;

namespace Lesson01HomeWork
{
	class Program
	{		
		static void Main(string[] args)
		{
			Console.WriteLine("Please, enter your name:");
			string name = Console.ReadLine();
			CountDown(5);
			Console.WriteLine($"Hello, {name}!");
			CountDown(5);
			Console.WriteLine($"See you later, {name}!");
			Console.ReadKey();
		}

		static void CountDown(byte fromSeconds)
		{
			Console.CursorVisible = false;

			for(byte i = fromSeconds; i > 0; i--)
			{
				Console.Write(i);
				Thread.Sleep(1000);
				Console.CursorLeft = 0;
			}

			Console.CursorVisible = true;
		}
	}
}
