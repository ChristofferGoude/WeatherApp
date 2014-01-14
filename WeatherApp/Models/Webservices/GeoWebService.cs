using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WeatherApp.ViewModels;

namespace WeatherApp.Models.Webservices
{
    public class GeoWebService
    {
        public Location GetLocationInfo(LocationName location)
        {
            Location checkedLocation = new Location();

            //Create a new XML document, create the string from user input, and load the XML.
            XmlDocument xml = new XmlDocument();
            String xmlString = String.Format("http://api.geonames.org/search?q={0}&maxRows=10&lang=es&username=crippegoude&style=full", location.LocationString);
            xml.Load(xmlString);

            XmlNodeList xmlNodeList = xml.SelectNodes("/geonames/geoname");

            try
            {
                //Get the information from the first location found
                checkedLocation.LocationID = Convert.ToInt32(xmlNodeList[0]["geonameId"].InnerText);
                checkedLocation.Lat = xmlNodeList[0]["lat"].InnerText;
                checkedLocation.Lng = xmlNodeList[0]["lng"].InnerText;
                checkedLocation.Location1 = location.LocationString;
            }
            catch (XmlException)
            {
                throw new Exception();
            }
            return checkedLocation;
        }
    }
}