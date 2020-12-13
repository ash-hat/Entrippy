using System;
using System.Collections.Generic;
using ADepIn;

namespace Entrippy.Stamping
{
	public class StampedSet<TTime, TValue>
	{
		private readonly IComparer<TTime> _comparer;

		public List<Stamped<TTime, TValue>> Entries { get; }

		public StampedSet(IComparer<TTime> comparer)
		{
			_comparer = comparer;

			Entries = new List<Stamped<TTime, TValue>>();
		}

		private SurroundingStamped<TTime, TValue> None => SurroundingStamped<TTime, TValue>.None;

		private SurroundingStamped<TTime, TValue> At(Stamped<TTime, TValue> value)
		{
			var opt = Option.Some(value);

			return new SurroundingStamped<TTime, TValue>(opt, opt);
		}

		private SurroundingStamped<TTime, TValue> After(Stamped<TTime, TValue> value)
		{
			return new SurroundingStamped<TTime, TValue>(Option.Some(value), Option.None<Stamped<TTime, TValue>>());
		}

		private SurroundingStamped<TTime, TValue> Behind(Stamped<TTime, TValue> value)
		{
			return new SurroundingStamped<TTime, TValue>(Option.None<Stamped<TTime, TValue>>(), Option.Some(value));
		}

		private SurroundingStamped<TTime, TValue> Within(Stamped<TTime, TValue> behind, Stamped<TTime, TValue> ahead)
		{
			return new SurroundingStamped<TTime, TValue>(Option.Some(behind), Option.Some(ahead));
		}

		private SurroundingStamped<TTime, TValue> Compare(TTime time, Stamped<TTime, TValue> value)
		{
			switch (_comparer.Compare(time, value.Time))
			{
				case -1: return Behind(value);
				case 0: return At(value);
				case 1: return After(value);
				default: throw new ArgumentOutOfRangeException();
			}
		}

		public SurroundingStamped<TTime, TValue> this[TTime time]
		{
			get
			{
				if (Entries.Count == 0)
				{
					return None;
				}

				var latest = Entries[Entries.Count - 1];
				if (Entries.Count == 1)
				{
					return Compare(time, latest);
				}

				switch (_comparer.Compare(time, latest.Time)) // [latest, infinity)
				{
					case -1: break;
					case 0: return At(latest);
					case 1: return After(latest);
					default: throw new ArgumentOutOfRangeException();
				}

				for (var i = Entries.Count - 1; i > 0; --i) // (oldest, latest)
				{
					var a = Entries[i - 1];
					var b = Entries[i];

					switch (_comparer.Compare(time, a.Time))
					{
						case -1: continue; // behind window
						case 0: return At(a);
						case 1: break; // inside window (ahead 'a')
						default: throw new ArgumentOutOfRangeException();
					}

					switch (_comparer.Compare(time, b.Time))
					{
						case -1: break; // inside window (before 'b')
						case 0: throw new NotImplementedException("This should never occur; the previous iteration should handle a time that is equal to the current head (then tail).");
						case 1: throw new NotImplementedException("This should never occur; the previous iterations should handle any time that is ahead of the current iteration.");
						default: throw new ArgumentOutOfRangeException();
					}

					return Within(a, b);
				}

				// (negative infinity, oldest]
				return Behind(Entries[0]);
			}
		}
	}
}
