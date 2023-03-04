using System.Linq;
using ChangeTracker.Model;

namespace ChangeTracker
{
	class Program
	{
		public static void Main(string[] args)
		{
			var session = new Session();
			if (args.Length == 0)
			{
				session.RunInteractively();
			}
			else
			{
				var commandPartsMinusProgramName =
					args.ToList().Skip(1).ToArray();
				session.CommandParseAndRun(commandPartsMinusProgramName);
			}
		}
	}
}
