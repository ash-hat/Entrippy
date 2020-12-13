namespace Entrippy.Fitting
{
	public class NewestFitter<T> : IFitter<T>, IInverseFitter<T>
	{
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
