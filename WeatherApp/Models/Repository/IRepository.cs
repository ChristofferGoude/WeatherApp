using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models.Repository
{
    interface IRepository
    {
        void AddWeather(List<WeatherInfo> weatherList);
        void Save();
    }
}
