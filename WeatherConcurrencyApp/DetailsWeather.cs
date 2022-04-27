using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherConcurrencyApp
{
    public partial class DetailsWeather : UserControl
    {
        public DetailsWeather(string detail, string value)
        {
            InitializeComponent();

            this.lblDetail.Text = detail;
            this.lblDetailValue.Text = value;
        }
    }
}
