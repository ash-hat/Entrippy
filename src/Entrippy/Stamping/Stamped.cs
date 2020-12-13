namespace Entrippy.Stamping
{
	public readonly struct Stamped<TTime, TValue>
	{
		public TTime Time { get; }

		public TValue Value { get; }

		public Stamped(TTime time, TValue value)
		{
			Time = time;
			Value = value;
		}
	}
}