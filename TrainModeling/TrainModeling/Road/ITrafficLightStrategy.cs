namespace TrainModeling
{
	public interface ITrafficLightStrategy
	{
		void Cange();
		TrafficLightState GeTrafficLightState();
	}
}