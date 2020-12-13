namespace Entrippy.Fitting.Impl
{
	public class FloatingFitters :
		IFitter<float>, IInverseFitter<float>,
		IFitter<double>, IInverseFitter<double>,
		IFitter<decimal>, IInverseFitter<decimal>
	{
		public static FloatingFitters Instance { get; } = new FloatingFitters();

		public float Fit(float a, float b, double t)
		{
			return (float) (a + (b - a) * t);
		}

		public double Fit(double a, double b, double t)
		{
			return a + (b - a) * t;
		}

		public decimal Fit(decimal a, decimal b, double t)
		{
			return a + (b - a) * (decimal) t;
		}

		public double InverseFit(float a, float b, float value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(double a, double b, double value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(decimal a, decimal b, decimal value)
		{
			return (double) ((value - a) / (b - a));
		}
	}
}