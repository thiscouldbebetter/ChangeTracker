using ChangeTracker.Tests.Framework;
using ChangeTracker.Tests.Tests;

namespace ChangeTracker.Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			var testRunner = new TestRunner
			(
				new TestFixture[]
				{
					new TestFixtureMain()
				}
			);

			testRunner.RunTests();
		}
	}
}
