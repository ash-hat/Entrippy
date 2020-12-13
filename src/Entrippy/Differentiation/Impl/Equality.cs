using System;
using ADepIn;

namespace Entrippy.Differentiation
{
	public class EqualityDifferentiator<T> : IDifferentiator<T, T> where T : IEquatable<T>
	{
		public Option<T> CreateDelta(T now, Option<T> baseline)
		{
			if (baseline.MatchSome(out var value))
			{
				return now.Equals(value)
					? Option.None<T>()
					: Option.Some(now);
			}

			return Option.Some(now);
		}

		public T ConsumeDelta(T delta, Option<T> now)
		{
			return delta;
		}
	}
}
