namespace ChangeTracker.InputOutput
{
	public interface IInputOutputText
	{
		string ReadLine();
		void Write(string textToWrite);
		void WriteLine(string lineToWrite);
	}
}
