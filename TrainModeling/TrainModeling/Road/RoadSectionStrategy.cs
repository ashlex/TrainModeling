using System;
using log4net;
using TrainModeling.Conditions;

namespace TrainModeling
{
	public class RoadSectionStrategy : IVariableChangingStrategy<RoadSectionState>
	{
		private RoadSectionState _newState;
		private IComponent _component;
		private static readonly ILog log = LogManager.GetLogger(typeof (RoadSectionStrategy));

		public IComponent Component
		{
			set
			{
				_component = value;
				Enum.TryParse(_component.State.ToString(), out _newState);
			}
		}

		public RoadSectionStrategy(IComponent component)
		{
			Component = component;
		}

		/// <summary>
		/// Select new state.If component is undefine then 
		/// </summary>
		public void Change()
		{
			if (_component != null)
			{
				switch (_component.State)
				{
					case (int) RoadSectionState.FREE:
						_newState = RoadSectionState.BUSY;
						break;
					case (int) RoadSectionState.BUSY:
						_newState = RoadSectionState.FREE;
						break;
					default:
						_newState = RoadSectionState.UNDEFINE;
						break;
				}
			}
			else
			{
				_newState = RoadSectionState.UNDEFINE;
				log.Error("Error to executing a Change method. Field of _component is not initialized.");
			}
		}

		public RoadSectionState GetState()
		{
			return _newState;
		}
	}
}