using Entrippy.Conversion;

namespace Entrippy.Serialization
{
	public static class TruncatedSerializers
	{
		public static ConverterSerializer<short, sbyte> ShortAsSByte { get; } = new ConverterSerializer<short, sbyte>(new UnmanagedSerializer<sbyte>(), new ShortConverter(), new SByteConverter());
		public static ConverterSerializer<short, byte> ShortAsByte { get; }  = new ConverterSerializer<short, byte>(new UnmanagedSerializer<byte>(), new ShortConverter(), new ByteConverter());

		public static ConverterSerializer<ushort, byte> UShortAsByte { get; }  = new ConverterSerializer<ushort, byte>(new UnmanagedSerializer<byte>(), new UShortConverter(), new ByteConverter());

		public static ConverterSerializer<int, sbyte> IntAsSByte { get; } = new ConverterSerializer<int, sbyte>(new UnmanagedSerializer<sbyte>(), new IntConverter(), new SByteConverter());
		public static ConverterSerializer<int, byte> IntAsByte { get; } = new ConverterSerializer<int, byte>(new UnmanagedSerializer<byte>(), new IntConverter(), new ByteConverter());
		public static ConverterSerializer<int, short> IntAsShort { get; } = new ConverterSerializer<int, short>(new UnmanagedSerializer<short>(), new IntConverter(), new ShortConverter());
		public static ConverterSerializer<int, ushort> IntAsUShort { get; } = new ConverterSerializer<int, ushort>(new UnmanagedSerializer<ushort>(), new IntConverter(), new UShortConverter());

		public static ConverterSerializer<uint, byte> UIntAsByte { get; } = new ConverterSerializer<uint, byte>(new UnmanagedSerializer<byte>(), new UIntConverter(), new ByteConverter());
		public static ConverterSerializer<uint, ushort> UIntAsUShort { get; } = new ConverterSerializer<uint, ushort>(new UnmanagedSerializer<ushort>(), new UIntConverter(), new UShortConverter());

		public static ConverterSerializer<long, sbyte> LongAsSByte { get; } = new ConverterSerializer<long, sbyte>(new UnmanagedSerializer<sbyte>(), new LongConverter(), new SByteConverter());
		public static ConverterSerializer<long, byte> LongAsByte { get; } = new ConverterSerializer<long, byte>(new UnmanagedSerializer<byte>(), new LongConverter(), new ByteConverter());
		public static ConverterSerializer<long, short> LongAsShort { get; } = new ConverterSerializer<long, short>(new UnmanagedSerializer<short>(), new LongConverter(), new ShortConverter());
		public static ConverterSerializer<long, ushort> LongAsUShort { get; } = new ConverterSerializer<long, ushort>(new UnmanagedSerializer<ushort>(), new LongConverter(), new UShortConverter());
		public static ConverterSerializer<long, int> LongAsInt { get; } = new ConverterSerializer<long, int>(new UnmanagedSerializer<int>(), new LongConverter(), new IntConverter());
		public static ConverterSerializer<long, uint> LongAsUInt { get; } = new ConverterSerializer<long, uint>(new UnmanagedSerializer<uint>(), new LongConverter(), new UIntConverter());

		public static ConverterSerializer<ulong, byte> ULongAsByte { get; } = new ConverterSerializer<ulong, byte>(new UnmanagedSerializer<byte>(), new ULongConverter(), new ByteConverter());
		public static ConverterSerializer<ulong, ushort> ULongAsUShort { get; } = new ConverterSerializer<ulong, ushort>(new UnmanagedSerializer<ushort>(), new ULongConverter(), new UShortConverter());
		public static ConverterSerializer<ulong, uint> ULongAsUInt { get; } = new ConverterSerializer<ulong, uint>(new UnmanagedSerializer<uint>(), new ULongConverter(), new UIntConverter());
	}

}
