using System;
using System.Collections.Generic;
using System.Text;

namespace Sendingly.Services
{
    public class SoftwareKeyboardEventArgs : EventArgs
    {
        public SoftwareKeyboardEventArgs(bool isVisible)
        {
            IsVisible = isVisible;
        }

        public bool IsVisible { get; private set; }
    }
}
