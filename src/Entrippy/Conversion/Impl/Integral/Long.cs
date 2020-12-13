namespace Entrippy.Conversion.Impl
{
	public class LongConverter :
		IConverter<sbyte, long>, IConverter<byte, long>,
		IConverter<short, long>, IConverter<ushort, long>,
		IConverter<int, long>, IConverter<uint, long>,
		IConverter<long, long>, IConverter<ulong, long>
	{
		private readonly IConverter<ulong, long> _ulong;

		public LongConverter()
		{
			var builder = new ConstrainedConverterBuilder<long>(long.MinValue, long.MaxValue);

			_ulong = builder.Create<ulong>((x, y) => x < 0 || (ulong) x <= y, (x, y) => x >= 0 && (ulong) x >= y, x => (long) x);
		}

		public long Convert(sbyte value)
		{
			return value;
		}

		public long Convert(byte value)
		{
			return value;
		}

		public long Convert(short value)
		{
			return value;
		}

		public long Convert(ushort value)
		{
			return value;
		}

		public long Convert(int value)
		{
			return value;
		}

		public long Convert(uint value)
		{
			return value;
		}

		public long Convert(long value)
		{
			return value;
		}

		public long Convert(ulong value)
		{
			return _ulong.Convert(value);
		}
	}
}