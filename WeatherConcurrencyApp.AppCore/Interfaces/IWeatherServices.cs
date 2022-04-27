using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WeatherConcurrentApp.Domain.Entities;

namespace WeatherConcurrencyApp.AppCore.Interfaces
{
    public interface IWeatherServices : IServices<OpenWeather>
    {
        List<OpenWeather> findWByCity(Expression<Func<OpenWeather, bool>> where);
    }
}
