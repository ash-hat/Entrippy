namespace Entrippy.Serialization
{
	public static class ExtStringSerializer
	{
		public static StringSerializer ToString(this ISerializer<char[]> @this)
		{
			return new StringSerializer(@this);
		}
	}
}