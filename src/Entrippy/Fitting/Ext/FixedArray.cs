using Entrippy.Fitting.Impl;

namespace Entrippy.Fitting
{
	public static class ExtFixedArrayFitter
	{
		public static IFitter<T[]> ToFixedArray<T>(this IFitter<T> @this)
		{
			return new FixedArrayFitter<T>(@this);
		}
	}
}