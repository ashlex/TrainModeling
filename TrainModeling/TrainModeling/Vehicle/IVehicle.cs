namespace TrainModeling
{
	public interface IVehicle
	{
		int Weight { get; set; }
		int TractionForce { get; set; }
		double Speed { get; set; }
		double MaxSpeed { get; set; }
		Position Position { get; set; }
		bool StartMoving();
		bool StopMoving();
	}
}