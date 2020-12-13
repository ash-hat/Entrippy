namespace Entrippy.Conversion.Impl
{
	public class UShortConverter :
		IConverter<sbyte, ushort>, IConverter<byte, ushort>,
		IConverter<short, ushort>, IConverter<ushort, ushort>,
		IConverter<int, ushort>, IConverter<uint, ushort>,
		IConverter<long, ushort>, IConverter<ulong, ushort>
	{
		private readonly IConverter<sbyte, ushort> _sbyte;
		private readonly IConverter<short, ushort> _short;
		private readonly IConverter<int, ushort> _int;
		private readonly IConverter<uint, ushort> _uint;
		private readonly IConverter<long, ushort> _long;
		private readonly IConverter<ulong, ushort> _ulong;

		public UShortConverter()
		{
			var builder = new ConstrainedConverterBuilder<ushort>(ushort.MinValue, ushort.MaxValue);

			_sbyte = builder.Create<sbyte>((x, y) => x <= y, (x, y) => x >= y, x => (ushort) x);
			_short = builder.Create<short>((x, y) => x <= y, (x, y) => x >= y, x => (ushort) x);
			_int = builder.Create<int>((x, y) => x <= y, (x, y) => x >= y, x => (ushort) x);
			_uint = builder.Create<uint>((x, y) => x <= y, (x, y) => x >= y, x => (ushort) x);
			_long = builder.Create<long>((x, y) => x <= y, (x, y) => x >= y, x => (ushort) x);
			_ulong = builder.Create<ulong>((x, y) => x < 0 || (ulong) x <= y, (x, y) => x >= 0 && (ulong) x >= y, x => (ushort) x);
		}

		public ushort Convert(sbyte value)
		{
			return _sbyte.Convert(value);
		}

		public ushort Convert(byte value)
		{
			return value;
		}

		public ushort Convert(short value)
		{
			return _short.Convert(value);
		}

		public ushort Convert(ushort value)
		{
			return value;
		}

		public ushort Convert(int value)
		{
			return _int.Convert(value);
		}

		public ushort Convert(uint value)
		{
			return _uint.Convert(value);
		}

		public ushort Convert(long value)
		{
			return _long.Convert(value);
		}

		public ushort Convert(ulong value)
		{
			return _ulong.Convert(value);
		}
	}
}