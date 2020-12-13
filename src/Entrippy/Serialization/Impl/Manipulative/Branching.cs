using System;
using ADepIn;
namespace Entrippy.Serialization
{
	public class BranchingSerializer<T> : ISerializer<T>
	{
		private readonly Mapper<T, bool> _if;
		private readonly ISerializer<T> _then;
		private readonly ISerializer<T> _else;

		public BranchingSerializer(Mapper<T, bool> @if, ISerializer<T> then, ISerializer<T> @else)
		{
			_if = @if;
			_then = then;
			_else = @else;
		}

		public T Deserialize(IPackedReader reader)
		{
			return reader.ReadBit()
				? _then.Deserialize(reader)
				: _else.Deserialize(reader);
		}

		public void Serialize(IPackedWriter writer, T value)
		{
			var conditional = _if(value);
			writer.Write(conditional);

			if (conditional)
			{
				_then.Serialize(writer, value);
			}
			else
			{
				_else.Serialize(writer, value);
			}
		}
	}
}
