namespace TrainModeling
{
	public interface ITurnOuts:IComponent
	{
		event TurnOutsEventHandler StateChanged;
		int TimeOfChange { get; set; }

		void CangeState();
	}
}