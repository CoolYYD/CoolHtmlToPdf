using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    public class BsApp : CefApp
    {
        public BsApp()
        {
            _cefBrowserProcessHandler = new BsBrowserProcessHandler();
        }
        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {

        }

        private BsBrowserProcessHandler _cefBrowserProcessHandler;

        protected override CefBrowserProcessHandler GetBrowserProcessHandler()
        {
            return _cefBrowserProcessHandler;
        }
    }
}
