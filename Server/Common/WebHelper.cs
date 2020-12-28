using System;
using System.Net;

namespace Common
{
    public class WebHelper
    {
        public static void DownloadFile(string url, string filename)
        {
            Uri uri = new Uri(url);
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            webClient.Headers[HttpRequestHeader.Host] = uri.Host;
            webClient.Headers[HttpRequestHeader.Referer] = string.Format("{0}://{1}/", uri.Scheme, uri.Host);
            webClient.Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate";
            webClient.DownloadFile(url, filename);
        }
    }
}
