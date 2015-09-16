using System.Collections.Generic;
using System.Web.Http;
using Project3.Models;

namespace Project3.Controllers
{
	public class EventLogController : ApiController
	{
		private readonly EventLog _eventLog;

		public EventLogController(EventLog theEventLog)
		{
			_eventLog = theEventLog;
		}

		// GET: api/EventLog
		public IEnumerable<string> Get()
		{
			return _eventLog.Events;
		}

	}
}
