namespace TrainModeling
{
	public interface IVariableChangingStrategy<T>
	{
		void Cange();
		T GeTrafficLightState();
	}
}