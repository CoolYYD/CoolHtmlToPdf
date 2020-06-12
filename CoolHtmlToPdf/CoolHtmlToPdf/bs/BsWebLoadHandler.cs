using log4net;
using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    class BsWebLoadHandler : CefLoadHandler
    {
        private readonly BsCtl _bsCtl;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(BsWebLoadHandler));

        public BsWebLoadHandler(BsCtl bsCtl)
        {
            _bsCtl = bsCtl;
        }

        protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
        {
            if (frame.IsMain)
            {
                _bsCtl.ConvertToPdf();
            }
        }

        protected override void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
        {
            base.OnLoadError(browser, frame, errorCode, errorText, failedUrl);
            _bsCtl.CloseBrowser();
        }
    }
}
