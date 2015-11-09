using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrainModeling
{
	public enum TurOutsState
	{
		LEFT_ROAD=1,
		RIGHT_ROAD=2,
		NO_ROAD=0
	}

	public class TurnOut : Composite,ITurnOuts
	{
		private TurOutsState _state=TurOutsState.NO_ROAD;
		public int State { get { return (int)_state; } }

		public TurnOut(IRoad leftRoad, IRoad rightRoad)
		{
			if (leftRoad.GetPointBegin() == rightRoad.GetPointBegin())
			{
				this.Add(leftRoad);
				this.Add(rightRoad);
				this._state = TurOutsState.LEFT_ROAD;
			}
		}
		public TurnOut()
		{
		}

		public void CangeState()
		{
			this._state = TurOutsState.NO_ROAD;
			Task t=new Task(new Action<object>(o =>
			{
				Thread.Sleep(5000);
				((TurnOut) o)._state = TurOutsState.RIGHT_ROAD;
			}),this);
			t.Start();
		}
	}
}