using System;
using System.Drawing;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace TrainModeling
{
	public class Road: Composite, IRoad
	{
		public ICoordinate GetPointBegin()
		{
			throw new NotImplementedException();
		}

		public ICoordinate GetCoordinate(double distance)
		{
			throw new NotImplementedException();
		}

		public override int State { get; }
	}
}