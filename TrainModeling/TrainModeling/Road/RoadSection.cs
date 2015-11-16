using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace TrainModeling
{
	public class RoadSection:Component,IRoadSection
	{
		private Matrix<double> _points;
        private IVariableChangingStrategy<RoadSectionState> _strategy; 
		private RoadSectionState _state;
		public override int State { get { return (int) _state; } }
		public double Length { get; }

		public RoadSection()
		{
			_strategy=new RoadSectionStrategy(this);
			_state = RoadSectionState.UNDEFINE;
			Length = 10;
		}

		public RoadSection(Matrix<double> points)
		{
			_strategy=new RoadSectionStrategy(this);
			_state = RoadSectionState.FREE;
			_points = points;
			IEnumerable<Vector<double>> row=_points.EnumerateRows();
			foreach (Vector<double> vector in row)
			{
				
			}
		}


		public ICoordinate GetPointBegin()
		{
			throw new System.NotImplementedException();
		}

		public ICoordinate GetCoordinate(double distance)
		{
			int n = _points.RowCount;
			int i = 0;
			VectorBuilder<double> vBuilder = Vector<double>.Build;
			Vector<double> v = vBuilder.Dense(_points.ColumnCount, 0);
			foreach (Vector<double> enumerateRow in _points.EnumerateRows())
			{
				Vector<double> tmp = enumerateRow.Multiply(BernstansBazis(n, i++, distance));
                v=v.Add(tmp);
			}
			return new Coordinate2D(v);
		}

		private double BernstansBazis(int n, int i,double t)
		{
			double a = MathNet.Numerics.Fn.Factorial(n);
			double b = (Fn.Factorial(i)*Fn.Factorial(n - i));
			double c = a/b;
			double d = Math.Pow(t, i);
			double e = Math.Pow(1 - t, n - i);
            return c * d * e;
		}

		public event EventHandler StateChanged;
		public int TimeOfChange { get; set; }
		public void ChangeState()
		{
			new Task(o =>
			{
				RoadSection rs=o as RoadSection;
				if (rs != null)
				{
					_strategy.Cange();
					rs.OnStateChanged(_strategy.GeTrafficLightState());
				}
			}, this).Start();
		}
		protected virtual void OnStateChanged(RoadSectionState state)
		{
			_state = state;
			StateChanged?.Invoke(this, null);
		}
	}

	public enum RoadSectionState
	{
		UNDEFINE=0,
		FREE=1,
		BUSY=2
	}
}