using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

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
			return new Coordinate2D(BezierCurve.GetPoint(_points, distance));
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