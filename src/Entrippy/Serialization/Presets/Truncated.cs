using Entrippy.Conversion;

namespace Entrippy.Serialization
{
	public static class TruncatedSerializers
	{
		public static ConverterSerializer<short, sbyte> ShortAsSByte { get; } = new ConverterSerializer<short, sbyte>(UnmanagedSerializer<sbyte>.Instance, Converters.Short, Converters.SByte);
		public static ConverterSerializer<short, byte> ShortAsByte { get; }  = new ConverterSerializer<short, byte>(UnmanagedSerializer<byte>.Instance, Converters.Short, Converters.Byte);

		public static ConverterSerializer<ushort, byte> UShortAsByte { get; }  = new ConverterSerializer<ushort, byte>(UnmanagedSerializer<byte>.Instance, Converters.UShort, Converters.Byte);

		public static ConverterSerializer<int, sbyte> IntAsSByte { get; } = new ConverterSerializer<int, sbyte>(UnmanagedSerializer<sbyte>.Instance, Converters.Int, Converters.SByte);
		public static ConverterSerializer<int, byte> IntAsByte { get; } = new ConverterSerializer<int, byte>(UnmanagedSerializer<byte>.Instance, Converters.Int, Converters.Byte);
		public static ConverterSerializer<int, short> IntAsShort { get; } = new ConverterSerializer<int, short>(UnmanagedSerializer<short>.Instance, Converters.Int, Converters.Short);
		public static ConverterSerializer<int, ushort> IntAsUShort { get; } = new ConverterSerializer<int, ushort>(UnmanagedSerializer<ushort>.Instance, Converters.Int, Converters.UShort);

		public static ConverterSerializer<uint, byte> UIntAsByte { get; } = new ConverterSerializer<uint, byte>(UnmanagedSerializer<byte>.Instance, Converters.UInt, Converters.Byte);
		public static ConverterSerializer<uint, ushort> UIntAsUShort { get; } = new ConverterSerializer<uint, ushort>(UnmanagedSerializer<ushort>.Instance, Converters.UInt, Converters.UShort);

		public static ConverterSerializer<long, sbyte> LongAsSByte { get; } = new ConverterSerializer<long, sbyte>(UnmanagedSerializer<sbyte>.Instance, Converters.Long, Converters.SByte);
		public static ConverterSerializer<long, byte> LongAsByte { get; } = new ConverterSerializer<long, byte>(UnmanagedSerializer<byte>.Instance, Converters.Long, Converters.Byte);
		public static ConverterSerializer<long, short> LongAsShort { get; } = new ConverterSerializer<long, short>(UnmanagedSerializer<short>.Instance, Converters.Long, Converters.Short);
		public static ConverterSerializer<long, ushort> LongAsUShort { get; } = new ConverterSerializer<long, ushort>(UnmanagedSerializer<ushort>.Instance, Converters.Long, Converters.UShort);
		public static ConverterSerializer<long, int> LongAsInt { get; } = new ConverterSerializer<long, int>(UnmanagedSerializer<int>.Instance, Converters.Long, Converters.Int);
		public static ConverterSerializer<long, uint> LongAsUInt { get; } = new ConverterSerializer<long, uint>(UnmanagedSerializer<uint>.Instance, Converters.Long, Converters.UInt);

		public static ConverterSerializer<ulong, byte> ULongAsByte { get; } = new ConverterSerializer<ulong, byte>(UnmanagedSerializer<byte>.Instance, Converters.ULong, Converters.Byte);
		public static ConverterSerializer<ulong, ushort> ULongAsUShort { get; } = new ConverterSerializer<ulong, ushort>(UnmanagedSerializer<ushort>.Instance, Converters.ULong, Converters.UShort);
		public static ConverterSerializer<ulong, uint> ULongAsUInt { get; } = new ConverterSerializer<ulong, uint>(UnmanagedSerializer<uint>.Instance, Converters.ULong, Converters.UInt);
	}

}
