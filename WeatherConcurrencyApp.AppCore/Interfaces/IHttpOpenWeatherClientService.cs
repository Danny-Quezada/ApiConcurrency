using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherConcurrentApp.Domain.Entities;

namespace WeatherConcurrencyApp.AppCore.Interfaces
{
    public interface IHttpOpenWeatherClientService
    {
        Task<OpenWeather> GetWeatherByCityNameAsync(string city);
        string GetImage(OpenWeather ow);
        //List<OpenWeatherCities> GetCities();

        List<OpenWeatherCities> GetCities(byte[] byteArray);
    }
}
