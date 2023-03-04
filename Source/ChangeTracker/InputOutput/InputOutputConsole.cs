using System;

namespace ChangeTracker.InputOutput
{
	public class InputOutputConsole : IInputOutputText
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void Write(string textToWrite)
		{
			Console.Write(textToWrite);
		}

		public void WriteLine(string lineToWrite)
		{
			Console.WriteLine(lineToWrite);
		}
	}
}
