namespace TrainModeling
{
	public class Position
	{
		public Coordinate ValueCoordinate { get; set; }

		private IRoad _road;

		public override string ToString()
		{
			return "R:"+_road+ValueCoordinate;
		}
	}
}