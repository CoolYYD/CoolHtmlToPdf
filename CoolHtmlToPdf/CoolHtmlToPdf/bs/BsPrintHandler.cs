using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    class BsPrintHandler : CefPrintHandler
    {
        protected override CefSize GetPdfPaperSize(int deviceUnitsPerInch)
        {
            return new CefSize(500, 500);
        }

        protected override bool OnPrintDialog(CefBrowser browser, bool hasSelection, CefPrintDialogCallback callback)
        {
            return true;
        }

        protected override bool OnPrintJob(CefBrowser browser, string documentName, string pdfFilePath, CefPrintJobCallback callback)
        {
            return true;
        }

        protected override void OnPrintReset(CefBrowser browser)
        {

        }

        protected override void OnPrintSettings(CefBrowser browser, CefPrintSettings settings, bool getDefaults)
        {

        }
    }
}
