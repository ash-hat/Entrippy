namespace Entrippy.Serialization
{
	public static class ExtOptionSerializer
	{
		public static OptionSerializer<TValue> ToOption<TValue>(this ISerializer<TValue> @this)
		{
			return new OptionSerializer<TValue>(@this);
		}
	}
}