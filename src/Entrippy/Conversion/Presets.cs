using Entrippy.Conversion.Impl;

namespace Entrippy.Conversion
{
	public static class Converters
	{
		public static SByteConverter SByte { get; } = new SByteConverter();
		public static ByteConverter Byte { get; } = new ByteConverter();
		public static UShortConverter UShort { get; } = new UShortConverter();
		public static ShortConverter Short { get; } = new ShortConverter();
		public static IntConverter Int { get; } = new IntConverter();
		public static UIntConverter UInt { get; } = new UIntConverter();
		public static LongConverter Long { get; } = new LongConverter();
		public static ULongConverter ULong { get; } = new ULongConverter();

		public static FloatConverter Float { get; } = new FloatConverter();
		public static DoubleConverter Double { get; } = new DoubleConverter();
		public static DecimalConverter Decimal { get; } = new DecimalConverter();
	}
}
