using TrainModeling.Conditions;

namespace TrainModeling
{
	public interface IStrategyFactory
	{
		IVariableChangingStrategy<RoadSectionState> GetRoadSectionChangingStrategy(IRoadSection roadSection);
		IVariableChangingStrategy<TrafficLightState> GetTrafficLightChangingStrategy();
		IVariableChangingStrategy<TurOutsState> GetTurOutsChangingStrategy();
		IMovingStrategy GetMovingStrategy();

	}
}