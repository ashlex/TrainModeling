using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using MathNet.Numerics.LinearAlgebra;

namespace TrainModeling
{
	public class Coordinate2D:ICoordinate
	{
		private double _x = 0;
		private double _y = 0;

		public Coordinate2D(Vector<double> vector )
		{
			if (vector.Count >= 2)
			{
				this._x = vector[0];
				this._y = vector[1];
			}
			else
			{
				this._x = 0;
				this._y = 0;
			}
		}

		public bool Set(int[] vector)
		{
			if (vector.Length == 2)
			{
				this._x = vector[0];
				this._y = vector[1];
				return true;
			}
			return false;
		}

		public Vector<double> Get()
		{
			return CreateVector.DenseOfArray(new[] { _x, _y });
		}

		public override string ToString()
		{
			return "X:"+_x+", Y:"+_y;
		}

		public Vector<double> GetVector()
		{
			throw new System.NotImplementedException();
		}

		public override bool Equals(object obj)
		{
			Coordinate2D o=obj as Coordinate2D;
			if (o!=null)
			{
				return (Math.Abs(o._x - this._x) < 0.00001)&&(Math.Abs(o._y - this._y) < 0.00001);
			}
			return false;
		}
	}
}