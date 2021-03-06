using System;
using System.Collections.Generic;
using System.Linq;
using XRE.Common.Functions;
using XRE.Common.Functions.CRUD;
using XRE.Common.Models;

namespace XRE_Grad_Test
{
    class Program
    {
        public 
        static void Main(string[] args)
        {
            List<BookingModel> Bookings = CRUD_Functions.SetupBookings();
            List<DayModel> Days = CRUD_Functions.SetupDays(Bookings);
            List<ActivityProviderModel> ActivityProviders = CRUD_Functions.SetupProviders();  
            List<Event> rrr = NewExtensions.SetupEvents(ActivityProviders, Days);


            //Task Three
            NewExtensions.GetStartAndEndTime(rrr, Days, Bookings);

            //Task Four
            NewExtensions.GetNumberOfEvents(rrr, Days);

            //Task Five
            NewExtensions.CreateJson(rrr, ActivityProviders);
          
           




            //List of activities here
        }
    }
}
