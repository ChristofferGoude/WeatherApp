//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public Location()
        {
            this.WeatherInfoes = new HashSet<WeatherInfo>();
        }
    
        public int LocationID { get; set; }
        public string Location1 { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    
        public virtual ICollection<WeatherInfo> WeatherInfoes { get; set; }
    }
}