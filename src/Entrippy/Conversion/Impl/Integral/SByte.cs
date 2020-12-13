namespace Entrippy.Conversion
{
	public class SByteConverter :
		IConverter<sbyte, sbyte>, IConverter<byte, sbyte>,
		IConverter<short, sbyte>, IConverter<ushort, sbyte>,
		IConverter<int, sbyte>, IConverter<uint, sbyte>,
		IConverter<long, sbyte>, IConverter<ulong, sbyte>
	{
		private readonly IConverter<byte, sbyte> _byte;
		private readonly IConverter<short, sbyte> _short;
		private readonly IConverter<ushort, sbyte> _ushort;
		private readonly IConverter<int, sbyte> _int;
		private readonly IConverter<uint, sbyte> _uint;
		private readonly IConverter<long, sbyte> _long;
		private readonly IConverter<ulong, sbyte> _ulong;

		public SByteConverter()
		{
			var builder = new ConstrainedConverterBuilder<sbyte>(sbyte.MinValue, sbyte.MaxValue);

			_byte = builder.Create<byte>((x, y) => x <= y, (x, y) => x >= y, x => (sbyte) x);
			_short = builder.Create<short>((x, y) => x <= y, (x, y) => x >= y, x => (sbyte) x);
			_ushort = builder.Create<ushort>((x, y) => x <= y, (x, y) => x >= y, x => (sbyte) x);
			_int = builder.Create<int>((x, y) => x <= y, (x, y) => x >= y, x => (sbyte) x);
			_uint = builder.Create<uint>((x, y) => x <= y, (x, y) => x >= y, x => (sbyte) x);
			_long = builder.Create<long>((x, y) => x <= y, (x, y) => x >= y, x => (sbyte) x);
			_ulong = builder.Create<ulong>((x, y) => x < 0 || (ulong) x <= y, (x, y) => x >= 0 && (ulong) x >= y, x => (sbyte) x);
		}

		public sbyte Convert(sbyte value)
		{
			return value;
		}

		public sbyte Convert(byte value)
		{
			return _byte.Convert(value);
		}

		public sbyte Convert(short value)
		{
			return _short.Convert(value);
		}

		public sbyte Convert(ushort value)
		{
			return _ushort.Convert(value);
		}

		public sbyte Convert(int value)
		{
			return _int.Convert(value);
		}

		public sbyte Convert(uint value)
		{
			return _uint.Convert(value);
		}

		public sbyte Convert(long value)
		{
			return _long.Convert(value);
		}

		public sbyte Convert(ulong value)
		{
			return _ulong.Convert(value);
		}
	}
}