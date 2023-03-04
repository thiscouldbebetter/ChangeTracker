using System;
using System.IO;
using System.Linq;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandWrite : Command
	{
		public CommandWrite(IInputOutputText inputOutput) : base("write", inputOutput)
		{}

		public override void Execute(Session session, string[] commandParts)
		{
			if (commandParts.Length < 3)
			{
				Console.WriteLine("Too few arguments specified.");
			}
			else
			{
				var filePath = commandParts[1];
				var fileContentsAsTokens = commandParts.ToList().Skip(2);
				var fileContentsAsString = string.Join(" ", fileContentsAsTokens);

				File.WriteAllText(filePath, fileContentsAsString);
			}
		}

	}
}
