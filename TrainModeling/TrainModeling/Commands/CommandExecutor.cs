namespace TrainModeling.Commands
{
	public class CommandExecutor
	{
		public bool Execute(ICommand command)
		{
			command.Execute();
			return true;
		} 
	}
}