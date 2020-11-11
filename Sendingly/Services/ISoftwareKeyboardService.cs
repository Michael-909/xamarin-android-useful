using System;
using System.Collections.Generic;
using System.Text;

namespace Sendingly.Services
{
    public interface ISoftwareKeyboardService
    {
        event SoftwareKeyboardEventHandler Hide;

        event SoftwareKeyboardEventHandler Show;
    }
}
