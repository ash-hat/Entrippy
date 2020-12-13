using Entrippy.Conversion;
namespace Entrippy.Serialization
{
	public class ConverterSerializer<TValue, TConverted> : ISerializer<TValue>
	{
		private readonly ISerializer<TConverted> _serializer;
		private readonly IConverter<TConverted, TValue> _value;
		private readonly IConverter<TValue, TConverted> _converted;

		public ConverterSerializer(ISerializer<TConverted> serializer, IConverter<TConverted, TValue> value, IConverter<TValue, TConverted> converted)
		{
			_serializer = serializer;
			_value = value;
			_converted = converted;
		}

		public TValue Deserialize(IPackedReader reader)
		{
			var converted = _serializer.Deserialize(reader);
			return _value.Convert(converted);
		}

		public void Serialize(IPackedWriter writer, TValue value)
		{
			var converted = _converted.Convert(value);
			_serializer.Serialize(writer, converted);
		}
	}
}
