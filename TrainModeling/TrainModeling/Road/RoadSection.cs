using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using TrainModeling.Conditions;

namespace TrainModeling
{
	public class RoadSection : Component, IRoadSection
	{
		private object lockObject=new object();
		private Matrix<double> _points;
		private IVariableChangingStrategy<RoadSectionState> _strategy;
		private RoadSectionState _state;

		public override int State
		{
			get { return (int) _state; }
		}

		public double Length { get; }

		public RoadSection(IFactory factory)
		{
			_state = RoadSectionState.UNDEFINE;
			_strategy = factory.GetStrategyFactory().GetRoadSectionChangingStrategy(this);
			Length = 10;
		}

		public RoadSection(IFactory factory, Matrix<double> points)
		{
			_state = RoadSectionState.FREE;
			_strategy = factory.GetStrategyFactory().GetRoadSectionChangingStrategy(this);
			_points = points;
			IEnumerable<Vector<double>> row = _points.EnumerateRows();
			foreach (Vector<double> vector in row)
			{
			}
		}


		public ICoordinate GetPointBegin()
		{
			return new Coordinate2D(_points.Column(0));
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
				lock (lockObject)
				{
					RoadSection rs = o as RoadSection;
					if (rs != null)
					{
						Thread.Sleep(rs.TimeOfChange);
						_strategy.Change();
						rs.OnStateChanged(_strategy.GetState());
					}
				}
			}, this).Start();
		}

		public override void EnterInOperation()
		{
			OnStateChanged(RoadSectionState.FREE);
		}
		public override void Decommission()
		{
			OnStateChanged(RoadSectionState.UNDEFINE);
		}

		protected virtual void OnStateChanged(RoadSectionState state)
		{
			_state = state;
			StateChanged?.Invoke(this, null);
		}
	}
	
}