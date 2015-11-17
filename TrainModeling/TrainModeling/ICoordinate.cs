using MathNet.Numerics.LinearAlgebra;

namespace TrainModeling
{
	public interface ICoordinate
	{
		Vector<double> GetVector();
	}
}