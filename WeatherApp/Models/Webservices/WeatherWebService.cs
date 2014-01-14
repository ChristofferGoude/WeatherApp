using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace WeatherApp.Models.Webservices
{
    public class WeatherWebService
    {
        public List<WeatherInfo> GetWeatherInfo(Location location)
        {
            //Create the list in which we will put all our weatherInfo objects.
            List<WeatherInfo> weatherList = new List<WeatherInfo>();

            //Create a new XML document, create the string from user input, and load the XML.
            XmlDocument xml = new XmlDocument();
            String xmlString = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?lat={0}&lon={1}&units=metric&cnt=5&lang=en&mode=xml&app_id=850cd19d2459a0c93e80bb44d19a05b2", location.Lat, location.Lng);
            xml.Load(xmlString);

            //Create a nodelist from the certain point in the XML doc we want.
            XmlNodeList xmlNodeList = xml.SelectNodes("/weatherdata/forecast/time");

            //Create weatherinfo objects.
            foreach(XmlNode item in xmlNodeList)
            {
                WeatherInfo weatherItem = new WeatherInfo();

                //Set all weatherinformation
                weatherItem.LocationID = location.LocationID;
                weatherItem.Location = location;
                weatherItem.Time = item.Attributes["day"].Value;
                weatherItem.Description = item["symbol"].Attributes["name"].Value;
                weatherItem.Icon = String.Format("http://openweathermap.org/img/w/{0}.png", item["symbol"].Attributes["var"].Value);

                //Check to see if the temperature for mid-day period exists. If not, take next one, and so on
                if (item["temperature"].Attributes["day"].Value != null)
                {
                    weatherItem.Temp = item["temperature"].Attributes["day"].Value;
                }
                else if (item["temperature"].Attributes["eve"].Value != null)
                {
                    weatherItem.Temp = item["temperature"].Attributes["eve"].Value;
                }
                else
                {
                    weatherItem.Temp = item["temperature"].Attributes["morn"].Value;
                }
                
                
                weatherList.Add(weatherItem);
            }

            return weatherList;
        }
    }
}