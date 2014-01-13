using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.ViewModels
{
    public class LocationName
    {
        [Required(ErrorMessage = "You must enter a search term")]
        [DisplayName("Search")]
        public string LocationString { get; set; }
    }
}