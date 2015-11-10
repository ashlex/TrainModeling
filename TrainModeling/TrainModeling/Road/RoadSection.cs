namespace TrainModeling
{
	public class RoadSection:Component,IRoadSection
	{
		private double _length;
		public override int State { get; }
		public double Length { get { return _length; } }

		public RoadSection()
		{
			_length = 0;
		}


		public ICoordinate GetPointBegin()
		{
			throw new System.NotImplementedException();
		}

		public ICoordinate GetCoordinate(double distance)
		{
			throw new System.NotImplementedException();
		}
	}
}