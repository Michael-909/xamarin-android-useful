using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.WebView), typeof(Sendingly.Droid.CustomWebViewRenderer))]
namespace Sendingly.Droid
{
    public class CustomWebViewRenderer : ViewRenderer<Xamarin.Forms.WebView, global::Android.Webkit.WebView>
    {
        public CustomWebViewRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var webView = new global::Android.Webkit.WebView(this.Context);
                webView.SetWebViewClient(new WebViewClient());
                webView.SetWebChromeClient(new WebChromeClient());
                WebSettings webSettings = webView.Settings;
                webSettings.JavaScriptEnabled = true;
                webSettings.DomStorageEnabled = true;

                webView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

                webView.SetDownloadListener(new CustomDownloadListener());
                this.SetNativeControl(webView);
                var source = e.NewElement.Source as UrlWebViewSource;
                if (source != null)
                {
                    webView.LoadUrl(source.Url);
                }
            }
        }
    }

    public class CustomDownloadListener : Java.Lang.Object, IDownloadListener
    {
        public void OnDownloadStart(string url, string userAgent, string contentDisposition, string mimetype, long contentLength)
        {
            Launcher.OpenAsync(url);
            //DownloadManager.Request request = new DownloadManager.Request(Android.Net.Uri.Parse(url));
            //request.SetNotificationVisibility(DownloadVisibility.VisibleNotifyCompleted);
            //request.SetDestinationInExternalFilesDir(Android.App.Application.Context, Android.OS.Environment.DirectoryDownloads, "label.pdf");
            //DownloadManager dm = (DownloadManager)Android.App.Application.Context.GetSystemService(Android.App.Application.DownloadService);
            //dm.Enqueue(request);
        }
    }
}