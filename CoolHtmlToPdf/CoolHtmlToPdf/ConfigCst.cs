using System;
using System.Configuration;

namespace CoolHtmlToPdf
{
   public static class ConfigCst
    {
        public static string CurPath = Environment.CurrentDirectory + @"\PdfFile";
        public static int MaxFileCount = int.Parse(ConfigurationManager.AppSettings["MaxFileCount"].ToString());
        public static string LoadBrowserTime = ConfigurationManager.AppSettings["LoadBrowserTime"].ToString();
    }
}
