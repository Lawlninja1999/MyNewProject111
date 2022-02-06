using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRE.Common.Models;

namespace XRE.Common.Functions.CRUD
{
    public static class CRUD_Functions
    {

        #region CREATE
        public static List<BookingModel> SetupBookings()
        {
            List<BookingModel> newBookings = new List<BookingModel>();
            newBookings.Add(CreateNewBooking());
            newBookings.Add(CreateNewBooking());

            return newBookings;   //List of two bookings in this case. 
        }
 
        public static List<DayModel> SetupDays(List<BookingModel> Bookings)
        {
            List<DayModel> newDays = new List<DayModel>();
            Random gen = new Random();

            foreach(BookingModel Booking in Bookings)
            {
                DateTime start = DateTime.Now;
                start.AddYears(1);
                start.AddDays(gen.Next(100));

                for(int i = 0; i < (gen.Next(3) + 1); i++)
                {
                    DayModel day = new DayModel();
                    day.xre_dayid = Guid.NewGuid();
                    day.xre_bookingrecordid = Booking.xre_bookingid;
                    day.xre_date = start.AddDays(i);
                    newDays.Add(day);
                }
            }
            return newDays;
        }

        
        public static List<ActivityProviderModel> SetupProviders()
        {
            List<ActivityProviderModel> Providers = new List<ActivityProviderModel>();
            Providers.Add(new ActivityProviderModel()
            {
                xre_activityproviderid = Guid.NewGuid(),
                xre_providername = "Tony's Laser skirmish",
                xre_provideraddress = "10 Seidhe Llygad St, Cityname, Victoria 3011",
                xre_providerbusinessphone = "+61 484,000,000"
            });

            Providers.Add(new ActivityProviderModel()
            {
                xre_activityproviderid = Guid.NewGuid(),
                xre_providername = "Grapehill Winery",
                xre_provideraddress = "3  St, Cityname, Victoria 3022",
                xre_providerbusinessphone = "+61 487,000,000"
            });

            Providers.Add(new ActivityProviderModel()
            {
                xre_activityproviderid = Guid.NewGuid(),
                xre_providername = "Mad Skillz Go-karting",
                xre_provideraddress = "68 Formula One St, Trackside, Victoria 3033",
                xre_providerbusinessphone = "+61 488,000,000"
            });

            Providers.Add(new ActivityProviderModel()
            {
                xre_activityproviderid = Guid.NewGuid(),
                xre_providername = "Andrew's Archery Range",
                xre_provideraddress = "79 Bullseye St, Target, Victoria 3055",
                xre_providerbusinessphone = "+61 489,000,000"
            });

            Providers.Add(new ActivityProviderModel()
            {
                xre_activityproviderid = Guid.NewGuid(),
                xre_providername = "VR Adventures",
                xre_provideraddress = "79 Gamer St, FantasyLand, Victoria 3044",
                xre_providerbusinessphone = "+61 481,000,000"
            });

            return Providers;
        }

    
        private static BookingModel CreateNewBooking()
        {
            BookingModel booking = new BookingModel();
            booking.xre_bookingid = Guid.NewGuid();
            booking.xre_startdate = DateTime.MinValue;
            booking.xre_enddate = DateTime.MinValue;

            return booking;
        }
      
        private static DayModel CreateNewDay(BookingModel booking, DateTime date)
        {
            DayModel day = new DayModel();
            day.xre_dayid = Guid.NewGuid();
            day.xre_bookingrecordid = booking.xre_bookingid;
            day.xre_date = date;
            return day;
        }
        #endregion


        #region READ
        public static List<DayModel> GetDaysAgainstBooking(this List<DayModel> Days, BookingModel Booking)
        {
           return Days.Where(day => day.xre_bookingrecordid == Booking.xre_bookingid).ToList();

        }
 

        #endregion


        #region UPDATE
        #endregion


        #region DELETE
        #endregion
        
    }
}
