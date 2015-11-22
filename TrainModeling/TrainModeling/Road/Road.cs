using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TrainModeling.Conditions;

namespace TrainModeling
{
	public class Road : Composite
	{
		public ICoordinate GetPointBegin()
		{
			throw new NotImplementedException();
		}

		public ICoordinate GetCoordinate(double distance)
		{
			throw new NotImplementedException();
		}

		#region Constructors

		public Road()
		{
		}

		#endregion

		#region Filds and properties

		private readonly RoadState _state = RoadState.NOT_DEFINE;
		public override int State
		{
			get { return (int) _state; }
		}

		public double Length
		{
			get
			{
				return this.GetChilds().OfType<IRoadSection>().Sum(child => child.Length);
			}
		}

		#endregion
	}


}