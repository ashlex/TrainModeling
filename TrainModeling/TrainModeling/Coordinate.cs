using MathNet.Numerics.LinearAlgebra;

namespace TrainModeling
{
	public class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Coordinate(int[] vector)
		{
			if (vector.Length == 2)
			{
				this.X = vector[0];
				this.Y = vector[1];
			}
			else
			{
				this.X = 0;
				this.Y = 0;
			}
		}

		public bool Set(int[] vector)
		{
			if (vector.Length == 2)
			{
				this.X = vector[0];
				this.Y = vector[1];
				return true;
			}
			return false;
		}

		public Vector<int> Get()
		{
			return CreateVector.DenseOfArray(new[] { X, Y });
		}

		public override string ToString()
		{
			return "X:"+X+", Y:"+Y;
		}
	}
}