using System;
using System.Collections.Generic;
using System.Linq;
using ChangeTracker.InputOutput;

namespace ChangeTracker.Tests.Mocks
{
	public class InputOutputTextMock : IInputOutputText
	{
		private List<string> _linesWritten;

		public InputOutputTextMock()
		{
			_linesWritten = new List<string>();
		}

		public bool LineHasBeenWritten(string lineToFind)
		{
			return _linesWritten.Any(x => x == lineToFind);
		}

		public void LinesWrittenClear()
		{
			_linesWritten.Clear();
		}

		// IInputOutputText implementation.

		public string ReadLine()
		{
			throw new NotImplementedException();
		}

		public void Write(string textToWrite)
		{
			_linesWritten.Add(textToWrite);
		}

		public void WriteLine(string lineToWrite)
		{
			_linesWritten.Add(lineToWrite);
		}
	}
}
