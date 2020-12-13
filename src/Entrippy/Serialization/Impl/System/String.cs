using Entrippy.Serialization;

namespace Entrippy.Serialization
{
	public class StringSerializer : ISerializer<string>
	{
		private readonly ISerializer<char[]> _chars;

		public StringSerializer(ISerializer<char[]> chars)
		{
			_chars = chars;
		}

		public string Deserialize(IPackedReader reader)
		{
			var chars = _chars.Deserialize(reader);

			return new string(chars, 0, chars.Length);
		}

		public void Serialize(IPackedWriter writer, string value)
		{
			var chars = value.ToCharArray();

			_chars.Serialize(writer, chars);
		}
	}
}
