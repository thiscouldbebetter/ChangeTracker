using System;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandHelp : Command
	{
		public CommandHelp(IInputOutputText inputOutput) : base("help", inputOutput)
		{ }

		public override void Execute(Session session, string[] commandParts)
		{
			var linesToWrite = new string[]
			{
				"Commands",
				"========",
				"?, help - Show this help message.",

				"exit, quit - Quit.",

				"branch",
				"    list - List all branches.",
				"    current - Display the name of the current branch.",
				"    select <branchName> - Switch to the specified existing branch.",
				"    create <branchName> - Create a branch with the specified name.",
				"    delete <branchName> - Delete the specified branch.",

				"changes - List all files changed since the last commit.",

				"commit",
				"    list - List past commits on the current branch, in reverse chronological order.",

				"ignore",
				"    list - List file or directory paths never to be included in the repository.",
				"    add <path> - Ignore the specified file or directory path.",
				"    remove <path> - Stop ignoring the specified file or directory path.",

				"repository",
				"    create - Create a new change tracker repository in the current directory.",
				"    destroy - Remove any change tracker repository from the current directory.",

				"remote",
				"    copy <remoteRepositoryPath> - Copy an existing repository hosted at the specfied directory path.",
				"    set <remoteRepositoryPath> - Set the repository targeted by the pull and push commands.",
				"    pull - Copy any remotely updated branches and commits from the currently targeted repository to the local one.",
				"    push - Push locally updated branches and commits to the currently targeted repository from the local one.",

				"revert",
				"    all [<commitId>] - Restore all files to their state at the specified commit, or latest if none specified.",
				"    path <path> [<commitId>] - Restore files at or under the specified path.",

				"staged",
				"    list - List all staged changes.",
				"    add <path> - Add the specified file or directory to the changes staged for commit.",
				"    remove <path> - Remove the specified file or directory from changes staged for commit.",
				"    commit [\"<comment>\"] - Commit the staged changes to the current branch, optionally with a specified comment.",

				"user",
				"    set <username> - Set the username under which commits will be logged.",
				"    get - Get the current username under which commits will be logged."
			};

			foreach (var line in linesToWrite)
			{
				Console.WriteLine(line);
			}
		}

	}
}
