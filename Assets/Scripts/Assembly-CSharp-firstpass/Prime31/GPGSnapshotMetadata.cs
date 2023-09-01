namespace Prime31
{
	public class GPGSnapshotMetadata
	{
		public double lastModifiedTimestamp;

		public string description;

		public string name;

		public string deviceName;

		public long playedTime;

		public string title;

		public long progressValue;

		public override string ToString()
		{
			return JsonFormatter.prettyPrint(Json.encode(this));
		}
	}
}
