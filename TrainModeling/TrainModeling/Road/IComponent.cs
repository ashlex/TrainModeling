namespace TrainModeling
{
	public interface IComponent
	{
		int State { get; }
		void EnterInOperation();
		void Decommission();
	}
}