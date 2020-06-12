using log4net;
using System;
using System.IO;
using System.Net;
using System.Threading;
using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    public class BsCtl
    {
        private CefBrowser _bs;
        public AutoResetEvent _autoResetEvent;
        private Thread _clear;
        private string _url;
        private BsClient _bsClient;

        public string DocTitle;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(BsCtl));

        public BsCtl()
        {
           
        }

        public string Init(string url)
        {
            _url = url;

            _clear = new Thread(CloseInvalidProcess);
            _clear.Start();

            DocTitle = Guid.NewGuid().ToString("N");//每次打印生成一个GUID
           
            _autoResetEvent = new AutoResetEvent(false);

            var cwi = CefWindowInfo.Create();
            _bsClient = new BsClient(this);
            _bsClient.OnCreated += Bc_OnCreated;
            var bs = new CefBrowserSettings();
            CefBrowserHost.CreateBrowser(cwi, _bsClient, bs, url);

            _autoResetEvent.WaitOne();
            return Path.Combine(ConfigCst.CurPath, DocTitle + ".pdf");
        }

        public void CloseInvalidProcess()
        {
            Thread.Sleep(600000);
            CloseBrowser();
        }

        public void CloseBrowser()
        {
            try
            {
                _bs.GetHost().CloseBrowser(true);

                _autoResetEvent.Set();
                Logger.Info("close browser success:" + _url);
            }
            catch (Exception ex)
            {
                Logger.Error("CloseBrowser", ex);
            }
        }
       

        public void ConvertToPdf()
        {
            if (!Directory.Exists(ConfigCst.CurPath))
                Directory.CreateDirectory(ConfigCst.CurPath);

            int sleepTime = Convert.ToInt16(ConfigCst.LoadBrowserTime);
            Thread.Sleep(sleepTime);

            var settings = new CefPdfPrintSettings
            {
                BackgroundsEnabled = true,
                HeaderFooterEnabled = false
            };
            settings.MarginType = CefPdfPrintMarginType.None;
            _bs.GetHost().PrintToPdf(Path.Combine(ConfigCst.CurPath, DocTitle + ".pdf"), settings, new BsCefPdfPrintCallback(this));
        }

        private void Bc_OnCreated(object sender, EventArgs e)
        {
            _bs = (CefBrowser)sender;
            Logger.Info("create browser success:" + _url);
            _bsClient.OnCreated -= Bc_OnCreated;
        }
    }
}
