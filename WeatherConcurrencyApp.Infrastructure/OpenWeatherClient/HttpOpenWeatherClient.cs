using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherConcurrencyApp.Common;
using WeatherConcurrentApp.Domain.Entities;
using WeatherConcurrentApp.Domain.Interfaces;

namespace WeatherConcurrencyApp.Infrastructure.OpenWeatherClient
{
    public class HttpOpenWeatherClient : IHttpOpenWeatherClient
    {
        public async Task<OpenWeather> GetWeatherByCityNameAsync(string city)
        {
           
            string url = $"{AppSettings.ApiUrl}{city}&units={AppSettings.Units}&lang=sp&appid={AppSettings.Token}";
            string jsonObject = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    jsonObject = await httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
                }
                   
                if(string.IsNullOrEmpty(jsonObject))
                {
                    throw new NullReferenceException("El objeto json no puede ser null.");
                }

                return Newtonsoft.Json.JsonConvert.DeserializeObject<OpenWeather>(jsonObject);
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public string GetImage(OpenWeather ow)
        {
            string imageLocation = $"{AppSettings.Image}{ow.Weather[0].Icon}.png";
            return imageLocation;
        }

        public List<OpenWeatherCities> GetCities(byte[] byteArray)
        {

            string jsonStr = Encoding.UTF8.GetString(byteArray);
            return JsonConvert.DeserializeObject<List<OpenWeatherCities>>(jsonStr);
        }

        //public List<OpenWeatherCities> GetCities()
        //{
        //    //List<OpenWeatherCities> cities;
        //    //using (StreamReader file = File.OpenText(AppSettings.Cities))
        //    //{
        //    //    JsonSerializer serializer = new JsonSerializer();
        //    //    cities = (List<OpenWeatherCities>)serializer.Deserialize(file, typeof(List<OpenWeather>));
        //    //}
        //    //return cities;

        //    List<OpenWeatherCities> cities = JsonConvert.DeserializeObject<List<OpenWeatherCities>>(File.ReadAllText(AppSettings.Cities));
        //    return cities;
        //}
    }
}
