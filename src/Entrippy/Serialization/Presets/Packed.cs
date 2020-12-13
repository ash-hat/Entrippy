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
						.ToBranching(x => x < sbyte.MinValue || sbyte.MaxValue < x, new UnmanagedSerializer<short>());
			UShort = TruncatedSerializers.UShortAsByte
						.ToBranching(x => x > byte.MaxValue, new UnmanagedSerializer<ushort>());

			Int = TruncatedSerializers.IntAsSByte
						.ToBranching(x => x < sbyte.MinValue || sbyte.MaxValue < x, TruncatedSerializers.IntAsShort)
						.ToBranching(x => x < short.MinValue || short.MaxValue < x, new UnmanagedSerializer<int>());
			UInt = TruncatedSerializers.UIntAsByte
						.ToBranching(x => x > byte.MaxValue, TruncatedSerializers.UIntAsUShort)
						.ToBranching(x => x > ushort.MaxValue, new UnmanagedSerializer<uint>());

			Long = TruncatedSerializers.LongAsSByte
						.ToBranching(x => x < sbyte.MinValue || sbyte.MaxValue < x, TruncatedSerializers.LongAsShort)
						.ToBranching(x => x < short.MinValue || short.MaxValue < x, TruncatedSerializers.LongAsInt
							.ToBranching(x => x < int.MinValue || int.MaxValue < x, new UnmanagedSerializer<long>()));
			ULong = TruncatedSerializers.ULongAsByte
						.ToBranching(x => x > byte.MaxValue, TruncatedSerializers.ULongAsUShort)
						.ToBranching(x => x > ushort.MaxValue, TruncatedSerializers.ULongAsUInt
							.ToBranching(x => x > uint.MaxValue, new UnmanagedSerializer<ulong>()));
		}
	}
}
