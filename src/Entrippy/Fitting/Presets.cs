using Entrippy.Fitting.Impl;

namespace Entrippy.Fitting
{
	public static class Fitters
	{
		public static IntegralFitters Integral => IntegralFitters.Instance;
		public static FloatingFitters Floating => FloatingFitters.Instance;

		public static NewestFitter<T> Newest<T>()
		{
			return NewestFitter<T>.Instance;
		}

		public static OldestFitter<T> Oldest<T>()
		{
			return OldestFitter<T>.Instance;
		}
	}
}
