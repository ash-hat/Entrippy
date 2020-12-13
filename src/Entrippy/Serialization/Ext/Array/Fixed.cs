namespace Entrippy.Serialization
{
	public static class ExtFixedArraySerializer
	{
		public static FixedArraySerializer<T> ToFixedArray<T>(this ISerializer<T> @this, int length)
		{
			return new FixedArraySerializer<T>(@this, length);
		}
	}
}