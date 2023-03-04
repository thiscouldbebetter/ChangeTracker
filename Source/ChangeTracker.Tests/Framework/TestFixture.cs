using System;

namespace ChangeTracker.Tests.Framework
{
	public class TestFixture
	{
		public string Name;
		private Test[] _tests;

		public TestFixture(string name, Test[] tests)
		{
			Name = name;
			_tests = tests;
		}

		public void RunTests()
		{
			Console.WriteLine("Running tests in fixture '" + Name + "'...");

			var testsFailedSoFarCount = 0;

			for (var t = 0; t < _tests.Length; t++)
			{
				var test = _tests[t];

				var testPassedOrFailedMessage = "Test " + t + ", '" + test.Name + "', ";
				try
				{
					test.Run(this);
					testPassedOrFailedMessage += "passed.";
				}
				catch (Exception ex)
				{
					testPassedOrFailedMessage += "FAILED with exception: '" + ex.Message + "'.";
					testsFailedSoFarCount++;
				}

				Console.WriteLine(testPassedOrFailedMessage);
			}

			if (testsFailedSoFarCount > 0)
			{
				Console.WriteLine(testsFailedSoFarCount + " tests in fixture failed.");
			}

			Console.WriteLine("...done running tests in fixture '" + Name + "'.");
		}
	}
}
