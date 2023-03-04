using System;
using System.Collections.Generic;

namespace ChangeTracker.Model
{
	public class ChangeGroup
	{
		public User UserCommitting { get; set; }
		public DateTime TimeCommitted { get; set; }
		public List<Change> Changes { get; set; }
		public ChangeGroup Predecessor { get; set; }

		public void WriteToFilesystemForRepository(Repository repository)
		{
			throw new NotImplementedException();
		}
	}
}
