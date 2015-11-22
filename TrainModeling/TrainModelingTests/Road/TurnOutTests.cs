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
using TrainModeling.Conditions;

namespace TrainModeling.Tests
{
	[TestClass()]
	public class TurnOutTests
	{
		[TestMethod()]
		public void CangeStateTestWihtDefaultConstructor()
		{
			ITurnOut turnOuts = new TurnOut();
			turnOuts.TimeOfChange = 100;
			Assert.AreEqual(turnOuts.State, (int)TurOutsState.NOT_DEFINE);
			turnOuts.ChangeState();
			Assert.AreEqual(turnOuts.State, (int)TurOutsState.NOT_DEFINE);
			Thread.Sleep(20);
			Assert.AreEqual((int)TurOutsState.NOT_DEFINE, turnOuts.State);
		}

		[TestMethod()]
		public void CangeStateTestConstructorWithTwoArg()
		{
			int t = 10;
			IRoadSection leftRoadSection = Mock.Of<IRoadSection>();
			IRoadSection rightRoadSection = Mock.Of<IRoadSection>();
			ITurnOut turnOuts = new TurnOut(leftRoadSection, rightRoadSection);
			turnOuts.TimeOfChange = t;
			Assert.AreEqual((int)TurOutsState.LEFT_ROAD, turnOuts.State);

			turnOuts.ChangeState();
			Assert.AreEqual((int)TurOutsState.NO_ROAD, turnOuts.State);
			Thread.Sleep(t + 10);
			Assert.AreEqual((int)TurOutsState.RIGHT_ROAD, turnOuts.State);
			turnOuts.ChangeState();
			Assert.AreEqual((int)TurOutsState.NO_ROAD, turnOuts.State);
			Thread.Sleep(t + 10);
			Assert.AreEqual((int)TurOutsState.LEFT_ROAD, turnOuts.State);
		}

		[TestMethod()]
		public void ChangeStateTest()
		{
			int t = 10;
			int s = 0;
			IRoadSection leftRoadSection = Mock.Of<IRoadSection>();
			IRoadSection rightRoadSection = Mock.Of<IRoadSection>();
			ITurnOut turnOuts = new TurnOut(leftRoadSection, rightRoadSection);
			turnOuts.TimeOfChange = t;
			var handler = new EventHandler((o, e) =>
			{
				s = ((ITurnOut)o).State;
			});
			turnOuts.StateChanged += handler;
			Assert.AreEqual((int)TurOutsState.LEFT_ROAD, turnOuts.State);
			turnOuts.ChangeState();
			Assert.AreEqual((int)TurOutsState.NO_ROAD, s);
			Thread.Sleep(t + 10);
			Assert.AreEqual((int)TurOutsState.RIGHT_ROAD, s);
			turnOuts.ChangeState();
			Assert.AreEqual((int)TurOutsState.NO_ROAD, s);
			Thread.Sleep(t + 10);
			Assert.AreEqual((int)TurOutsState.LEFT_ROAD, s);
		}
	}
}