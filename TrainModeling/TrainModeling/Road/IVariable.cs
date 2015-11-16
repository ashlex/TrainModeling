using System;

namespace TrainModeling
{
	public interface IVariable
	{
		event EventHandler StateChanged;
		int TimeOfChange { get; set; }

		void ChangeState();
	}
}