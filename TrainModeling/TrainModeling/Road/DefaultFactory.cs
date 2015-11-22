namespace TrainModeling
{
	public class DefaultFactory:IFactory
	{
		public IStrategyFactory GetStrategyFactory()
		{
			return new DefaultStrategyFactory();
		}
	}
}