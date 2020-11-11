using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sendingly.Droid.Renderers;
using Sendingly.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(ScrollEntryRenderer))]
namespace Sendingly.Droid.Renderers
{
    public class ScrollEntryRenderer : EntryRenderer
    {
        public ScrollEntryRenderer(Context context) : base(context) {}
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            EditorsScrollingHelper.AttachToControl(Control, this);
        }
    }
}