using System.Drawing;

namespace TrainModeling
{
	public interface IRoadSection:IVariable,IComponent
	{
		double Length { get; }
		ICoordinate GetPointBegin();
		ICoordinate GetCoordinate(double distance);
	}
}