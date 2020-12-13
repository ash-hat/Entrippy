namespace Entrippy.Fitting
{
	public interface IFitter<T>
	{
		T Fit(T a, T b, double t);
	}
}
