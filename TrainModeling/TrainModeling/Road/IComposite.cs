using System.Collections.Generic;
using log4net;

namespace TrainModeling
{
	public class Composite:Component
	{
		private readonly List<Component> _components=new List<Component>();
		private static readonly ILog _log = LogManager.GetLogger(typeof(Composite));

		public bool Add(Component component)
		{
			if (_components.Contains(component))
			{
				_log.Debug("Component don't be null");
				return false;
			}
			_components.Add(component);
			return true;
		}

		public bool Remove(Component component)
		{
			if (component == null)
			{
				_log.Debug("Component don't be null");
				return false;
			}
			return _components.Remove(component);
		}
	}
}