using ADepIn;
using Entrippy.Differentiation.Impl;

namespace Entrippy.Differentiation
{
	public static class ExtFixedArrayDifferentiator
	{
		public static IDifferentiator<TValue[], Option<TDelta>[]> ToArray<TValue, TDelta>(this IDifferentiator<TValue, TDelta> @this)
		{
			return new FixedArrayDifferentiator<TValue, TDelta>(@this);
		}
	}
}