using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GWeathApp
{
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage ()
		{
			InitializeComponent ();
            this.Title = "GWeath App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;

            this.BindingContext = new Weather();
		}

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                this.BindingContext = weather;
                getWeatherBtn.Text = "Search Again";
            }
            
        }
	}
}