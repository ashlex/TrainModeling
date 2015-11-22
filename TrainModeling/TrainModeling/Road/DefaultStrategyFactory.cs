using TrainModeling.Conditions;

namespace TrainModeling
{
	public class DefaultStrategyFactory:IStrategyFactory
	{
		public IVariableChangingStrategy<RoadSectionState> GetRoadSectionChangingStrategy()
		{
			return new RoadSectionStrategy();
		}

		public IVariableChangingStrategy<TrafficLightState> GetTrafficLightChangingStrategy()
		{
			throw new System.NotImplementedException();
		}

		public IVariableChangingStrategy<TurOutsState> GetTurOutsChangingStrategy()
		{
			throw new System.NotImplementedException();
		}

		public IMovingStrategy GetMovingStrategy()
		{
			throw new System.NotImplementedException();
		}
	}
}