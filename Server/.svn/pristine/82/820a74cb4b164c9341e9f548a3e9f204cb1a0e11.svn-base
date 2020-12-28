using System;
using System.Configuration;
using System.Net;
using System.Text;

namespace AutoClose
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string server = ConfigurationManager.AppSettings["ServerUrl"];
                string token = "\"" + ConfigurationManager.AppSettings["CloseToken"] + "\"";

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Headers.Add("platform", "1");
                NLog.Info("发送请求");
                string result = webClient.UploadString(server, token);
                NLog.Info(result);
            }
            catch (Exception ex)
            {
                NLog.Error(ex.Message, ex);
            }
            NLog.Info("退出");
        }
    }
}