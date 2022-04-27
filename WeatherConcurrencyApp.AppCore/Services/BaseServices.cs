using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherConcurrencyApp.AppCore.Services
{
    public abstract class BaseServices<T> : IServices<T>
    {
        private IModel<T> Model;

        protected BaseServices(IModel<T> model)
        {
            this.Model = model;
        }

        public void Add(T t)
        {
            Model.Add(t);
        }

        public void Delete(T t)
        {
            Model.Delete(t);
        }

        public bool Delete(int id)
        {
            return Model.Delete(id);
        }

        public List<T> Read()
        {
            return Model.Read();
        }
    }
}
