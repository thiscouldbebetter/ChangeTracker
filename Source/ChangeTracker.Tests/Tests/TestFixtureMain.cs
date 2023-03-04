using System.Collections.Generic;
using ChangeTracker.Model;
using ChangeTracker.Tests.Framework;
using ChangeTracker.Tests.Mocks;

namespace ChangeTracker.Tests.Tests
{
	class TestFixtureMain : TestFixture
	{
		public TestFixtureMain()
			: base
			(
				"Main",
				new Test[]
				{
					new Test("EndToEnd", (testFixture) => { (testFixture as TestFixtureMain).EndToEnd(); } )
				}
			)
		{ }

		// Tests.

		public void EndToEnd()
		{
			var inputOutputText = new InputOutputTextMock();

			var session = new Session(inputOutputText);

			session.CommandParseAndRun("repository destroy");
			Assert.IsNull(session.BranchLocal);

			session.CommandParseAndRun("repository create");
			Assert.IsNotNull(session.BranchLocal);
			Assert.AreEqual(Branch.NameDefault, session.BranchLocal.Name);

			var fileContentsByPath = new Dictionary<string, string>()
			{
				{ "Test0.txt", "This is also a test!" },
				{ "Test1.txt", "This is also a test!" },
				{ "Test2.txt", "This is another test!" },
				{ "Test3.txt", "This is yet another test!" },
				{ "Test4.txt", "This is still another test!" }
			};

			foreach (var filePath in fileContentsByPath.Keys)
			{
				session.CommandParseAndRun("delete " + filePath);
				Assert.IsFalse(session.FileExistsAtPath(filePath) );

				var fileContentsToWrite = fileContentsByPath[filePath];
				session.CommandParseAndRun("write " + filePath + " " + fileContentsToWrite);

				Assert.IsTrue(session.FileExistsAtPath("Test0.txt"));
			}
		}
	}
}
