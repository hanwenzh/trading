using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MessagePush
{
    public class MessageHub : Hub
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();
        private static IHubConnectionContext<dynamic> clients = GlobalHost.ConnectionManager.GetHubContext<MessageHub>().Clients;

        public void Subscribe(string token, string platform)
        {
            Subscribed(Context.ConnectionId, token + "-" + platform);
        }

        private static void DoSend(string conn_id, string message = "")
        {
            clients.Client(conn_id).Message(message);
        }

        private static void DoSend(List<string> conn_ids, string message)
        {
            clients.Clients(conn_ids).Message(message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Disconnected(null, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        private static void Subscribed(object _conn_id, string token)
        {
            NLog.Info("收到订阅：" + token);
            string conn_id = _conn_id.ToString();
            string[] tokens = token.Split('-');
            string msg = "1002";
            if (tokens.Length == 3)
            {
                if (!Users.ContainsKey(conn_id))
                {
                    lock (Users)
                    {
                        Users.Add(conn_id, tokens[0]);
                    }
                }
                msg = "1001";
            }
            DoSend(conn_id, msg);
        }

        private static void Disconnected(object sender, string conn_id)
        {
            lock (Users)
            {
                Users.Remove(conn_id);
            }
        }

        public static void Send(string user_id, string message = "")
        {
            lock (Users)
            {
                var conn_ids = Users.Where(p => p.Value == user_id).Select(u => u.Key).ToList();
                if (conn_ids.Count() > 0)
                {
                    DoSend(conn_ids, message);
                    NLog.Info("发送消息：" + user_id + "  " + message);
                }
            }
        }
    }
}