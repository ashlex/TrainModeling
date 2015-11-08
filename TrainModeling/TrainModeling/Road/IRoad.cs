using System.Drawing;

namespace TrainModeling
{
	public interface IRoad
	{
		Point GetPointBegin();
		Point GetPointEnd();
		Point GetCoordinate(double distance);
	}
}