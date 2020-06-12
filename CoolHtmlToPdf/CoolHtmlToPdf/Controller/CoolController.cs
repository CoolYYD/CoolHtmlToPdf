using CoolHtmlToPdf.bs;
using log4net;
using System.IO;
using System.Web.Http;

namespace CoolHtmlToPdf.Controller
{
    public class CoolController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CoolController));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">需要转化的url地址</param>
        /// <returns></returns>
        [HttpGet]
        public byte[] HtmlToPdf(string url)
        {
            try
            {
                string filePath = new BsCtl().Init(url);
                byte[] data = File.ReadAllBytes(filePath);
                File.Delete(filePath);
                return data;
            }
            catch (System.Exception ex)
            {
                Logger.Error("HtmlToPdf error:" + ex);
                return null;
            }
        }
    }
}
