namespace Entrippy.Serialization
{
	public static class ExtVersionSerializer
	{
		public static VersionSerializer ToVersion(this ISerializer<int> @this)
		{
			return new VersionSerializer(@this);
		}
	}
}