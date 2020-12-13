namespace Entrippy.Fitting.Impl
{
	public class IntegralFitters : 
		IFitter<sbyte>, IInverseFitter<sbyte>,
		IFitter<byte>, IInverseFitter<byte>,
		IFitter<short>, IInverseFitter<short>,
		IFitter<ushort>, IInverseFitter<ushort>,
		IFitter<int>, IInverseFitter<int>,
		IFitter<uint>, IInverseFitter<uint>,
		IFitter<long>, IInverseFitter<long>,
		IFitter<ulong>, IInverseFitter<ulong>
	{
		public static IntegralFitters Instance { get; } = new IntegralFitters();

		public sbyte Fit(sbyte a, sbyte b, double t)
		{
			return (sbyte) (a + (b - a) * t);
		}

		public byte Fit(byte a, byte b, double t)
		{
			return (byte) (a + (b - a) * t);
		}

		public short Fit(short a, short b, double t)
		{
			return (short) (a + (b - a) * t);
		}

		public ushort Fit(ushort a, ushort b, double t)
		{
			return (ushort) (a + (b - a) * t);
		}

		public int Fit(int a, int b, double t)
		{
			return (int) (a + (b - a) * t);
		}

		public uint Fit(uint a, uint b, double t)
		{
			return (uint) (a + (b - a) * t);
		}

		public long Fit(long a, long b, double t)
		{
			return (long) (a + (b - a) * t);
		}

		public ulong Fit(ulong a, ulong b, double t)
		{
			return (ulong) (a + (b - a) * t);
		}

		public double InverseFit(sbyte a, sbyte b, sbyte value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(byte a, byte b, byte value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(short a, short b, short value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(ushort a, ushort b, ushort value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(int a, int b, int value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(uint a, uint b, uint value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(long a, long b, long value)
		{
			return (double) (value - a) / (b - a);
		}

		public double InverseFit(ulong a, ulong b, ulong value)
		{
			return (double) (value - a) / (b - a);
		}
	}
}