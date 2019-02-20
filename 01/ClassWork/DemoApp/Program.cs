using System;
using System.Threading;

namespace DemoApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите имя:");
			string name = Console.ReadLine();
			Thread.Sleep(1000);
			Console.WriteLine($"Приветствую, {name}!");
			Console.ReadKey();
		}
	}
}
