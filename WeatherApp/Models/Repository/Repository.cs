using WeatherApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Repository
{
    public class Repository : IRepository
    {
        private bool _disposed = false;
        private WeatherAppEntities _entities = new WeatherAppEntities();

        public void AddWeather(List<WeatherInfo> weatherList)
        {
            foreach (WeatherInfo item in weatherList)
            {
                _entities.AddWeather(item.LocationID, item.Location, item.Time, item.Description, item.Temp, item.Icon);
            }
        }

        public void DeleteWeather(int locationID)
        {
            //Delete weather
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            _disposed = true;
        }
    }
}