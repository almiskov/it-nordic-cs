using System;
using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		public static string OutputPrefixFormat { get; set; }

		public string Category { get; }

		private List<string> _errors;

		static ErrorList()
		{
			OutputPrefixFormat = "MMMM dd, yyyy (h:mm tt)";
		}

		public ErrorList(string category)
		{
			Category = category;
			_errors = new List<string>();
		}

		public void WriteToConsole()
		{
			foreach(string s in _errors)
			{
				var prefix = DateTimeOffset.Now.ToString(OutputPrefixFormat);
				Console.WriteLine($"{prefix}: {s}");
			}
		}

		public void Add(string error)
		{
			_errors.Add(error);
		}

		public void Dispose()
		{
			if(_errors != null)
			{
				_errors.Clear();
				_errors = null;
			}
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _errors.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _errors.GetEnumerator();
		}
	}
}
