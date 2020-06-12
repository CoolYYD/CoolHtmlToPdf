using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    class BsCefPdfPrintCallback : CefPdfPrintCallback
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(BsCefPdfPrintCallback));
        private BsCtl bsCtl;
        public BsCefPdfPrintCallback(BsCtl bsCtl)
        {
            this.bsCtl = bsCtl;
        }
        protected override void OnPdfPrintFinished(string path, bool ok)
        {
            logger.Info("Convert to Pdf path:" + Path.Combine(ConfigCst.CurPath, bsCtl.DocTitle + ".pdf"));
            bsCtl.CloseBrowser();
        }
    }
}
