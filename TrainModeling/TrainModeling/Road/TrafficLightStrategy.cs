namespace TrainModeling
{
	public class TrafficLightStrategy:IVariableChangingStrategy<TrafficLightState>
	{
		private readonly TrafficLight _trafficLight;
		private TrafficLightState _trafficLightState;

		public TrafficLightStrategy(TrafficLight trafficLight)
		{
			_trafficLight = trafficLight;
		}

		public void Cange()
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

		public TrafficLightState GeTrafficLightState()
		{
			return _trafficLightState;
		}
	}
}