using Entrippy.Serialization;

namespace Entrippy.Serialization
{
	public class DynamicArraySerializer<TValue> : ISerializer<TValue[]>
	{
		private readonly ISerializer<TValue> _serializer;
		private readonly ISerializer<int> _length;

		public DynamicArraySerializer(ISerializer<TValue> serializer, ISerializer<int> length)
		{
			_serializer = serializer;
			_length = length;
		}

		public TValue[] Deserialize(IPackedReader reader)
		{
			var length = _length.Deserialize(reader);

			var buffer = new TValue[length];
			for (var i = 0; i < buffer.Length; ++i)
			{
				buffer[i] = _serializer.Deserialize(reader);
			}

			return buffer;
		}

		public void Serialize(IPackedWriter writer, TValue[] value)
		{
			_length.Serialize(writer, value.Length);

			for (var i = 0; i < value.Length; ++i)
			{
				_serializer.Serialize(writer, value[i]);
			}
		}
	}
}
