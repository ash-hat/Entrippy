namespace Entrippy.Conversion
{
	public class FloatConverter : IConverter<float, float>, IConverter<double, float>, IConverter<decimal, float>
	{
		public float Convert(float value)
		{
			return value;
		}

		public float Convert(double value)
		{
			return (float) value;
		}

		public float Convert(decimal value)
		{
			return (float) value;
		}
	}
}