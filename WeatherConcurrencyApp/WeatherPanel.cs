using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherConcurrentApp.Domain.Entities;

namespace WeatherConcurrencyApp
{
    public partial class WeatherPanel : UserControl
    {
        //public WeatherPanel(string imageLocation, string city, string temperature, string weatherDesc)
        //{
        //    InitializeComponent();

        //    lblCity.Text = city;
        //    lblTemperature.Text = temperature;
        //    lblWeather.Text = weatherDesc;
        //    pictureBox1.ImageLocation = imageLocation;
        //}
        public WeatherPanel(OpenWeather openWeather, string imageLocation)
        {
            InitializeComponent();

            lblCity.Text = openWeather.Name;
            lblTemperature.Text = openWeather.Main.Temp.ToString();
            lblWeather.Text = openWeather.Weather[0].Main;
            pictureBox1.ImageLocation = imageLocation;
            addDetailsweather(openWeather);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void addDetailsweather(OpenWeather openWeather)
        {
            //for (int i=0;i<1;i++)
            //{
            //    flpContent.Controls.Add(new DetailsWeather());
            //}
            flpContent.Controls.Add(new DetailsWeather("Wind Speed", openWeather.Wind.Speed.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Weather Description", openWeather.Weather[0].Description));
            flpContent.Controls.Add(new DetailsWeather("Maximum temperature", openWeather.Main.Temp_max.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Minimum temperature", openWeather.Main.Temp_min.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Humidity", openWeather.Main.Humidity.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Pressure", openWeather.Main.Pressure.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Clouds", openWeather.Clouds.All.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Visibility", openWeather.Visibility.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Sunrise", openWeather.Sys.Sunrise.ToString()));
            flpContent.Controls.Add(new DetailsWeather("Sunset", openWeather.Sys.Sunset.ToString()));
        }

        private void lblCity_Click(object sender, EventArgs e)
        {

        }
    }
}
