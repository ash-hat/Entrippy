using System.Net;
using Entrippy.Serialization;

namespace Entrippy.Serialization
{
    public class IPEndPointSerializer : ISerializer<IPEndPoint>
    {
		private readonly ISerializer<IPAddress> _address;
		private readonly ISerializer<ushort> _port;

		public IPEndPointSerializer(ISerializer<IPAddress> address, ISerializer<ushort> port)
		{
			_address = address;
			_port = port;
		}

        public IPEndPoint Deserialize(IPackedReader reader)
        {
			var address = _address.Deserialize(reader);
			var port = _port.Deserialize(reader);

            return new IPEndPoint(address, port);
        }

        public void Serialize(IPackedWriter writer, IPEndPoint value)
        {
            _address.Serialize(writer, value.Address);
			_port.Serialize(writer, (ushort) value.Port);
        }
    }
}
