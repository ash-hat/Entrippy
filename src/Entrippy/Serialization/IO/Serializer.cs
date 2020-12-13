using System;

namespace Entrippy.Serialization
{
	public class Serializer : IPackedWriter
	{
		private byte[] _bits;
		private byte[] _bytes;

		private int _bitsUsed;
		private int _bytesUsed;

		private int BitBlockIndex => _bitsUsed / PackedBuffer.BITS_PER_BYTE;
		private int BitIndex => _bitsUsed % PackedBuffer.BITS_PER_BYTE;
		private int BitBlocksUsed
		{
			get
			{
				var bitBlocks = BitBlockIndex;
				if (BitIndex != 0)
				{
					++bitBlocks;
				}

				return bitBlocks;
			}
		}

		public PackedBuffer Data
		{
			get
			{
				var trailingBits = (byte) (PackedBuffer.BITS_PER_BYTE - BitIndex);
				var bitSegment = new ArraySegment<byte>(_bits, 0, BitBlocksUsed);
				var byteSegment = new ArraySegment<byte>(_bytes, 0,  _bytesUsed);
				
				return new PackedBuffer(trailingBits, bitSegment, byteSegment);
			}
		}

		public Serializer()
		{
			_bits = new byte[1024];
			_bytes = new byte[1024];

			Clear();
		}

		private void ExpandIfNeeded<T>(ref T[] array, int used)
		{
			if (used == array.Length)
			{
				Array.Resize(ref array, 2 * array.Length);
			}
		}

		public void Clear()
		{
			_bytesUsed = _bitsUsed = 0;
		}

		public void Write(bool value)
		{
			var blockIndex = BitBlockIndex;
			ExpandIfNeeded(ref _bits, blockIndex);

			if (value)
			{
				var bitFlag = (byte) (1 << BitIndex);

				ref var block = ref _bits[blockIndex];
				block |= bitFlag;
			}

			++_bitsUsed;
		}

		public void Write(byte value)
		{
			ExpandIfNeeded(ref _bytes, _bytesUsed);

			_bytes[_bytesUsed++] = value;
		}
	}
}