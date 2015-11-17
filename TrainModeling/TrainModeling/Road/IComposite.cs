using System.Collections.Generic;

namespace TrainModeling
{
	public interface IComposite:IComponent
	{
		bool Add(IComponent component);
		bool Remove(IComponent component);
		IEnumerable<IComponent> GetChilds();
	}
}