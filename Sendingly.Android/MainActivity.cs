using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Views.InputMethods;
using Android.Content;
using Java.Interop;
using TinyIoC;
using Sendingly.Services;
using Sendingly.Droid.Services;
using Xamarin.Forms;

namespace Sendingly.Droid
{
    [Activity(Label = "Sendingly", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            TinyIoCContainer.Current.Register<ISoftwareKeyboardService, SoftwareKeyboardService>().AsSingleton();
            TinyIoCContainer.Current.Register(this);
            Forms.Init(this, savedInstanceState, GetType().Assembly);

            base.OnCreate(savedInstanceState);

            App.DeviceHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density) - 22;
            App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density) + 5;
            App.ScreenHeight = App.DeviceHeight;

            Window.AddFlags(WindowManagerFlags.ForceNotFullscreen);
            Window.ClearFlags(WindowManagerFlags.Fullscreen);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 119, 218, 237));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}