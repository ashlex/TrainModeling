using System;

namespace TrainModeling
{
	public interface IRoadNode:IComponent
	{
		event EventHandler StateChanged;
		int TimeOfChange { get; set; }

		void ChangeState();
	}
}