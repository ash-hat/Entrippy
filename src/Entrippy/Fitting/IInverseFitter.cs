namespace Entrippy.Fitting
{
	public interface IInverseFitter<in T>
	{
		double InverseFit(T a, T b, T value);
	}
}
