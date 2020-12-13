using ADepIn;
using Entrippy.Differentiation;

namespace Entrippy.Differentiation
{
	public static class ExtOptionDifferentiator
	{
		public static OptionDifferentiator<TValue, TDelta> ToOption<TValue, TDelta>(this IDifferentiator<TValue, TDelta> @this)
		{
			return new OptionDifferentiator<TValue, TDelta>(@this);
		}
	}
}