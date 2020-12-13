using System.Collections.Generic;
using Entrippy.Serialization;

namespace Entrippy.Serialization
{
	public class SuperSerializer<T> : ISerializer<T> where T : new()
	{
		private readonly List<IEntry> _entries;

		public SuperSerializer()
		{
			_entries = new List<IEntry>();
		}

		public SuperSerializer<T> Include<TChild>(ISerializer<TChild> serializer, MapperRef<T, TChild> refOf)
		{
			_entries.Add(new Entry<TChild>(serializer, refOf));

			return this;
		}

		public T Deserialize(IPackedReader reader)
		{
			var value = new T();

			foreach (var entry in _entries)
			{
				entry.Deserialize(ref value, reader);
			}

			return value;
		}

		public void Serialize(IPackedWriter writer, T value)
		{
			foreach (var entry in _entries)
			{
				entry.Serialize(writer, value);
			}
		}

		private interface IEntry
		{
			void Deserialize(ref T value, IPackedReader reader);
			void Serialize(IPackedWriter writer, T value);
		}

		public class Entry<TChild> : IEntry
		{
			private readonly ISerializer<TChild> _serializer;
			private readonly MapperRef<T, TChild> _refOf;

			public Entry(ISerializer<TChild> serializer, MapperRef<T, TChild> refOf)
			{
				_serializer = serializer;
				_refOf = refOf;
			}

			public void Deserialize(ref T value, IPackedReader reader)
			{
				_refOf(ref value) = _serializer.Deserialize(reader);
			}

			public void Serialize(IPackedWriter writer, T value)
			{
				_serializer.Serialize(writer, _refOf(ref value));
			}
		}
	}
}
