using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TrainModeling.Conditions;

namespace TrainModeling.Tests
{
	[TestClass()]
	public class RoadSectionStrategyTests
	{
		[TestMethod()]
		public void GetState_ByDefault_IsUndefine()
		{
			IVariableChangingStrategy<RoadSectionState> t=CreateRoadSectionStrategy(RoadSectionState.UNDEFINE);
			Assert.AreEqual(RoadSectionState.UNDEFINE,t.GetState());
		}

		[TestMethod()]
		public void GetState_WhenComponentUndefine_IsUndefine()
		{
			IVariableChangingStrategy<RoadSectionState> t= CreateRoadSectionStrategy(RoadSectionState.UNDEFINE);
			Assert.AreEqual(RoadSectionState.UNDEFINE,t.GetState());
			var comp=new Mock<IComponent>();
			comp.Setup(component => component.State).Returns((int) RoadSectionState.UNDEFINE);
			t.Component = comp.Object;
			Assert.AreEqual(RoadSectionState.UNDEFINE, t.GetState());
		}

		[TestMethod()]
		public void GetState_WhenComponentFree_IsFree()
		{
			IVariableChangingStrategy<RoadSectionState> t= CreateRoadSectionStrategy(RoadSectionState.FREE);
			Assert.AreEqual(RoadSectionState.FREE,t.GetState());
			var comp=new Mock<IComponent>();
			comp.Setup(component => component.State).Returns((int) RoadSectionState.FREE);
			t.Component = comp.Object;
			Assert.AreEqual(RoadSectionState.FREE, t.GetState());
		}

		[TestMethod()]
		public void GetState_WhenComponentBusy_IsBusy()
		{
			IVariableChangingStrategy<RoadSectionState> t=CreateRoadSectionStrategy(RoadSectionState.BUSY);
			Assert.AreEqual(RoadSectionState.BUSY,t.GetState());
			var comp=new Mock<IComponent>();
			comp.Setup(component => component.State).Returns((int) RoadSectionState.BUSY);
			t.Component = comp.Object;
			Assert.AreEqual(RoadSectionState.BUSY, t.GetState());
		}
		[TestMethod()]
		public void Change_ByDefault_IsUndefine()
		{
			IVariableChangingStrategy<RoadSectionState> t= CreateRoadSectionStrategy(RoadSectionState.UNDEFINE);
			Assert.AreEqual(RoadSectionState.UNDEFINE,t.GetState());
			t.Change();
			Assert.AreEqual(RoadSectionState.UNDEFINE, t.GetState());
		}


		[TestMethod()]
		public void Change_WhenComponentFree_IsBusy()
		{
			IVariableChangingStrategy<RoadSectionState> t = CreateRoadSectionStrategy(RoadSectionState.FREE);
			Assert.AreEqual(RoadSectionState.FREE, t.GetState());
			t.Change();
			Assert.AreEqual(RoadSectionState.BUSY, t.GetState());
		}

		[TestMethod()]
		public void Change_WhenComponentBusy_IsFree()
		{
			IVariableChangingStrategy<RoadSectionState> t = CreateRoadSectionStrategy(RoadSectionState.BUSY);
			Assert.AreEqual(RoadSectionState.BUSY, t.GetState());
			t.Change();
			Assert.AreEqual(RoadSectionState.FREE, t.GetState());
		}

		[TestMethod()]
		public void Change_WhenComponentUndefine_IsUndefine()
		{
			IVariableChangingStrategy<RoadSectionState> t = CreateRoadSectionStrategy(RoadSectionState.UNDEFINE);
			Assert.AreEqual(RoadSectionState.UNDEFINE, t.GetState());
			t.Change();
			Assert.AreEqual(RoadSectionState.UNDEFINE, t.GetState());
		}


		private RoadSectionStrategy CreateRoadSectionStrategy(RoadSectionState componentState)
		{
			var comp = new Mock<IComponent>();
			comp.Setup(component => component.State).Returns((int)componentState);
			return new RoadSectionStrategy(comp.Object);
		}
    }
}