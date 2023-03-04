namespace ChangeTracker.Model
{
	public class Change
	{
		public string FilePath { get; set; }
		public ChangeType Type { get; set; }
		public string Content { get; set; }
	}
}
