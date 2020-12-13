namespace Entrippy.Conversion
{
	public class DoubleConverter : IConverter<float, double>, IConverter<double, double>, IConverter<decimal, double>
	{
		public double Convert(float value)
		{
			return value;
		}

		public double Convert(double value)
		{
			return value;
		}

		public double Convert(decimal value)
		{
			return (double) value;
		}
	}
}