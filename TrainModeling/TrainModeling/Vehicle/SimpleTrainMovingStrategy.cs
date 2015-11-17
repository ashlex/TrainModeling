using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Timers;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace TrainModeling
{
	public class SimpleTrainMovingStrategy : IMovingStrategy
	{
		private IVehicle _vehicle;
		private bool _isAction = false;
		private Timer _timer;
		private int _interval = 1000;
		private int _time;

		public SimpleTrainMovingStrategy(IVehicle vehicle)
		{
			_time = 0;
			_vehicle = vehicle;
			_timer = new Timer { Interval = _interval };
			_timer.Elapsed += (sender, args) => { _time++; };
		}

		public bool Start()
		{
			_isAction = true;
			_timer.Elapsed +=Accelerate;
			_timer.Start();

			return true;
		}

		public bool Stop()
		{
			_isAction = false;
			Console.WriteLine("Train is stoped.");
			return true;
		}

		private void Accelerate(object sender, ElapsedEventArgs elapsedEventArgs)
		{
				double v = _vehicle.Speed;
				_vehicle.Speed = v + ((double)_vehicle.TractionForce/ (double)_vehicle.Weight)*_interval/1000;
//				_vehicle.Position.ValueCoordinate.X += ((int) v*_interval) +
//				                                       ((_interval*_vehicle.TractionForce)/(2*_vehicle.Weight));

				Console.WriteLine("Train speed:" + _vehicle.Speed + ". Position [" + _vehicle.Position + "]");
				if (_vehicle.Speed >= _vehicle.MaxSpeed)
				{
					_timer.Elapsed -= Accelerate;
				}
		}

		private void SlowDown(object sender, ElapsedEventArgs elapsedEventArgs)
		{
			
		}
	}
}