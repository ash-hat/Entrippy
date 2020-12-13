namespace Entrippy.Serialization
{
	public class Deserializer : IPackedReader
	{
		private PackedBuffer _buffer;

		private int _bitsUsed;
		private int _bytesUsed;

		private int BitBlockIndex => _bitsUsed / PackedBuffer.BITS_PER_BYTE;
		private int BitIndex => _bitsUsed % PackedBuffer.BITS_PER_BYTE;

		public Deserializer(PackedBuffer buffer)
		{
			_buffer = buffer;
		}

		public void Reset(PackedBuffer buffer)
		{
			_buffer = buffer;

			_bitsUsed = 0;
			_bytesUsed = 0;
		}

		public bool ReadBit()
		{
			var bits = _buffer.Bits;
			var block = bits.Array![bits.Offset + BitBlockIndex];
			var flag = 1 << BitIndex;

			return (block & flag) == flag;
		}

		public byte ReadByte()
		{
			var bytes = _buffer.Bytes;
			return bytes.Array![bytes.Offset + _bytesUsed++];
		}
	}
}