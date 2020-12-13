namespace Entrippy.Fitting.Impl
{
	public class NewestFitter<T> : IFitter<T>, IInverseFitter<T>
	{
		public static NewestFitter<T> Instance { get; } = new NewestFitter<T>();

		public T Fit(T a, T b, double t)
		{
			return b;
		}

		public double InverseFit(T a, T b, T value)
		{
			return 1;
		}
	}
}
