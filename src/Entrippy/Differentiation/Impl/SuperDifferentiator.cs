using System.Collections.Generic;
using ADepIn;

namespace Entrippy.Differentiation
{
	public class SuperDifferentiator<TValue, TDelta> : IDifferentiator<TValue, TDelta> 
		where TValue : new()
		where TDelta : new()
	{
		private readonly List<IEntry> _entries;

		public SuperDifferentiator()
		{
			_entries = new List<IEntry>();
		}

		public SuperDifferentiator<TValue, TDelta> Include<TChildValue, TChildDelta>(IDifferentiator<TChildValue, TChildDelta> differentiator, MapperRef<TValue, TChildValue> valueRefOf, MapperRef<TDelta, Option<TChildDelta>> deltaRefOf)
		{
			_entries.Add(new Entry<TChildValue, TChildDelta>(differentiator, valueRefOf, deltaRefOf));

			return this;
		}

		public TValue ConsumeDelta(TDelta delta, Option<TValue> now)
		{
			var value = new TValue();

			foreach (var entry in _entries)
			{
				entry.ConsumeDelta(ref value, delta, now);
			}

			return value;
		}

		public Option<TDelta> CreateDelta(TValue now, Option<TValue> baseline)
		{
			var delta = Option.None<TDelta>();

			foreach (var entry in _entries)
			{
				entry.CreateDelta(ref delta, now, baseline);
			}

			return delta;
		}

		private interface IEntry
		{
			void ConsumeDelta(ref TValue value, TDelta delta, Option<TValue> now);
			void CreateDelta(ref Option<TDelta> delta, TValue now, Option<TValue> baseline);
		}

		private class Entry<TChildValue, TChildDelta> : IEntry
		{
			private readonly IDifferentiator<TChildValue, TChildDelta> _differentiator;
			private readonly MapperRef<TValue, TChildValue> _valueRefOf;
			private readonly MapperRef<TDelta, Option<TChildDelta>> _deltaRefOf;

			private readonly Mapper<TValue, TChildValue> _valueCopyOf;

			public Entry(IDifferentiator<TChildValue, TChildDelta> differentiator, MapperRef<TValue, TChildValue> valueRefOf, MapperRef<TDelta, Option<TChildDelta>> deltaRefOf)
			{
				_differentiator = differentiator;
				_valueRefOf = valueRefOf;
				_deltaRefOf = deltaRefOf;

				_valueCopyOf = x => _valueRefOf(ref x);
			}

			public void ConsumeDelta(ref TValue value, TDelta delta, Option<TValue> now)
			{
				if (_deltaRefOf(ref delta).MatchSome(out var subDelta))
				{
					_valueRefOf(ref value) = _differentiator.ConsumeDelta(subDelta, now.Map(_valueCopyOf));
				}
			}

			public void CreateDelta(ref Option<TDelta> delta, TValue now, Option<TValue> baseline)
			{
				var subDelta = _differentiator.CreateDelta(_valueRefOf(ref now), baseline.Map(_valueCopyOf));

				if (delta.MatchSome(out var inner))
				{
					_deltaRefOf(ref inner) = subDelta;

					delta = Option.Some(inner);
				}
				else if (subDelta.IsSome)
				{
					inner = new TDelta();
					_deltaRefOf(ref inner) = subDelta;

					delta = Option.Some(inner);
				}
			}
		}
	}
}