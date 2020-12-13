namespace Entrippy.Serialization
{
	public interface IPackedReader
	{
		bool ReadBit();
		byte ReadByte();
	}
}