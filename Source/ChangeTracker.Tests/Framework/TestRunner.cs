using System;

namespace ChangeTracker.Tests.Framework
{
	public class TestRunner
	{
		private TestFixture[] _testFixtures;

		public TestRunner(TestFixture[] testFixtures)
		{
			_testFixtures = testFixtures;
		}

		public void RunTests()
		{
			var fixtureCount = _testFixtures.Length;

			Console.WriteLine("Running tests in " + fixtureCount + " fixture(s)...");

			foreach (var testFixture in _testFixtures)
			{
				testFixture.RunTests();
			}

			Console.WriteLine("...done running tests in " + fixtureCount + " fixture(s).");
		}
	}
}
