using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainModeling.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TrainModeling.Commands.Tests
{
	[TestClass()]
	public class StartMovingCommandTests
	{
		[TestMethod()]
		public void ExecuteTest()
		{
			SimpleTrain simple=new SimpleTrain();
			IMovingStrategy strategy = Mock.Of<IMovingStrategy>(d => d.Start()==true && d.Stop()==true);
			ICommand command=new StartMovingCommand(new SimpleTrain());
			CommandExecutor commandExecutor=new CommandExecutor();
			Assert.IsTrue(commandExecutor.Execute(command));
		}
	}
}