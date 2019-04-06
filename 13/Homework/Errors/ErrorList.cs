using System;
using System.Collections;
using System.Collections.Generic;

namespace Errors
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		public string Category { get; }

		private List<string> _errors;

		public ErrorList(string category)
		{
			Category = category;
			_errors = new List<string>();
		}

		public void Add(string errorMessage)
		{
			_errors.Add(errorMessage);
		}

		public void Dispose()
		{
			_errors.Clear(); // тут вообще есть смысл очищать его, если мы тут же делаем его null?
			_errors = null;
		}

		public IEnumerator<string> GetEnumerator()
		{
			return ((IEnumerable<string>)_errors).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)_errors).GetEnumerator();
		}
	}
}
