namespace TrainModeling
{
	/// <summary>
	/// Это интерфейс который необходимо реализовывать для лубой стратегии изменения состояния.
	/// </summary>
	/// <typeparam name="T"> Перечислимый тип в контексте которого будет возращенно состояние</typeparam>
	public interface IVariableChangingStrategy<T>
	{
		IComponent Component { set;}
		void Change();
		T GetState();
	}
}