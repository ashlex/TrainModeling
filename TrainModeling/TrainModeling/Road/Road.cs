using System;
using System.Drawing;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace TrainModeling
{
	public class Road: Composite, IRoad
	{
		private Coordinate _coordinateBegin;
		private Point[] _points;

		public Road(Point[] arrrayPoints)
		{
			_points = arrrayPoints;
		}

		public Point GetPointBegin()
		{
			if (_points.Any())
			{
				return _points.First();
			}

			return Point.Empty;
		}

		public Point GetPointEnd()
		{
			if (_points.Any())
			{
				return _points.ElementAtOrDefault(_points.Length-1);
			}

			return Point.Empty;
		}

		public Point GetCoordinate(double distance)
		{
//			if(distance<0||distance>1)throw new ArgumentOutOfRangeException(ExeptionMessage.Road_DistanceExeption);
throw new NotImplementedException();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var point in _points)
			{
				sb.AppendLine(String.Format("[{0},{1}]", point.X, point.Y));
			}
			return sb.ToString();
		}
	}
}