using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class WeatherInfo
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