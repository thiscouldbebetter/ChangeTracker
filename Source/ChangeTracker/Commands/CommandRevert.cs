using System;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandRevert : Command
	{
		public CommandRevert(IInputOutputText inputOutput) : base("revert", inputOutput)
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
				if (subcommand == "list")
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
