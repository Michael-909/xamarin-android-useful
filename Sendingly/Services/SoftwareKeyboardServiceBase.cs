using Sendingly.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sendingly.Services
{
    public abstract class SoftwareKeyboardServiceBase : ISoftwareKeyboardService
    {
        public virtual event SoftwareKeyboardEventHandler Hide;

        public virtual event SoftwareKeyboardEventHandler Show;

        public void InvokeKeyboardHide(SoftwareKeyboardEventArgs args)
        {
            OnHide();
            var handler = Hide;
            handler?.Invoke(this, args);
        }

        public void InvokeKeyboardShow(SoftwareKeyboardEventArgs args)
        {
            var handler = Show;
            handler?.Invoke(this, args);
        }

        private void OnHide()
        {
            if (Application.Current.MainPage != null)
            {
                Application.Current.MainPage.SetTranslation(0);
            }
        }
    }
}
