namespace TrainModeling
{
	public abstract class Component:Base,IComponent
	{
		public abstract int State { get; }
		public abstract void EnterInOperation();
		public abstract void Decommission();
	}
}