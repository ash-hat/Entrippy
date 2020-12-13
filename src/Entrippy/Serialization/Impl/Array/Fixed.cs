using System;
namespace Entrippy.Serialization
{
	public class FixedArraySerializer<TValue> : ISerializer<TValue[]>
	{
		private readonly ISerializer<TValue> _serializer;
		private readonly int _length;

		public FixedArraySerializer(ISerializer<TValue> serializer, int length)
		{
			_serializer = serializer;
			_length = length;
		}

		public TValue[] Deserialize(IPackedReader reader)
		{
			var buffer = new TValue[_length];
			for (var i = 0; i < _length; ++i)
			{
				buffer[i] = _serializer.Deserialize(reader);
			}

			return buffer;
		}

		public void Serialize(IPackedWriter writer, TValue[] value)
		{
			if (value.Length != _length)
			{
				throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Array length must be equal to the fixed size: " + _length);
			}

			for (var i = 0; i < _length; ++i)
			{
				_serializer.Serialize(writer, value[i]);
			}
		}
	}
}
