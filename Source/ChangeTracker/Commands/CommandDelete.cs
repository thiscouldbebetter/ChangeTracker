using System;
using System.IO;
using System.Linq;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandDelete : Command
	{
		public CommandDelete(IInputOutputText inputOutput) : base("delete", inputOutput)
		{}

		public override void Execute(Session session, string[] commandParts)
		{
			if (commandParts.Length != 2)
			{
				Console.WriteLine("Wrong number of arguments specified.");
			}
			else
			{
				var filePath = commandParts[1];

				File.Delete(filePath);
			}
		}

	}
}
