using System;

namespace ChangeTracker.Tests.Framework
{
	public class Assert
	{
		public static void AreEqual(string expected, string actual)
		{
			if (actual != expected)
			{
				throw new Exception("Expected: '" + expected + "', but was: '" + actual + "'.");
			}
		}

		public static void IsFalse(bool valueToCheck)
		{
			if (valueToCheck != false)
			{
				throw new Exception("Expected: false, but was: true.");
			}
		}

		public static void IsNotNull(object valueToCheck)
		{
			if (valueToCheck == null)
			{
				throw new Exception("Expected: not null, but was: null.");
			}
		}

		public static void IsNull(object valueToCheck)
		{
			if (valueToCheck != null)
			{
				throw new Exception("Expected: null, but was: not null.");
			}
		}

		public static void IsTrue(bool valueToCheck)
		{
			if (valueToCheck != true)
			{
				throw new Exception("Expected: true, but was: false.");
			}
		}

	}
}
