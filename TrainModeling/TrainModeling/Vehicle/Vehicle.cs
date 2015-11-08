using System;

namespace TrainModeling
{
	public abstract class Vehicle : Base, IVehicle
	{
		private IMovingStrategy _movingStrategy;


		public IMovingStrategy MovingStrategy
		{
			protected get { return _movingStrategy; }
			set { _movingStrategy = value; }
		}


		public abstract int Weight { get; set; }
		public abstract int TractionForce { get; set; }
		public abstract double Speed { get; set; }
		public abstract double MaxSpeed { get; set; }

		public Position Position { get; set; }

		public bool StartMoving()
		{
			if (_movingStrategy == null) return false;
			return _movingStrategy.Start();
		}
		

		public bool StopMoving()
		{
			if (_movingStrategy == null) return false;
			return _movingStrategy.Stop();
		}
	}
}