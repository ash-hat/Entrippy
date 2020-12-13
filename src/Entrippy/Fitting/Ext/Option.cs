using ADepIn;
using Entrippy.Fitting;

namespace Entrippy.Fitting
{
	public static class ExtOptionFitter
	{
		public static IFitter<Option<T>> ToOption<T>(this IFitter<T> @this)
		{
			return new OptionFitter<T>(@this);
		}
	}
}