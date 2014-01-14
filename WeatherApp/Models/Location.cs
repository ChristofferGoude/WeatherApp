using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    [MetadataType(typeof(Location_MetaData))]
    public partial class Location
    {
    }

    public class Location_MetaData
    {
        public int LocationID { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string City { get; set; }
    }
}