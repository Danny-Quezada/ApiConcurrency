using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WeatherConcurrencyApp.AppCore.Interfaces;
using WeatherConcurrentApp.Domain.Entities;

namespace WeatherConcurrencyApp.AppCore.Services
{
    public class WeatherServices : BaseServices<OpenWeather>, IWeatherServices
    {
        IWeather weather;
        public WeatherServices(IWeather model) : base(model)
        {
            this.weather = model;
        }
        public List<OpenWeather> findWByCity(Expression<Func<OpenWeather, bool>> where)
        {
            return weather.findWByCity(where);
        }
    }
}
