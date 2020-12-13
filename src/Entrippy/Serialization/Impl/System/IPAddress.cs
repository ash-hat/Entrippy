using System.Net;
using Entrippy.Serialization;

namespace Entrippy.Serialization
{
    public class IPAddressSerializer : ISerializer<IPAddress>
    {
		private readonly ISerializer<byte[]> _bytes;

		public IPAddressSerializer(ISerializer<byte[]> bytes)
		{
			_bytes = bytes;
		}

        public IPAddress Deserialize(IPackedReader reader)
        {
			return new IPAddress(_bytes.Deserialize(reader));
        }

        public void Serialize(IPackedWriter writer, IPAddress value)
        {
            _bytes.Serialize(writer, value.GetAddressBytes());
        }
    }
}
