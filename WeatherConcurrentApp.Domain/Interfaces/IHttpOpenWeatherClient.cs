using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherConcurrentApp.Domain.Entities;

namespace WeatherConcurrentApp.Domain.Interfaces
{
    public interface IHttpOpenWeatherClient
    {
       Task<OpenWeather> GetWeatherByCityNameAsync(string city);
       string GetImage(OpenWeather ow);
       //List<OpenWeatherCities> GetCities();
       List<OpenWeatherCities> GetCities(byte[] byteArray);
    }
}
