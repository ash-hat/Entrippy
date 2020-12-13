namespace Entrippy.Serialization
{
	public static class ExtIPAddressSerializer
    {
        public static IPAddressSerializer ToIPAddress(this ISerializer<byte[]> @this)
        {
            return new IPAddressSerializer(@this);
        }
    }
}