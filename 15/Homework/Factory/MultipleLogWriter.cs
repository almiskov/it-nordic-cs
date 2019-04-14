using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Factory
{
	class MultipleLogWriter : AbstractLogWriter, ICollection<ILogWriter>
	{
		private ICollection<ILogWriter> _logWriters = new Collection<ILogWriter>();

		protected override void Log(MessageType messageType, string message)
		{
			foreach (ILogWriter logWriter in _logWriters)
			{
				switch (messageType)
				{
					case MessageType.Error:
						logWriter.LogError(message);
						break;
					case MessageType.Info:
						logWriter.LogInfo(message);
						break;
					case MessageType.Warning:
						logWriter.LogWarning(message);
						break;
				}
			}
		}

		#region ICollection<ILogWriter> implementation (Add() method modified)

		public int Count => _logWriters.Count;

		public bool IsReadOnly => _logWriters.IsReadOnly;

		public void Add(ILogWriter item)
		{
			if (item.GetType() != this.GetType())
				_logWriters.Add(item);
		}

		public void Clear()
		{
			_logWriters.Clear();
		}

		public bool Contains(ILogWriter item)
		{
			return _logWriters.Contains(item);
		}

		public void CopyTo(ILogWriter[] array, int arrayIndex)
		{
			_logWriters.CopyTo(array, arrayIndex);
		}

		public bool Remove(ILogWriter item)
		{
			return _logWriters.Remove(item);
		}

		public IEnumerator<ILogWriter> GetEnumerator()
		{
			return _logWriters.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _logWriters.GetEnumerator();
		}

		#endregion
	}
}
