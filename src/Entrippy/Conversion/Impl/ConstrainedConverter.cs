using System;

namespace Entrippy.Conversion.Impl
{
	public class ConstrainedConverter<T, TConstrained> : IConverter<T, TConstrained>
	{
		private readonly TConstrained _min;
		private readonly TConstrained _max;

		private readonly Func<TConstrained, T, bool> _lessThanOrEqualTo;
		private readonly Func<TConstrained, T, bool> _greaterThanOrEqualTo;

		private readonly Func<T, TConstrained> _convert;

		public ConstrainedConverter(TConstrained min, TConstrained max, Func<TConstrained, T, bool> lessThanOrEqualTo, Func<TConstrained, T, bool> greaterThanOrEqualTo, Func<T, TConstrained> convert)
		{
			_min = min;
			_max = max;

			_lessThanOrEqualTo = lessThanOrEqualTo;
			_greaterThanOrEqualTo = greaterThanOrEqualTo;

			_convert = convert;
		}

		public TConstrained Convert(T value)
		{
			if (_greaterThanOrEqualTo(_min, value) || _lessThanOrEqualTo(_max, value))
			{
				throw new ArgumentOutOfRangeException(nameof(value), value, $"Value must be within the range of a byte: {_min} <= v <= {_max}");
			}

			return _convert(value);
		}
	}
}