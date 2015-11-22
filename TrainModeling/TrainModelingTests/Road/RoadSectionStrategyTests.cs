using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TrainModeling.Tests
{
	[TestClass()]
	public class RoadSectionStrategyTests
	{
		[TestMethod()]
		public void RoadSectionStrategyTest()
		{
			var rs = new Mock<IRoadSection>();
			rs.Setup(o => o.State).Returns((int)RoadSectionState.FREE);
			Assert.AreEqual((int)RoadSectionState.FREE, rs.Object.State);
			
			IVariableChangingStrategy<RoadSectionState> t=new RoadSectionStrategy();
			Assert.AreEqual(RoadSectionState.FREE,t.GetState());
		}

		[TestMethod()]
		public void CangeTest()
		{
			var rs = new Mock<IRoadSection>();
			rs.Setup(o => o.State).Returns((int)RoadSectionState.FREE);
			Assert.AreEqual((int)RoadSectionState.FREE, rs.Object.State);
			IVariableChangingStrategy<RoadSectionState> t = new RoadSectionStrategy();
			Assert.AreEqual(RoadSectionState.FREE, t.GetState());
			t.Change();
			Assert.AreEqual(RoadSectionState.BUSY, t.GetState());
		}
		
	}
}