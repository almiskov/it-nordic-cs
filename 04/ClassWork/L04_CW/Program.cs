using System;

namespace L04_CW
{
	class Program
	{
		static void Main(string[] args)
		{
			byte a = 0x09;
			byte b = 0x07;

			Console.WriteLine("OR |");
			WriteByteValueWithBits(a);
			WriteByteValueWithBits(b);
			WriteByteValueWithBits((byte)(a | b));

			Console.WriteLine("\nAND &");
			WriteByteValueWithBits(a);
			WriteByteValueWithBits(b);
			WriteByteValueWithBits((byte)(a & b));

			Console.WriteLine("\nXOR ^");
			WriteByteValueWithBits(a);
			WriteByteValueWithBits(b);
			WriteByteValueWithBits((byte)(a ^ b));

			Console.WriteLine("\nNOT ~");
			WriteByteValueWithBits(a);
			WriteByteValueWithBits((byte)(~a));

			Console.WriteLine("\nleft-shift <<");
			WriteByteValueWithBits(a);
			WriteByteValueWithBits((byte)(a << 1));

			Console.WriteLine("\nright-shift >>");
			WriteByteValueWithBits(b);
			WriteByteValueWithBits((byte)(b >> 1));

			Console.ReadLine();
		}

		static void WriteByteValueWithBits(byte value)
		{
			Console.WriteLine(
				"0x{0}\t{1}\t{2}",
				Convert.ToString(value, 16).PadLeft(2, '0'),
				Convert.ToString(value, 2).PadLeft(8, '0'),
				Convert.ToString(value, 10).PadLeft(3, '0'));
		}
	}
}
