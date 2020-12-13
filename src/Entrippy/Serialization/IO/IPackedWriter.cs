namespace Entrippy.Serialization
{
	public interface IPackedWriter
	{
		void Write(bool value);
		void Write(byte value);
	}
}