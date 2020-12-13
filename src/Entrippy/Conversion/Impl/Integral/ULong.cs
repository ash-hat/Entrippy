namespace Entrippy.Conversion.Impl
{
	public class ULongConverter :
		IConverter<sbyte, ulong>, IConverter<byte, ulong>,
		IConverter<short, ulong>, IConverter<ushort, ulong>,
		IConverter<int, ulong>, IConverter<uint, ulong>,
		IConverter<long, ulong>, IConverter<ulong, ulong>
	{
		private readonly IConverter<sbyte, ulong> _sbyte;
		private readonly IConverter<short, ulong> _short;
		private readonly IConverter<int, ulong> _int;
		private readonly IConverter<long, ulong> _long;

		public ULongConverter()
		{
			var builder = new ConstrainedConverterBuilder<ulong>(ulong.MinValue, ulong.MaxValue);

			_sbyte = builder.Create<sbyte>((x, y) => y >= 0 && x <= (ulong) y, (x, y) => y < 0 || x >= (ulong) y, x => (ulong) x);
			_short = builder.Create<short>((x, y) => y >= 0 && x <= (ulong) y, (x, y) => y < 0 || x >= (ulong) y, x => (ulong) x);
			_int = builder.Create<int>((x, y) => y >= 0 && x <= (ulong) y, (x, y) => y < 0 || x >= (ulong) y, x => (ulong) x);
			_long = builder.Create<long>((x, y) => y >= 0 && x <= (ulong) y, (x, y) => y < 0 || x >= (ulong) y, x => (ulong) x);
		}

		public ulong Convert(sbyte value)
		{
			return _sbyte.Convert(value);
		}

		public ulong Convert(byte value)
		{
			return value;
		}

		public ulong Convert(short value)
		{
			return _short.Convert(value);
		}

		public ulong Convert(ushort value)
		{
			return value;
		}

		public ulong Convert(int value)
		{
			return _int.Convert(value);
		}

		public ulong Convert(uint value)
		{
			return value;
		}

		public ulong Convert(long value)
		{
			return _long.Convert(value);
		}

		public ulong Convert(ulong value)
		{
			return value;
		}
	}
}