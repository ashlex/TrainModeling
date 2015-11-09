namespace TrainModeling
{
	public abstract class Component:Base,IComponent
	{
		public abstract int State { get; }
	}
}