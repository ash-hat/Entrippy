using ADepIn;

namespace Entrippy.Fitting.Impl
{
	public class OptionFitter<T> : IFitter<Option<T>>
	{
		private readonly IFitter<T> _fitter;

		public OptionFitter(IFitter<T> fitter)
		{
			_fitter = fitter;
		}

		public Option<T> Fit(Option<T> a, Option<T> b, double t)
		{
			return a.MatchSome(out var aValue) && b.MatchSome(out var bValue)
				? Option.Some(_fitter.Fit(aValue, bValue, t))
				: Option.None<T>();
		}
	}
}
