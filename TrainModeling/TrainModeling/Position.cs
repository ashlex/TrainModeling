namespace TrainModeling
{
	public class Position
	{
		public ICoordinate ValueCoordinate { get; set; }

		private IRoadSection _roadSection;

		public override string ToString()
		{
			return "R:"+_roadSection+ValueCoordinate;
		}
	}
}