using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            buttonNavi.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new SubPage());
            };
        }


	}
}
