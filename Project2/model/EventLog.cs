using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project2.model
{
	public class EventLog
	{
		public EventLog()
		{
			Events  = new List<string>();
		}

		public List<string> Events { get; }

		public void AddLogMessage(string theMessage)
		{
			Events.Add(theMessage);
		}
	}
}