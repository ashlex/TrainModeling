namespace TrainModeling
{
	public class SimpleTrain : Vehicle
	{
		private int _weight;
		private int _tractionForce;
		private double _speed;
		private double _maxSpeed;

		public override int Weight
		{
			get { return _weight; }
			set { if (value > 0) _weight = value; }
		}

		public override int TractionForce
		{
			get { return _tractionForce; }
			set { if (value > 0) _tractionForce = value; }
		}

		public override double Speed
		{
			get { return _speed; }
			set { if (value > 0) _speed = value; }
		}

		public override double MaxSpeed
		{
			get { return _maxSpeed; }
			set { if (value > 0) _maxSpeed = value; }
		}

		public SimpleTrain()
		{
			_tractionForce = 3000;
			_maxSpeed = 16.66;
			_weight = 4100;
		}
	}
}