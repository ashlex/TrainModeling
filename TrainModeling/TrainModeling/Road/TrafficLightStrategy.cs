namespace TrainModeling
{
	public class TrafficLightStrategy:IVariableChangingStrategy<TrafficLightState>
	{
		private IComponent _trafficLight;
		private TrafficLightState _trafficLightState;

		public IComponent Component
		{
			set {
				_trafficLight = value;
				
			}
		}

		public void Change()
		{
			switch (_trafficLight.State)
			{
				case (int) TrafficLightState.RED:
					_trafficLightState = TrafficLightState.GREEN;
					break;
				case (int) TrafficLightState.GREEN:
					_trafficLightState = TrafficLightState.YELLOW;
					break;
				case (int) TrafficLightState.YELLOW:
					_trafficLightState = TrafficLightState.RED;
					break;
				default:
					_trafficLightState = (int) TrafficLightState.UNDEFINED;
					break;
			}
		}

		public TrafficLightState GetState()
		{
			return _trafficLightState;
		}
	}
}