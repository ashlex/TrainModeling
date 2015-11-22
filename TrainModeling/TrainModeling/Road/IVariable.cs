using System;

namespace TrainModeling
{
	/// <summary>
	/// Этот интерфейс должны реализовывать все объекты которые могут изменять своё состояние
	/// </summary>
	public interface IVariable
	{
		/// <summary>
		/// Событие смены состояния
		/// </summary>
		event EventHandler StateChanged;
		/// <summary>
		/// Время смены состояния
		/// </summary>
		int TimeOfChange { get; set; }

		void ChangeState();
	}
}