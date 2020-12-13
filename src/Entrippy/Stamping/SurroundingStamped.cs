using ADepIn;

namespace Entrippy.Stamping
{
	public readonly struct SurroundingStamped<TTime, TValue>
	{
		public static SurroundingStamped<TTime, TValue> None { get; }

		static SurroundingStamped()
		{
			var none = Option.None<Stamped<TTime, TValue>>();

			None = new SurroundingStamped<TTime, TValue>(none, none);
		}

		public Option<Stamped<TTime, TValue>> Behind { get; }

		public Option<Stamped<TTime, TValue>> Ahead { get; }

		public SurroundingStamped(Option<Stamped<TTime, TValue>> behind, Option<Stamped<TTime, TValue>> ahead)
		{
			Behind = behind;
			Ahead = ahead;
		}
	}
}