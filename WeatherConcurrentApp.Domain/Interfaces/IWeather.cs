
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeatherConcurrentApp.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IWeather : IModel<OpenWeather>
    {
        List<OpenWeather> findWByCity(Expression<Func<OpenWeather, bool>> where);

    }
}