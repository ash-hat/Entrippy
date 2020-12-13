using ADepIn;
namespace Entrippy.Serialization
{
	public class OptionSerializer<T> : ISerializer<Option<T>>
	{
		private readonly ISerializer<T> _serializer;

		public OptionSerializer(ISerializer<T> serializer)
		{
			_serializer = serializer;
		}

		public Option<T> Deserialize(IPackedReader reader)
		{
			return reader.ReadBit()
				? Option.Some(_serializer.Deserialize(reader))
				: Option.None<T>();
		}

		public void Serialize(IPackedWriter writer, Option<T> value)
		{
			var isSome = value.MatchSome(out var inner);

			writer.Write(isSome);
			if (isSome)
			{
				_serializer.Serialize(writer, inner!);
			}
		}
	}
}
