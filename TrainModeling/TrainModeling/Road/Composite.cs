﻿using System.Collections.Generic;
using log4net;

namespace TrainModeling
{
	public abstract class Composite:Component,IComposite
	{
		private readonly List<IComponent> _components=new List<IComponent>();
		private static readonly ILog _log = LogManager.GetLogger(typeof(Composite));

		public bool Add(IComponent component)
		{
			if (_components.Contains(component))
			{
				_log.Debug("Component don't be null");
				return false;
			}
			_components.Add(component);
			return true;
		}

		public bool Remove(IComponent component)
		{
			if (component == null)
			{
				_log.Debug("Component don't be null");
				return false;
			}
			return _components.Remove(component);
		}

		public IEnumerable<IComponent> GetChilds()
		{
			return _components;
		}
	}
}