using Sendingly.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TinyIoC;

namespace Sendingly.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _event;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            var keyboardService = TinyIoCContainer.Current.Resolve<ISoftwareKeyboardService>();
            keyboardService.Hide += _keyboardService_Hide;
            keyboardService.Show += _keyboardService_Show;
        }

        private void _keyboardService_Show(object sender, SoftwareKeyboardEventArgs args)
        {
            App.ScreenHeight = App.DeviceHeight - 70;
            App.UpdateWebViewHeight();
            Event = "Show event handler invoked";
        }

        private void _keyboardService_Hide(object sender, SoftwareKeyboardEventArgs args)
        {
            App.ScreenHeight = App.DeviceHeight;
            App.UpdateWebViewHeight();
            Event = "Hide event handler invoked";
        }

        public string Event
        {
            get { return _event; }
            set
            {
                _event = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
