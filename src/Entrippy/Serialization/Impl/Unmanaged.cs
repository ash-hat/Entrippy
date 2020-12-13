using Entrippy.IO;

namespace Entrippy.Serialization
{
	public class UnmanagedSerializer<T> : ISerializer<T> where T : unmanaged
	{
		public static UnmanagedSerializer<T> Instance { get; } = new UnmanagedSerializer<T>();

		public unsafe T Deserialize(IPackedReader reader)
		{
			T value = default;
			byte* ptr = (byte*) &value;
			for (var i = 0; i < sizeof(T); ++i)
			{
				ptr[i] = reader.ReadByte();
			}

			return value;
		}

		public unsafe void Serialize(IPackedWriter writer, T value)
		{
			byte* ptr = (byte*) &value;
			for (var i = 0; i < sizeof(T); ++i)
			{
				writer.Write(ptr[i]);
			}
		}
	}
}