namespace Entrippy.Conversion
{
	public class DecimalConverter : IConverter<float, decimal>, IConverter<double, decimal>, IConverter<decimal, decimal>
	{
		public decimal Convert(float value)
		{
			return (decimal) value;
		}

		public decimal Convert(double value)
		{
			return (decimal) value;
		}

		public decimal Convert(decimal value)
		{
			return value;
		}
	}
}