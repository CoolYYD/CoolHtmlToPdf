using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    public class BsDownloadHandler : CefDownloadHandler
    {
        protected override void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
        {
            callback.Continue(string.Empty, true);
        }
        protected override void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
        {
            if (downloadItem.IsComplete)
            {
                MessageBox.Show("下载成功");
                if (browser.IsPopup && !browser.HasDocument)
                {
                 //   browser.GetHost().ParentWindowWillClose();
                    browser.GetHost().CloseBrowser();
                }
            }
        }
    }
}
