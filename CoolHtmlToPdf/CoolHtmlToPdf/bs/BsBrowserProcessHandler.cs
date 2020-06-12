using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    class BsBrowserProcessHandler : CefBrowserProcessHandler
    {
        private readonly BsPrintHandler _bsPrintHandler;

        public BsBrowserProcessHandler()
        {
            _bsPrintHandler = new BsPrintHandler();
        }

        protected override CefPrintHandler GetPrintHandler()
        {
            return _bsPrintHandler;
        }
    }
}
