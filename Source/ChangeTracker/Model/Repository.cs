using System;
using System.Collections.Generic;

namespace ChangeTracker.Model
{
	public class Repository
	{
		public string PathRoot { get; set; }
		public List<ChangeGroup> ChangeGroupsForBranchesAll { get; set; }
		public List<Branch> Branches { get; set; }

		public Repository(string pathRoot)
		{
			PathRoot = pathRoot;

			var branchDefault = new Branch();
			Branches = new List<Branch>() { branchDefault };

			ChangeGroupsForBranchesAll = new List<ChangeGroup>();
		}

		public void WriteToFilesystem()
		{
			foreach (var changeGroup in ChangeGroupsForBranchesAll)
			{
				changeGroup.WriteToFilesystemForRepository(this);
			}

			foreach (var branch in Branches)
			{
				branch.WriteToFilesystemForRepository(this);
			}
		}
	}
}
