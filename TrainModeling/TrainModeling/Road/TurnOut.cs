using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TrainModeling
{
	public class TurnOut : Composite, ITurnOuts
	{
		/// <summary>
		///     This should be allocated to the strategy
		/// </summary>
		public void CangeState()
		{
			if (_state != TurOutsState.NOT_DEFINE)
			{
				_previousState = _state;
				SetState(TurOutsState.NO_ROAD);
				new Task(Run, this).Start();
			}
			else
			{
				if (StateChanged != null) StateChanged(this);
			}
		}

		private void Run(object sender)
		{
			//This should be allocated to the strategy

			#region Strategy

			var turnOut = (TurnOut) sender;
			Thread.Sleep(turnOut.TimeOfChange);
			turnOut.SetState(turnOut._previousState != TurOutsState.NO_ROAD
				? (turnOut._previousState == TurOutsState.LEFT_ROAD ? TurOutsState.RIGHT_ROAD : TurOutsState.LEFT_ROAD)
				: turnOut._state);

			#endregion
		}

		protected void SetState(TurOutsState state)
		{
			_state = state;
			if (StateChanged != null) StateChanged(this);
		}

		#region Constructors

		public TurnOut([NotNull] IRoad leftRoad, [NotNull] IRoad rightRoad, TurOutsState state)
		{
			if (leftRoad == null || rightRoad == null) throw new ArgumentNullException();
			if (leftRoad.GetPointBegin() != rightRoad.GetPointBegin()) throw new ArgumentException();
			Add(leftRoad);
			Add(rightRoad);
			_state = state;
		}

		public TurnOut([NotNull] IRoad leftRoad, [NotNull] IRoad rightRoad)
			: this(leftRoad, rightRoad, TurOutsState.LEFT_ROAD)
		{
		}

		public TurnOut()
		{
			_state = TurOutsState.NOT_DEFINE;
		}

		#endregion

		#region Fields and properties

		private TurOutsState _previousState = TurOutsState.NO_ROAD;
		private TurOutsState _state;
		public int TimeOfChange { get; set; }
		public event TurnOutsEventHandler StateChanged;

		public override int State
		{
			get { return (int) _state; }
		}

		#endregion
	}

	public delegate void TurnOutsEventHandler(object sender);

	public enum TurOutsState
	{
		LEFT_ROAD = 1,
		RIGHT_ROAD = 2,
		NO_ROAD = 0,
		NOT_DEFINE = 3
	}
}