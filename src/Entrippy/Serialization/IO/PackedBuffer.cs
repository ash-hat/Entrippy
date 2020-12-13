using System;

namespace Entrippy.Serialization
{
	public readonly struct PackedBuffer
	{
		public const byte BITS_PER_BYTE = 8;

		public byte TrailingBits { get; }

		public ArraySegment<byte> Bits { get; }

		public ArraySegment<byte> Bytes { get; }

		public PackedBuffer(byte trailingBits, ArraySegment<byte> bits, ArraySegment<byte> bytes)
		{
			TrailingBits = trailingBits;
			Bits = bits;
			Bytes = bytes;
		}
	}
}