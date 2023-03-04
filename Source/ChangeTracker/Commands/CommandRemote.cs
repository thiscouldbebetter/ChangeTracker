using System;
using System.IO;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandRemote : Command
	{
		public CommandRemote(IInputOutputText inputOutput) : base("remote", inputOutput)
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
				if (subcommand == "copy")
				{
					throw new NotImplementedException();
				}
				else if (subcommand == "set")
				{
					throw new NotImplementedException();
				}
				else if (subcommand == "pull")
				{
					throw new NotImplementedException();
				}
				else if (subcommand == "push")
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
