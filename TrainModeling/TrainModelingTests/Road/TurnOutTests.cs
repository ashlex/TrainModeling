using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainModeling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;

namespace TrainModeling.Tests
{
	[TestClass()]
	public class TurnOutTests
	{
		[TestMethod()]
		public void CangeStateTestWihtDefaultConstructor()
		{
			int s = 0;

			var handler = new TurnOutsEventHandler(o =>
			{
				s = ((ITurnOuts)o).State;
			});
			ITurnOuts turnOuts=new TurnOut();
			turnOuts.TimeOfChange = 10;
			turnOuts.StateChanged += handler;
			Assert.AreEqual(turnOuts.State,(int)TurOutsState.NOT_DEFINE);
			turnOuts.CangeState();
			Assert.AreEqual((int)TurOutsState.NOT_DEFINE, s);
			Assert.AreEqual(turnOuts.State, (int)TurOutsState.NOT_DEFINE);
			Thread.Sleep(20);
			Assert.AreEqual((int)TurOutsState.NOT_DEFINE,turnOuts.State);
		}

		[TestMethod()]
		public void CangeStateTestConstructorWithTwoArg()
		{
			int t = 10;
			int s = 0;
			IRoad leftRoad = Mock.Of<IRoad>();
			IRoad rightRoad = Mock.Of<IRoad>();
			ITurnOuts turnOuts = new TurnOut(leftRoad, rightRoad);
			turnOuts.TimeOfChange = t;

			var handler = new TurnOutsEventHandler(o =>
			{
				s = ((ITurnOuts)o).State;
			});

			turnOuts.StateChanged += handler;

			Assert.AreEqual((int)TurOutsState.LEFT_ROAD,turnOuts.State);

			turnOuts.CangeState();
			Assert.AreEqual( (int)TurOutsState.NO_ROAD,turnOuts.State);
			Assert.AreEqual((int)TurOutsState.NO_ROAD,s);
			Thread.Sleep(t+10);
			Assert.AreEqual( (int) TurOutsState.RIGHT_ROAD,turnOuts.State);
			Assert.AreEqual((int)TurOutsState.RIGHT_ROAD, s);
			turnOuts.CangeState();
			Assert.AreEqual( (int)TurOutsState.NO_ROAD,turnOuts.State);
			Assert.AreEqual((int)TurOutsState.NO_ROAD, s);
			Thread.Sleep(t+10);
			Assert.AreEqual((int)TurOutsState.LEFT_ROAD,turnOuts.State );
			Assert.AreEqual((int)TurOutsState.LEFT_ROAD, s);
		}
		
	
		
	}
}