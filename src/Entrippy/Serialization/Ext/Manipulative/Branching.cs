using ADepIn;

namespace Entrippy.Serialization
{
	public static class ExtBranchingSerializer
	{
		public static BranchingSerializer<T> ToBranching<T>(this ISerializer<T> @this, Mapper<T, bool> @if, ISerializer<T> then)
		{
			return new BranchingSerializer<T>(@if, then, @this);
		}
	}
}