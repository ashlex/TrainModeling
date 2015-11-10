using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TrainModeling
{
	public class Road : Composite, IRoadSection
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

	public enum RoadState
	{
		NOT_DEFINE = 0,
		FREE = 1,
		BUZI = 2,
		NOT_AVAIBLE = 3
	}
}