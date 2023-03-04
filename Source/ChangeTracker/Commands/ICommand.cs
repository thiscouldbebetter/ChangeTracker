using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	public abstract class Command
	{
		public readonly string Name;
		protected readonly IInputOutputText _inputOutputText;

		public Command(string name, IInputOutputText inputOutputText)
		{
			Name = name;
			_inputOutputText = inputOutputText;
		}

		public abstract void Execute(Session session, string[] commandParts);
	}
}
