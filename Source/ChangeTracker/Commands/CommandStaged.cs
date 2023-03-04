using System;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandStaged : Command
	{
		public CommandStaged(IInputOutputText inputOutput) : base("staged", inputOutput)
		{ }

		public override void Execute(Session session, string[] commandParts)
		{
			if (commandParts.Length < 2)
			{
				Console.WriteLine("A subcommand was expected but not specified.");
			}
			else
			{
				var subcommand = commandParts[1];
				if (subcommand == "add")
				{
					throw new NotImplementedException();
				}
				else if (subcommand == "commit")
				{
					throw new NotImplementedException();
				}
				else if (subcommand == "list")
				{
					throw new NotImplementedException();
				}
				else if (subcommand == "remove")
				{
					throw new NotImplementedException();
				}
				else
				{
					Console.WriteLine("Unrecognized subcommand: " + subcommand + ".");
				}
			}
		}

	}
}
