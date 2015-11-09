using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainModeling.Tests
{
	[TestClass()]
	public class TurnOutTests
	{
		[TestMethod()]
		public void CangeStateTest()
		{
			ITurnOuts turnOuts=new TurnOut();
			Console.WriteLine(turnOuts.State);
			Assert.AreEqual(turnOuts.State,(int)TurOutsState.NO_ROAD);
			turnOuts.CangeState();
			Assert.AreEqual(turnOuts.State, (int)TurOutsState.NO_ROAD);
			Thread.Sleep(6000);
			Assert.AreEqual(turnOuts.State,(int)TurOutsState.RIGHT_ROAD);
		}
	}
}