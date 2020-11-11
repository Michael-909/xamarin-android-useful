using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace Sendingly
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SetDimentions();
        }
        public void SetDimentions()
        {
            mwebView.HeightRequest = App.ScreenHeight;
            mwebView.WidthRequest = App.ScreenWidth;
        }
    }
}
