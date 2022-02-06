using System;
using System.Collections.Generic;
using System.Text;

namespace XRE.Common.Models
{
    public class DayModel
    {
        public Guid xre_dayid { get; set; }                 //Primary Key

        //data against record
        public Guid xre_bookingrecordid { get; set; }       //The BookingModel id which this record relates to. 
        public DateTime xre_date { get; set; }              //The date of this DayModel. 
        public int xre_activitycount { get; set; }          //The number of Activities on this day. 
    }
}
