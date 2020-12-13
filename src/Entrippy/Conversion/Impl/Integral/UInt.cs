namespace Entrippy.Conversion.Impl
{
	public class UIntConverter :
		IConverter<sbyte, uint>, IConverter<byte, uint>,
		IConverter<short, uint>, IConverter<ushort, uint>,
		IConverter<int, uint>, IConverter<uint, uint>,
		IConverter<long, uint>, IConverter<ulong, uint>
	{
		private readonly IConverter<sbyte, uint> _sbyte;
		private readonly IConverter<short, uint> _short;
		private readonly IConverter<int, uint> _int;
		private readonly IConverter<long, uint> _long;
		private readonly IConverter<ulong, uint> _ulong;

		public UIntConverter()
		{
			var builder = new ConstrainedConverterBuilder<uint>(uint.MinValue, uint.MaxValue);

			_sbyte = builder.Create<sbyte>((x, y) => x <= y, (x, y) => x >= y, x => (uint) x);
			_short = builder.Create<short>((x, y) => x <= y, (x, y) => x >= y, x => (uint) x);
			_int = builder.Create<int>((x, y) => x <= y, (x, y) => x >= y, x => (uint) x);
			_long = builder.Create<long>((x, y) => x <= y, (x, y) => x >= y, x => (uint) x);
			_ulong = builder.Create<ulong>((x, y) => x < 0 || (ulong) x <= y, (x, y) => x >= 0 && (ulong) x >= y, x => (uint) x);
		}

		public uint Convert(sbyte value)
		{
			return _sbyte.Convert(value);
		}

		public uint Convert(byte value)
		{
			return value;
		}

		public uint Convert(short value)
		{
			return _short.Convert(value);
		}

		public uint Convert(ushort value)
		{
			return value;
		}

		public uint Convert(int value)
		{
			return _int.Convert(value);
		}

		public uint Convert(uint value)
		{
			return value;
		}

		public uint Convert(long value)
		{
			return _long.Convert(value);
		}

		public uint Convert(ulong value)
		{
			return _ulong.Convert(value);
		}
	}
}