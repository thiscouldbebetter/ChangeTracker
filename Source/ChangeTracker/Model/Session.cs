using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChangeTracker.Commands;
using ChangeTracker.InputOutput;

namespace ChangeTracker.Model
{
	public class Session
	{
		public Branch BranchLocal { get; set; }
		public Branch BranchUpstream { get; set; }
		public User UserCurrent { get; set; }

		private IInputOutputText _inputOutputText { get; }

		private readonly Dictionary<string, Command> _commandsKnownByName;

		public Session() : this(new InputOutputConsole())
		{ }

		public Session(IInputOutputText inputOutputText)
		{
			_inputOutputText = inputOutputText;

			var commandsKnown = new Command[]
			{
				new CommandBranch(_inputOutputText),
				new CommandChanges(_inputOutputText),
				new CommandCommit(_inputOutputText),
				new CommandDelete(_inputOutputText),
				new CommandIgnore(_inputOutputText),
				new CommandStaged(_inputOutputText),
				new CommandRemote(_inputOutputText),
				new CommandRepository(_inputOutputText),
				new CommandRevert(_inputOutputText),
				new CommandUser(_inputOutputText),
				new CommandWrite(_inputOutputText)
			};

			_commandsKnownByName = commandsKnown.ToDictionary(x => x.Name);
		}

		public void RunInteractively()
		{
			_inputOutputText.WriteLine("Change Tracker");
			_inputOutputText.WriteLine("==============");

			string commandText;
			var hasUserQuit = false;

			while (hasUserQuit == false)
			{
				_inputOutputText.Write("Enter a command (? for help): ");
				commandText = _inputOutputText.ReadLine();

				commandText = commandText.Trim();
				var commandParts = commandText.Split
				(
					new string[] { " " },
					StringSplitOptions.RemoveEmptyEntries
				);

				if (commandParts.Length < 1)
				{
					_inputOutputText.WriteLine("No command was specified.");
				}
				else
				{
					var commandPart0 = commandParts[0];

					if
					(
						commandPart0 == "?"
						|| commandPart0 == "help"
					)
					{
						new CommandHelp(_inputOutputText).Execute(this, commandParts);
					}
					else if
					(
						commandPart0 == "exit"
						|| commandPart0 == "quit"
					)
					{
						hasUserQuit = true;
					}
					else if (BranchLocal == null)
					{
						_inputOutputText.WriteLine(
							"No local branch exists.  Run 'repository create' to create one in the current directory."
						);
					}
					else
					{
						CommandParseAndRun(commandParts);
					}
				}
			}
		}

		// Commands.

		public void CommandParseAndRun(string commandText)
		{
			var commandParts = commandText.Split
			(
				new string[] { " " },
				StringSplitOptions.RemoveEmptyEntries
			);

			CommandParseAndRun(commandParts);
		}

		public void CommandParseAndRun(string[] commandParts)
		{
			var commandPart0 = commandParts[0];

			if (_commandsKnownByName.ContainsKey(commandPart0))
			{
				var command = _commandsKnownByName[commandPart0];
				command.Execute(this, commandParts);
			}
			else
			{
				_inputOutputText.WriteLine("Unrecognized command: " + commandPart0 + ".");
			}
		}

		// Filesystem.

		public bool FileExistsAtPath(string filePathToCheck)
		{
			return File.Exists(filePathToCheck);
		}
	}
}
