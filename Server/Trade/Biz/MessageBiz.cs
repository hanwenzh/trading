using Common;
using Model.Enum;
using NetMQ;
using NetMQ.Sockets;
using RedisSrv;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Biz
{
    public class MessageBiz
    {
        private readonly static string push_server = ConfigurationManager.AppSettings["MessagePushServer"];

        static MessageBiz()
        {
            if (!MonitorRA.HashExists("message", "count"))
                MonitorRA.Set("message", "count", "0");
        }

        public static async void Send(string user_id, MessageTypeEnum messageType, string message = "")
        {
            await Task.Run(() =>
            {
                string msg = string.Format("{0}|{1}{2}", user_id, ((int)messageType).ToString(), message);
                string response;
                bool result = Send(msg, out response);
                if (result && response == "1")
                {
                    MonitorRA.Increment("message", "count");
                    MonitorRA.Set("message", "time", DateTime.Now.Format());
                }
            });
        }

        public static bool Test()
        {
            string msg = "test";
            string response;
            bool result = Send(msg, out response);
            if (result && response == "test")
            {
                return true;
            }
            return false;
        }

        private static bool Send(string msg, out string response)
        {
            using (var client = new RequestSocket())
            {
                client.Connect(push_server);
                client.TrySendFrame(new TimeSpan(0, 0, 3), Encoding.UTF8.GetBytes(msg));
                bool result = client.TryReceiveFrameString(new TimeSpan(0, 0, 3), Encoding.UTF8, out response);
                client.Close();
                client.Dispose();
                return result;
            }
        }
    }
}