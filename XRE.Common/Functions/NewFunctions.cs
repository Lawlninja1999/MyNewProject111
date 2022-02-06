using System;
using System.Collections.Generic;
using System.Linq;
using XRE.Common.Models;
using Newtonsoft;
using Newtonsoft.Json;

namespace XRE.Common.Functions
{
    public static class NewExtensions
    {
      

        public static List<Event> SetupEvents(List<ActivityProviderModel> activityProviders, List<DayModel> bookings)
        {
            Random ran;
            Random ra;

            ran = new Random();ra = new Random();
            List<Event> events = new List<Event>();
            events.Add(new Event()
            {
                EventID = Guid.NewGuid(),
                EventName = "Event One"
              ,
                ProviderId = activityProviders.Select(m => m.xre_activityproviderid).ElementAt(ran.Next(activityProviders.Count())),
                  DayModelId = bookings.Select(m => m.xre_dayid).ElementAt(ra.Next(bookings.Count())),
            });
            events.Add(new Event()
            {
                EventID = Guid.NewGuid(),
                EventName = "Event two"
     ,
                ProviderId = activityProviders.Select(m => m.xre_activityproviderid).ElementAt(ran.Next(activityProviders.Count())),
                DayModelId = bookings.Select(m => m.xre_dayid).ElementAt(ra.Next(bookings.Count())),
            });
            events.Add(new Event()
            {
                EventID = Guid.NewGuid(),
                EventName = "Event three"
,
                ProviderId = activityProviders.Select(m => m.xre_activityproviderid).ElementAt(ran.Next(activityProviders.Count())),
                DayModelId = bookings.Select(m => m.xre_dayid).ElementAt(ra.Next(bookings.Count())),
            });
            events.Add(new Event()
            {
                EventID = Guid.NewGuid(),
                EventName = "Event four"
,
                ProviderId = activityProviders.Select(m => m.xre_activityproviderid).ElementAt(ran.Next(activityProviders.Count())),
                DayModelId = bookings.Select(m => m.xre_dayid).ElementAt(ra.Next(bookings.Count())),
            });
            return events;
        }

        public static void GetNumberOfEvents(List<Event> events, List<DayModel> dayModels)
        {

            var group = events.GroupBy(m => m.DayModelId);
            foreach (var item in group)
            {
                var DaysList = dayModels.Where(x => x.xre_dayid == item.Key);
                Console.WriteLine(string.Format("\nAll Events Taking place on this date (Date ID): {0} ({1})", item.Key, item.Count()));

                foreach (var m in DaysList)
                {
                    Console.WriteLine(string.Format("{0}", m.xre_date));
                    m.xre_activitycount = item.Count();
                }
                foreach (var v in item)
                {
                    Console.WriteLine(string.Format("{0}", v.EventName));
                }
            }

        }
            public static void GetStartAndEndTime(List<Event> events, List<DayModel> dayModels, List<BookingModel> bookings)
        {
         
            foreach (var eventItem in events)
            {
                var DaysList = dayModels.Where(x => x.xre_dayid == eventItem.DayModelId);
                Console.WriteLine(string.Format("Event Name is: {0}", eventItem.EventName));
                Console.WriteLine(string.Format("Event ID is: {0}", eventItem.EventID));
                Console.WriteLine(string.Format("Provider ID is: {0}", eventItem.ProviderId));
                foreach (var DaysItem in DaysList)
                {
                    var BookingList = bookings.Where(m => m.xre_bookingid == DaysItem.xre_bookingrecordid);
                    Console.WriteLine(string.Format("Event StartDate is: {0}", DaysItem.xre_date));
                  
                    foreach (var Start_EndTIme in BookingList)
                    {
                        Console.WriteLine(string.Format("Event StartTime is: {0}", Start_EndTIme.xre_startdate));
                        Console.WriteLine(string.Format("Event EndTIme is: {0}\n", Start_EndTIme.xre_enddate));
                    }

                }
            }

        }
        public static void CreateJson(List<Event> events, List<ActivityProviderModel>  activityProviders)
        {
            List<ActivityProviderModel> Lis = new List<ActivityProviderModel>();

            foreach (var item in events)
            {
                var doThis = activityProviders.Where(m => m.xre_activityproviderid == item.ProviderId);
                foreach (var thi in doThis)
                {
                    Lis.Add(thi);
                  

                }
                
            }
           var r= JsonConvert.SerializeObject(Lis.Distinct().ToList());
            Console.WriteLine("\n" + r + "\n");




        }
    }
}
