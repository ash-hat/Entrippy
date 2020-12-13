namespace Entrippy.Serialization
{
	public static class PackedSerializers
	{
		public static ISerializer<short> Short { get; }
		public static ISerializer<ushort> UShort { get; }

		public static ISerializer<int> Int { get; }
		public static ISerializer<uint> UInt { get; }

		public static ISerializer<long> Long { get; }
		public static ISerializer<ulong> ULong { get; }

		static PackedSerializers()
		{
			Short = TruncatedSerializers.ShortAsSByte
						.ToBranching(x => x < sbyte.MinValue || sbyte.MaxValue < x, UnmanagedSerializer<short>.Instance);
			UShort = TruncatedSerializers.UShortAsByte
						.ToBranching(x => x > byte.MaxValue, UnmanagedSerializer<ushort>.Instance);

			Int = TruncatedSerializers.IntAsSByte
						.ToBranching(x => x < sbyte.MinValue || sbyte.MaxValue < x, TruncatedSerializers.IntAsShort)
						.ToBranching(x => x < short.MinValue || short.MaxValue < x, UnmanagedSerializer<int>.Instance);
			UInt = TruncatedSerializers.UIntAsByte
						.ToBranching(x => x > byte.MaxValue, TruncatedSerializers.UIntAsUShort)
						.ToBranching(x => x > ushort.MaxValue, UnmanagedSerializer<uint>.Instance);

			Long = TruncatedSerializers.LongAsSByte
						.ToBranching(x => x < sbyte.MinValue || sbyte.MaxValue < x, TruncatedSerializers.LongAsShort)
						.ToBranching(x => x < short.MinValue || short.MaxValue < x, TruncatedSerializers.LongAsInt
							.ToBranching(x => x < int.MinValue || int.MaxValue < x, UnmanagedSerializer<long>.Instance));
			ULong = TruncatedSerializers.ULongAsByte
						.ToBranching(x => x > byte.MaxValue, TruncatedSerializers.ULongAsUShort)
						.ToBranching(x => x > ushort.MaxValue, TruncatedSerializers.ULongAsUInt
							.ToBranching(x => x > uint.MaxValue, UnmanagedSerializer<ulong>.Instance));
		}
	}
}
