namespace Entrippy.Serialization
{
	public static class ExtDynamicArraySerializer
	{
		public static DynamicArraySerializer<T> ToDynamicArray<T>(this ISerializer<T> @this, ISerializer<int> length)
		{
			return new DynamicArraySerializer<T>(@this, length);
		}
	}
}