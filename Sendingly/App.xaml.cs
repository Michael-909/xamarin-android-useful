using Sendingly.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sendingly
{
    public partial class App : Application
    {
        public static int ScreenWidth;
        public static int ScreenHeight;
        public static int DeviceHeight;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage()
            {
                BindingContext = new MainPageViewModel()
            };
        }
        public static void UpdateWebViewHeight()
        {
            (Application.Current.MainPage as MainPage).SetDimentions();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
