using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TrainModeling
{
	public class TurnOut : Composite, IRoadNode
	{
		public void ChangeState()
		{
			if (_state != TurOutsState.NOT_DEFINE)
			{
				_previousState = _state;
				OnStateChanged(TurOutsState.NO_ROAD);
				new Task(Run, this).Start();
			}
		}

		private void Run(object sender)
		{
			//This should be allocated to the strategy

			#region Strategy

			var turnOut = (TurnOut) sender;
			Thread.Sleep(turnOut.TimeOfChange);
			turnOut.OnStateChanged(turnOut._previousState != TurOutsState.NO_ROAD
				? (turnOut._previousState == TurOutsState.LEFT_ROAD ? TurOutsState.RIGHT_ROAD : TurOutsState.LEFT_ROAD)
				: turnOut._state);
			#endregion
		}

		protected virtual void OnStateChanged(TurOutsState state)
		{
			_state = state;
			StateChanged?.Invoke(this,null);
		}

		#region Constructors

		public TurnOut([NotNull] IRoadSection leftRoadSection, [NotNull] IRoadSection rightRoadSection, TurOutsState state)
		{
			if (leftRoadSection == null || rightRoadSection == null) throw new ArgumentNullException();
			if (leftRoadSection.GetPointBegin() != rightRoadSection.GetPointBegin()) throw new ArgumentException();
			Add(leftRoadSection);
			Add(rightRoadSection);
			_state = state;
		}

		public TurnOut([NotNull] IRoadSection leftRoadSection, [NotNull] IRoadSection rightRoadSection)
			: this(leftRoadSection, rightRoadSection, TurOutsState.LEFT_ROAD)
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

		public event EventHandler StateChanged;

		public override int State
		{
			get { return (int) _state; }
		}

		#endregion
	}
	

	public enum TurOutsState
	{
		LEFT_ROAD = 1,
		RIGHT_ROAD = 2,
		NO_ROAD = 0,
		NOT_DEFINE = 3
	}
}