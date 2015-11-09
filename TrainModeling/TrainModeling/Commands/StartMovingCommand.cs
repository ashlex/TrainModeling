using System;
using JetBrains.Annotations;

namespace TrainModeling.Commands
{
	public class StartMovingCommand : ICommand
	{
		private readonly IVehicle _vehicle;

		public StartMovingCommand([NotNull] IVehicle vehicle)
		{
			if (vehicle == null) throw new ArgumentNullException();
			_vehicle = vehicle;
		}

		public void Execute()
		{
			_vehicle.StartMoving();
		}
	}
}