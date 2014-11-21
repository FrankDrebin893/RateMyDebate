using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace RateMyDebate.Hubs
{

    public class ChatHub : Hub
    {
        private volatile static int time = 0;
        private Timer _timer;
        private readonly ServerTimer _serverTimer;

        public ChatHub() : this(ServerTimer.Instance)
        {
            
        }

        public ChatHub(ServerTimer serverTimer)
        {
            _serverTimer = serverTimer;
        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients
            Clients.All.broadcastMessage(name, message);
        }

        /*
        public void StartTimer()
        {
            _timer = new Timer(BroadcastTimer, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
        }

        
        public void BroadcastTimer(object state)
        {
            time += 1;
            Clients.Caller.broadcastTime(time);
        }
        */
    }
}