using System;
using System.Net;

namespace Entrippy.Serialization
{
	public static class SystemSerializers
	{
		public static VersionSerializer Version { get; } = new VersionSerializer(UnmanagedSerializer<int>.Instance);

		public static IPAddressSerializer IPAddress { get; } = new IPAddressSerializer(UnmanagedSerializer<byte>.Instance.ToDynamicArray(TruncatedSerializers.IntAsByte));

		public static IPEndPointSerializer IPEndPoint { get; } = IPAddress.ToIPEndPoint(UnmanagedSerializer<ushort>.Instance);
	}
}
