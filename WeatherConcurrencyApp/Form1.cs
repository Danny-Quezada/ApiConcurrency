using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WeatherConcurrencyApp.AppCore.Interfaces;
using WeatherConcurrencyApp.Infrastructure.OpenWeatherClient;
using WeatherConcurrentApp.Domain.Entities;
using WeatherConcurrentApp.Domain.Enum;

namespace WeatherConcurrencyApp
{
    public partial class FrmMain : Form
    {
        public IHttpOpenWeatherClientService httpOpenWeatherClient;
        public OpenWeather openWeather;
        public IWeatherServices weatherServices;
        List<OpenWeatherCities> cities;
        public FrmMain(IHttpOpenWeatherClientService httpOpenWeatherClient, IWeatherServices weatherServices)
        {
            InitializeComponent();
            this.httpOpenWeatherClient = httpOpenWeatherClient;
            this.weatherServices = weatherServices;
            //cities = httpOpenWeatherClient.GetCities();
            cities = httpOpenWeatherClient.GetCities(Properties.Resources.city_list);
            //if (cities.Count != 0)
            //{
            //    MessageBox.Show("Test");
            //}
            comboBox1.DataSource = cities.Select(x => x.Name).ToList();

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData(combData);
            comboBox1.AutoCompleteCustomSource = combData;
            comboBox2.Items.AddRange(Enum.GetValues(typeof(Class1)).Cast<object>().ToArray());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(Request).Wait();
                if (openWeather == null)
                {
                    throw new NullReferenceException("Fallo al obtener el objeto OpeWeather.");
                }
                weatherServices.Add(openWeather);
                string imageLocation = httpOpenWeatherClient.GetImage(openWeather);
                WeatherPanel weatherPanel = new WeatherPanel(openWeather, imageLocation);
                flpContent.Controls.Add(weatherPanel);
            }
            catch (Exception)
            {

            }

        }

        public async Task Request()
        {
            //openWeather = await httpOpenWeatherClient.GetWeatherByCityNameAsync(textBox1.Text);
            openWeather = await httpOpenWeatherClient.GetWeatherByCityNameAsync(comboBox1.SelectedValue.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            foreach (OpenWeatherCities city in cities)
            {
                dataCollection.Add(city.Name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                limpiarfly();
               
                Expression<Func<OpenWeather, bool>> expression = u => u.Name.Contains(comboBox1.SelectedValue.ToString());
                var seleccion = weatherServices.findWByCity(expression);
                foreach(OpenWeather weather in seleccion)
                {
                    string imageLocation = httpOpenWeatherClient.GetImage(weather);
                    WeatherPanel weathers = new WeatherPanel(weather, imageLocation );
                    flpContent.Controls.Add(weathers);
                }
            }
            if (comboBox2.SelectedIndex == 0)
            {
                limpiarfly();
                var all = weatherServices.Read();
                foreach (OpenWeather weather in all)
                {
                    string imageLocation = httpOpenWeatherClient.GetImage(weather);
                    WeatherPanel weathers = new WeatherPanel(weather, imageLocation);
                    flpContent.Controls.Add(weathers);
                }
            }
        }

        private void flpContent_Paint(object sender, PaintEventArgs e)
        {

        }
        private void limpiarfly()
        {
            foreach (Control c in flpContent.Controls)
            {
                ((Panel)c).Dispose();

            }
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            openWeather = await httpOpenWeatherClient.GetWeatherByCityNameAsync("Managua");
            weatherServices.Add(openWeather);
            MessageBox.Show(weatherServices.Read()[0].Weather[0].Description);
        }
    }
}
