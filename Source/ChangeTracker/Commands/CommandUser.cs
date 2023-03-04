using System;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandUser : Command
	{
		public CommandUser(IInputOutputText inputOutput) : base("user", inputOutput)
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
				if (subcommand == "get")
				{
					throw new NotImplementedException();
				}
				else if (subcommand == "set")
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
