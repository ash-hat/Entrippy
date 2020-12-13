namespace Entrippy.Conversion
{
	public class IntConverter :
		IConverter<sbyte, int>, IConverter<byte, int>,
		IConverter<short, int>, IConverter<ushort, int>,
		IConverter<int, int>, IConverter<uint, int>,
		IConverter<long, int>, IConverter<ulong, int>
	{
		private readonly IConverter<uint, int> _uint;
		private readonly IConverter<long, int> _long;
		private readonly IConverter<ulong, int> _ulong;

		public IntConverter()
		{
			var builder = new ConstrainedConverterBuilder<int>(int.MinValue, int.MaxValue);

			_uint = builder.Create<uint>((x, y) => x <= y, (x, y) => x >= y, x => (int) x);
			_long = builder.Create<long>((x, y) => x <= y, (x, y) => x >= y, x => (int) x);
			_ulong = builder.Create<ulong>((x, y) => x < 0 || (ulong) x <= y, (x, y) => x >= 0 && (ulong) x >= y, x => (int) x);
		}

		public int Convert(sbyte value)
		{
			return value;
		}

		public int Convert(byte value)
		{
			return value;
		}

		public int Convert(short value)
		{
			return value;
		}

		public int Convert(ushort value)
		{
			return value;
		}

		public int Convert(int value)
		{
			return value;
		}

		public int Convert(uint value)
		{
			return _uint.Convert(value);
		}

		public int Convert(long value)
		{
			return _long.Convert(value);
		}

		public int Convert(ulong value)
		{
			return _ulong.Convert(value);
		}
	}
}