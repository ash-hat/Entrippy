namespace Entrippy.Conversion
{
	public class ByteConverter :
		IConverter<sbyte, byte>, IConverter<byte, byte>,
		IConverter<short, byte>, IConverter<ushort, byte>,
		IConverter<int, byte>, IConverter<uint, byte>,
		IConverter<long, byte>, IConverter<ulong, byte>
	{
		private readonly IConverter<sbyte, byte> _sbyte;
		private readonly IConverter<short, byte> _short;
		private readonly IConverter<ushort, byte> _ushort;
		private readonly IConverter<int, byte> _int;
		private readonly IConverter<uint, byte> _uint;
		private readonly IConverter<long, byte> _long;
		private readonly IConverter<ulong, byte> _ulong;

		public ByteConverter()
		{
			var builder = new ConstrainedConverterBuilder<byte>(byte.MinValue, byte.MaxValue);

			_sbyte = builder.Create<sbyte>((x, y) => x <= y, (x, y) => x >= y, x => (byte) x);
			_short = builder.Create<short>((x, y) => x <= y, (x, y) => x >= y, x => (byte) x);
			_ushort = builder.Create<ushort>((x, y) => x <= y, (x, y) => x >= y, x => (byte) x);
			_int = builder.Create<int>((x, y) => x <= y, (x, y) => x >= y, x => (byte) x);
			_uint = builder.Create<uint>((x, y) => x <= y, (x, y) => x >= y, x => (byte) x);
			_long = builder.Create<long>((x, y) => x <= y, (x, y) => x >= y, x => (byte) x);
			_ulong = builder.Create<ulong>((x, y) => x <= y, (x, y) => x >= y, x => (byte) x);
		}

		public byte Convert(sbyte value)
		{
			return _sbyte.Convert(value);
		}

		public byte Convert(byte value)
		{
			return value;
		}

		public byte Convert(short value)
		{
			return _short.Convert(value);
		}

		public byte Convert(ushort value)
		{
			return _ushort.Convert(value);
		}

		public byte Convert(int value)
		{
			return _int.Convert(value);
		}

		public byte Convert(uint value)
		{
			return _uint.Convert(value);
		}

		public byte Convert(long value)
		{
			return _long.Convert(value);
		}

		public byte Convert(ulong value)
		{
			return _ulong.Convert(value);
		}
	}
}