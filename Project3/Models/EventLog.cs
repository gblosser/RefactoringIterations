using System.Collections.Generic;

namespace Project3.Models
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