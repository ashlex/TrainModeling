using System;
using System.Threading.Tasks;
using TrainModeling.Conditions;

namespace TrainModeling
{
	public class TrafficLight : Component,IVariable
	{

		public void ChangeState()
		{
			new Task(o =>
			{
				var light = o as TrafficLight;
				if (light != null)
				{
					_changeStrategy.Change();
					light._state = _changeStrategy.GetState();
					OnStateChanged();
				}
			}, this).Start();
		}

		protected virtual void OnStateChanged()
		{
			StateChanged?.Invoke(this, EventArgs.Empty);
		}

		#region Fields and properties
		
		private readonly IVariableChangingStrategy<TrafficLightState> _changeStrategy;
		private TrafficLightState _state = TrafficLightState.UNDEFINED;
		public event EventHandler StateChanged;
		public int TimeOfChange { get; set; }

		public override int State { get { return (int) _state; } }
		public override void EnterInOperation()
		{
			throw new NotImplementedException();
		}

		public override void Decommission()
		{
			throw new NotImplementedException();
		}

		#endregion


		#region Constructors

		public TrafficLight(IFactory factory)
		{
			_changeStrategy = factory.GetStrategyFactory().GetTrafficLightChangingStrategy();
			_changeStrategy.Component = this;
		}

		#endregion


	}
	
}