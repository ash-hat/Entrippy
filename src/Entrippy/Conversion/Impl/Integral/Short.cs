namespace Entrippy.Conversion
{
	public class ShortConverter :
		IConverter<sbyte, short>, IConverter<byte, short>,
		IConverter<short, short>, IConverter<ushort, short>,
		IConverter<int, short>, IConverter<uint, short>,
		IConverter<long, short>, IConverter<ulong, short>
	{
		private readonly IConverter<ushort, short> _ushort;
		private readonly IConverter<int, short> _int;
		private readonly IConverter<uint, short> _uint;
		private readonly IConverter<long, short> _long;
		private readonly IConverter<ulong, short> _ulong;

		public ShortConverter()
		{
			var builder = new ConstrainedConverterBuilder<short>(short.MinValue, short.MaxValue);

			_ushort = builder.Create<ushort>((x, y) => x <= y, (x, y) => x >= y, x => (short) x);
			_int = builder.Create<int>((x, y) => x <= y, (x, y) => x >= y, x => (short) x);
			_uint = builder.Create<uint>((x, y) => x <= y, (x, y) => x >= y, x => (short) x);
			_long = builder.Create<long>((x, y) => x <= y, (x, y) => x >= y, x => (short) x);
			_ulong = builder.Create<ulong>((x, y) => x < 0 || (ulong) x <= y, (x, y) => x >= 0 && (ulong) x >= y, x => (sbyte) x);
		}

		public short Convert(sbyte value)
		{
			return value;
		}

		public short Convert(byte value)
		{
			return value;
		}

		public short Convert(short value)
		{
			return value;
		}

		public short Convert(ushort value)
		{
			return _ushort.Convert(value);
		}

		public short Convert(int value)
		{
			return _int.Convert(value);
		}

		public short Convert(uint value)
		{
			return _uint.Convert(value);
		}

		public short Convert(long value)
		{
			return _long.Convert(value);
		}

		public short Convert(ulong value)
		{
			return _ulong.Convert(value);
		}
	}
}