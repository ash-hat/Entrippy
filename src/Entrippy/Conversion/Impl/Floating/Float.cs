namespace Entrippy.Conversion.Impl
{
	public class FloatConverter : IConverter<float, float>, IConverter<double, float>, IConverter<decimal, float>
	{
		public static FloatConverter Instance { get; } = new FloatConverter();

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