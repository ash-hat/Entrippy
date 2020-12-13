using System;

namespace Entrippy.Conversion.Impl
{
	public class ConstrainedConverterBuilder<T>
	{
		private readonly T _min;
		private readonly T _max;

		public ConstrainedConverterBuilder(T min, T max)
		{
			_min = min;
			_max = max;
		}

		public IConverter<TSource, T> Create<TSource>(Func<T, TSource, bool> lessThanOrEqualTo, Func<T, TSource, bool> greaterThanOrEqualTo, Func<TSource, T> convert)
		{
			return new ConstrainedConverter<TSource, T>(_min, _max, lessThanOrEqualTo, greaterThanOrEqualTo, convert);
		}
	}
}