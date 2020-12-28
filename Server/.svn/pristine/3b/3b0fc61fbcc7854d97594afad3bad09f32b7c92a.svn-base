using System;
using System.ServiceProcess;

namespace MessagePush
{
    public partial class MessageService : ServiceBase
    {
        public MessageService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MessageBiz.Init();
        }

        protected override void OnStop()
        {
        }
    }
}