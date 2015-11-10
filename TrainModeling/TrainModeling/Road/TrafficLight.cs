using System;
using System.Threading.Tasks;

namespace TrainModeling
{
	public class TrafficLight : Component,IRoadNode
	{

		public void ChangeState()
		{
			new Task(o =>
			{
				var light = o as TrafficLight;
				if (light != null)
				{
					_changeStrategy.Cange();
					light._state = _changeStrategy.GeTrafficLightState();
					OnStateChanged();
				}
			}, this).Start();
		}

		protected virtual void OnStateChanged()
		{
			StateChanged?.Invoke(this, EventArgs.Empty);
		}

		#region Fields and properties
		
		private readonly TrafficLightStrategy _changeStrategy;
		private TrafficLightState _state = TrafficLightState.UNDEFINED;
		public event EventHandler StateChanged;
		public int TimeOfChange { get; set; }

		public override int State { get { return (int) _state; } }

		#endregion


		#region Constructors

		public TrafficLight()
		{
			_changeStrategy = new TrafficLightStrategy(this);
		}

		#endregion


	}

	public enum TrafficLightState
	{
		UNDEFINED = 0,
		GREEN = 1,
		YELLOW = 2,
		RED = 3
	}
}