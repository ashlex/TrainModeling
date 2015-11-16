using System;

namespace TrainModeling
{
	public class RoadSectionStrategy:IVariableChangingStrategy<RoadSectionState>
	{
		private RoadSectionState _newState;
		private readonly IRoadSection _roadSection;

		public RoadSectionStrategy(IRoadSection roadSection)
		{
			_roadSection = roadSection;
			Enum.TryParse(roadSection.State.ToString(), out _newState);
		}

		public void Cange()
		{
			switch (_roadSection.State)
			{
				case (int)RoadSectionState.FREE:
					_newState=RoadSectionState.BUSY;
					break;
				case (int)RoadSectionState.BUSY:
					_newState=RoadSectionState.FREE;
					break;
			}
        }

		public RoadSectionState GeTrafficLightState()
		{
			return _newState;
		}
	}
}