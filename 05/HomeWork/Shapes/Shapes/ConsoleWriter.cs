using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Shapes
{
	public class ConsoleWriter
	{
		public ConsoleWriter()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
		}

		#region Write methods

		public void Write(string text)
		{
			Console.Write(text);
		}

		private void WriteWithColor(string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(text);
			Console.ResetColor();
		}

		public void WriteRed(string text)
		{
			WriteWithColor(text, ConsoleColor.Red);
		}

		public void WriteGreen(string text)
		{
			WriteWithColor(text, ConsoleColor.Green);
		}

		public void WriteYellow(string text)
		{
			WriteWithColor(text, ConsoleColor.Yellow);
		}

		public void WriteBlue(string text)
		{
			WriteWithColor(text, ConsoleColor.Blue);
		}

		#endregion

		#region WriteLine methods

		public void WriteLine(string text)
		{
			Console.WriteLine(text);
		}

		private void WriteLineWithColor(string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ResetColor();
		}

		public void WriteLineRed(string text)
		{
			WriteLineWithColor(text, ConsoleColor.Red);
		}

		public void WriteLineGreen(string text)
		{
			WriteLineWithColor(text, ConsoleColor.Green);
		}

		public void WriteLineYellow(string text)
		{
			WriteLineWithColor(text, ConsoleColor.Yellow);
		}

		public void WriteLineBlue(string text)
		{
			WriteLineWithColor(text, ConsoleColor.Blue);
		}


		#endregion
	}
}
