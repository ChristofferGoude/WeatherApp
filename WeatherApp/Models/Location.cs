using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string City { get; set; }
    }
}