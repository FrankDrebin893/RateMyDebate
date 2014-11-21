using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace RateMyDebate.Hubs
{
    
    public class ServerTimer
    {
        private static int time;
        private readonly Timer _timer;
        private readonly static Lazy<ServerTimer> _instance = new Lazy<ServerTimer>(() => new ServerTimer(GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients));
        private volatile bool _updatingTimer = false;
        private readonly object _updateTimerLock = new object();

        private ServerTimer(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            _timer = new Timer(UpdateTimer, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }
        public void Start()
        {
        }

        public int GetTime()
        {
            return time;
        }

        public void UpdateTimer(object state)
        {
            lock (_updateTimerLock)
            {
                if (!_updatingTimer)
                {
                    _updatingTimer = true;
                    IncrementTimer();
                }
                BroadcastTimer();
                _updatingTimer = false;
            }
        }

        public static ServerTimer Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void IncrementTimer()
        {
            time += 1;
        }

        public void BroadcastTimer()
        {
            Clients.All.broadcastTime(time);
        }

        public void Stop(bool immediate)
        {
            throw new NotImplementedException();
        }
    }
}