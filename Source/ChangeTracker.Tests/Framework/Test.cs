using System;

namespace ChangeTracker.Tests.Framework
{
	public class Test
	{
		public string Name;
		private Action<TestFixture> _run;

		public Test(string name, Action<TestFixture> run)
		{
			Name = name;
			_run = run;
		}

		public void Run(TestFixture testFixture)
		{
			_run(testFixture);
		}
	}
}
