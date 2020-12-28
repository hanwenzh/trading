using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using NetMQ;
using NetMQ.Sockets;
using Owin;
using System;
using System.Configuration;
using System.Threading;

[assembly: OwinStartup(typeof(MessagePush.MessageBiz))]
namespace MessagePush
{
    public class MessageBiz
    {
        private static IDisposable SignalR { get; set; }
        private static string ServerURI = ConfigurationManager.AppSettings["SignalRUrl"];

        public static bool Init()
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);

                Thread thread = new Thread(ThreadMQ);
                thread.IsBackground = true;
                thread.Start();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ThreadMQ()
        {
            using (NetMQSocket serverSocket = new ResponseSocket())
            {
                serverSocket.Bind(ConfigurationManager.AppSettings["MQServer"]);
                while (true)
                {
                    string message = serverSocket.ReceiveFrameString();
                    NLog.Info("收到请求：" + message);
                    if (message.Contains("|"))
                    {
                        string[] items = message.Split('|');
                        MessageHub.Send(items[0], items[1]);
                        serverSocket.SendFrame("ok");
                    }
                    else
                    {
                        serverSocket.SendFrame("1");
                    }
                }
            }
        }


        public void Configuration(IAppBuilder app)
        {
            HubConfiguration configuration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };
            app.MapSignalR(configuration);
        }
    }
}