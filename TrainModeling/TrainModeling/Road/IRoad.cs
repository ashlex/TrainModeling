using System.Drawing;

namespace TrainModeling
{
	public interface IRoad:IComponent
	{
		ICoordinate GetPointBegin();
		ICoordinate GetCoordinate(double distance);
	}
}