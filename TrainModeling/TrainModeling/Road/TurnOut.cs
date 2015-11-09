using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrainModeling
{
	public enum TurOutsState
	{
		LEFT_ROAD = 1,
		RIGHT_ROAD = 2,
		NO_ROAD = 0
	}

	public delegate void TurnOutsEventHandler(object sender);

	public class TurnOut : Composite, ITurnOuts
	{
		private TurOutsState _previousState = TurOutsState.NO_ROAD;
		private TurOutsState _state;

		public TurnOut(IRoad leftRoad, IRoad rightRoad)
		{
			if (leftRoad.GetPointBegin() != rightRoad.GetPointBegin()) throw new ArgumentException();
			Add(leftRoad);
			Add(rightRoad);
			SetState(TurOutsState.LEFT_ROAD);
		}

		public TurnOut()
		{
		}

		public int TimeOfChange { get; set; }
		public event TurnOutsEventHandler StateChanged;

		public override int State
		{
			get { return (int) _state; }
		}

		public void CangeState()
		{
			_previousState = _state;
			SetState(TurOutsState.NO_ROAD);
			var t = new Task(o =>
			{
				var turnOut = (TurnOut) o;
				Thread.Sleep(turnOut.TimeOfChange);
				turnOut.SetState(turnOut._previousState != TurOutsState.NO_ROAD
					? (turnOut._previousState == TurOutsState.LEFT_ROAD ? TurOutsState.RIGHT_ROAD : TurOutsState.LEFT_ROAD)
					: turnOut._state);
			}, this);
			t.Start();
		}

		private void SetState(TurOutsState state)
		{
			_state = state;
			if (StateChanged != null) StateChanged(this);
		}
	}
}