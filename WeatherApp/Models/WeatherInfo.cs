using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    [MetadataType(typeof(WeatherInfo_MetaData))]
    public partial class WeatherInfo
    {
    }

    public class WeatherInfo_MetaData
    {
        public int WeatherInfoID { get; set; }
        public int LocationID { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string Icon { get; set; }
    }
}