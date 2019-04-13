using System.Collections;
using System.Collections.Generic;

namespace Singleton
{
	class MultipleLogWriter : AbstractLogWriter, ICollection<ILogWriter>
	{
		private ICollection<ILogWriter> _logWriters;

		private static MultipleLogWriter _instance;

		private MultipleLogWriter()
		{
			_logWriters = new List<ILogWriter>();
		}

		public static MultipleLogWriter GetInstance()
		{
			if (_instance == null)
				_instance = new MultipleLogWriter();
			return _instance;
		}

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

		#region ICollection<ILogWriter> autoimplementation

		public int Count => ((ICollection<ILogWriter>)_logWriters).Count;

		public bool IsReadOnly => ((ICollection<ILogWriter>)_logWriters).IsReadOnly;

		public void Add(ILogWriter item)
		{
			((ICollection<ILogWriter>)_logWriters).Add(item);
		}

		public void Clear()
		{
			((ICollection<ILogWriter>)_logWriters).Clear();
		}

		public bool Contains(ILogWriter item)
		{
			return ((ICollection<ILogWriter>)_logWriters).Contains(item);
		}

		public void CopyTo(ILogWriter[] array, int arrayIndex)
		{
			((ICollection<ILogWriter>)_logWriters).CopyTo(array, arrayIndex);
		}

		public bool Remove(ILogWriter item)
		{
			return ((ICollection<ILogWriter>)_logWriters).Remove(item);
		}

		public IEnumerator<ILogWriter> GetEnumerator()
		{
			return ((ICollection<ILogWriter>)_logWriters).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((ICollection<ILogWriter>)_logWriters).GetEnumerator();
		}

		#endregion
	}
}
