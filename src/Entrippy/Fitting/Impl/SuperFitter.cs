using System.Collections.Generic;

namespace Entrippy.Fitting
{
	public class SuperFitter<T> : IFitter<T> where T : new()
	{
		private readonly List<IEntry> _entries;

		public SuperFitter()
		{
			_entries = new List<IEntry>();
		}

		public SuperFitter<T> Include<TChild>(MapperRef<T, TChild> refOf, IFitter<TChild> fitter)
		{
			_entries.Add(new Entry<TChild>(fitter, refOf));

			return this;
		}

		public T Fit(T a, T b, double t)
		{
			var value = new T();

			foreach (var entry in _entries)
			{
				entry.Fit(ref value, a, b, t);
			}

			return value;
		}

		private interface IEntry
		{
			void Fit(ref T value, T a, T b, double t);
		}

		public class Entry<TChild> : IEntry
		{
			private readonly IFitter<TChild> _fitter;
			private readonly MapperRef<T, TChild> _refOf;

			public Entry(IFitter<TChild> fitter, MapperRef<T, TChild> refOf)
			{
				_fitter = fitter;
				_refOf = refOf;
			}

			public void Fit(ref T value, T a, T b, double t)
			{
				_refOf(ref value) = _fitter.Fit(_refOf(ref a), _refOf(ref b), t);
			}
		}
	}
}
