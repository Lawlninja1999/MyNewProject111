using System;
using System.Collections.Generic;
using System.Text;

namespace XRE.Common.Models
{
    public class ActivityProviderModel
    {
        public Guid xre_activityproviderid { get; set; }            //Primary Key

        //data against record
        public string xre_providername { get; set; }                //Providers name, e.g.  Tony's Laser skirmish
        public string xre_provideraddress { get; set; }             //Providers location, e.g. 10 Mulloway St, Cityname, Victoria 3011
        public string xre_providerbusinessphone { get; set; }       //Providers contact number, e.g. +61 487,000,000
       
    }
}
