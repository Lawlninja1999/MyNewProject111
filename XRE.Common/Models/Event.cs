using System;
using System.Collections.Generic;
using System.Text;

namespace XRE.Common.Models
{
   public class Event
    {
        public Guid EventID { get; set; }
        public string EventName { get; set; }
        public Guid ProviderId { get; set; }
        public Guid DayModelId { get; set; }
    }
}
