using ADepIn;
using Entrippy.Conversion;

namespace Entrippy.Serialization
{
	public static class ExtConverterSerializer
	{
		public static ConverterSerializer<TValue, TConverted> ToConverter<TValue, TConverted>(this ISerializer<TConverted> @this, IConverter<TConverted, TValue> value, IConverter<TValue, TConverted> converted)
		{
			return new ConverterSerializer<TValue, TConverted>(@this, value, converted);
		}
	}
}