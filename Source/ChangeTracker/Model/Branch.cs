using System;

namespace ChangeTracker.Model
{
	public class Branch
	{
		public const string NameDefault = "main";

		public string Name { get; set; }
		public ChangeGroup ChangeGroupLatest { get; set; }

		public Branch() : this(NameDefault)
		{ }

		public Branch(string name)
		{
			Name = name;
		}

		public void WriteToFilesystemForRepository(Repository repository)
		{
			throw new NotImplementedException();
		}
	}
}
