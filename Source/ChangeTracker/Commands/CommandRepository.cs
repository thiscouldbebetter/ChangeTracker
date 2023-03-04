using System;
using System.IO;
using ChangeTracker.InputOutput;
using ChangeTracker.Model;

namespace ChangeTracker.Commands
{
	class CommandRepository : Command
	{
		public const string DirectoryNameChangeTracker = ".ChangeTracker";

		public CommandRepository(IInputOutputText inputOutput) : base("repository", inputOutput)
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
				if (subcommand == "create")
				{
					var changeTrackingIsEnabled = ChangeTrackingIsEnabled();

					if (changeTrackingIsEnabled)
					{
						_inputOutputText.WriteLine(
							"Cannot create a repository here.  An ancestor directory already contains a '"
							+ DirectoryNameChangeTracker + "' subdirectory."
						);
					}
					else
					{
						var directoryToCreatePath = DirectoryNameChangeTracker;
						Directory.CreateDirectory(directoryToCreatePath);
						var repository = new Repository(directoryToCreatePath);
						repository.WriteToFilesystem();
						session.BranchLocal = repository.Branches[0];
					}
				}
				else if (subcommand == "destroy")
				{
					var changeTrackingIsEnabled = ChangeTrackingIsEnabled();

					if (changeTrackingIsEnabled == false)
					{
						_inputOutputText.WriteLine(
							"No directory named '" + DirectoryNameChangeTracker + "' exists in any ancestor directory."
						);
					}
					else
					{
						var changeTrackingDirectoryPath = ChangeTrackerDirectoryPathFind();
						Directory.Delete(changeTrackingDirectoryPath, recursive: true);
						session.BranchLocal = null;
					}
				}
				else
				{
					Console.WriteLine("Unrecognized subcommand: " + subcommand + ".");
				}
			}
		}

		// Helper methods.

		public static bool ChangeTrackingIsEnabled()
		{
			var changeTrackingDirectoryPath = ChangeTrackerDirectoryPathFind();
			var doesDirectoryExist = (changeTrackingDirectoryPath != null);
			return doesDirectoryExist;
		}

		public static string ChangeTrackerDirectoryPathFind()
		{
			string returnValue = null;

			var isAnyAncestorDirectoryUnderChangeTrackingSoFar = false;
			var directoryToCheckPath = "./";
			while (isAnyAncestorDirectoryUnderChangeTrackingSoFar)
			{
				directoryToCheckPath = directoryToCheckPath + "/..";
				var changeTrackerDirectoryPath = directoryToCheckPath + "/" + DirectoryNameChangeTracker + "/";
				var changeTrackerDirectoryExists =
					Directory.Exists(changeTrackerDirectoryPath);
				if (changeTrackerDirectoryExists)
				{
					returnValue = Path.GetFullPath(changeTrackerDirectoryPath);
					break;
				}
			}

			return returnValue;
		}

	}
}
