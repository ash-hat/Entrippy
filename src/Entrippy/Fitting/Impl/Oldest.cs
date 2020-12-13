namespace Entrippy.Fitting
{
	public class OldestFitter<T> : IFitter<T>, IInverseFitter<T>
	{
		public T Fit(T a, T b, double t)
		{
			return a;
		}

		public double InverseFit(T a, T b, T value)
		{
			return 0;
		}
	}
}
