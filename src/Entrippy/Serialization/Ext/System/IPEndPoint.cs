using System.Net;

namespace Entrippy.Serialization
{
	public static class ExtIPEndPointSerializer
	{
		public static IPEndPointSerializer ToIPEndPoint(this ISerializer<IPAddress> @this, ISerializer<ushort> port)
		{
			return new IPEndPointSerializer(@this, port);
		}
	}
}