using System;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandChanges : Command
	{
		public CommandChanges(IInputOutputText inputOutput) : base("changes", inputOutput)
		{ }

		public override void Execute(Session session, string[] commandParts)
		{
			throw new NotImplementedException();
		}
	}
}
