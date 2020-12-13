namespace Entrippy.Serialization
{
	public interface ISerializer<T>
	{
		T Deserialize(IPackedReader reader);

		void Serialize(IPackedWriter writer, T value);
	}
}
