using System;
using Xilium.CefGlue;

namespace CoolHtmlToPdf.bs
{
    public class BsClient : CefClient
    {
        public event EventHandler OnCreated;
        private readonly CefLifeSpanHandler _lifeSpanHandler;
        private readonly BsWebLoadHandler _loadHandler;
        private readonly CefDownloadHandler _downloadHandler;

        public CefBrowser Bs;
        
        public BsClient(BsCtl bsCtl)
        {
            _lifeSpanHandler = new BsLifeSpanHandler(this);
            _downloadHandler = new BsDownloadHandler();
            _loadHandler = new BsWebLoadHandler(bsCtl);
        }
        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return _lifeSpanHandler;
        }

        protected override CefLoadHandler GetLoadHandler()
        {
            return _loadHandler;
        }

        protected override CefDownloadHandler GetDownloadHandler()
        {
            return _downloadHandler;
        }

        public void Created(CefBrowser bs)
        {
            if (OnCreated != null)
            {
                Bs = bs;
                OnCreated(bs, EventArgs.Empty);
            }
        }
    }
}
