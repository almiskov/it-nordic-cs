using System;

namespace Flags
{
	class Program
	{
		[Flags]
		enum Days
		{
			None = 0x00,
			Monday = 0x01,
			Tuesday = 0x01 << 1,
			Wednesday = 0x01 << 2,
			Thirsday = 0x01 << 3,
			Friday = 0x01 << 4,
			Saturday = 0x01 << 5,
			Sunday = 0x01 << 6
		}

		static void Main(string[] args)
		{
			Days nonWorkingDays = Days.Saturday | Days.Sunday;
			nonWorkingDays = nonWorkingDays | Days.Monday | Days.Tuesday | Days.Monday; // если повторно добавляем, то ничего страшного
			WriteByteValueWithBits((byte)nonWorkingDays);
			Console.WriteLine();
			nonWorkingDays = nonWorkingDays ^ Days.Monday ^ Days.Tuesday; //перед повторным удалением надо проверить на наличие
			WriteByteValueWithBits((byte)nonWorkingDays);
			Console.WriteLine();
			Console.WriteLine((nonWorkingDays & Days.Sunday) == Days.Sunday);





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
