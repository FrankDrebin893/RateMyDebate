using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RateMyDebate.Models;

namespace RateMyDebate.Hubs
{

    public class ChatHub : Hub
    {
        static readonly HashSet<int> DebateGroups = new HashSet<int>();
        private Timer _timer;
        private int time;
    
        public void JoinDebateGroup(int debateId)
        {
            String Id = debateId.ToString();
            if (!DebateGroups.Contains(debateId))
            {
                CreateDebateGroup(debateId);
            }
            else
            {
                Groups.Add(Context.ConnectionId, Id);
            }
        }

        public void CreateDebateGroup(int debateId)
        {
            String Id = debateId.ToString();
            if(DebateGroups.Contains(debateId)) return;
            DebateGroups.Add(debateId);
            JoinDebateGroup(debateId);
            time = 0;
            _timer = new Timer(UpdateTimer, debateId, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
            Clients.All.debateGroups(new[] {debateId});
        }


        public void LeaveDebateGroup(int debateId)
        {
            
        }

        private void UpdateTimer(Object state)
        {
            time += 1;
            BroadcastTimer(state);
        }

        private void BroadcastTimer(Object state)
        {
            String debateId = state.ToString();
            //Clients.All.broadcastTime(time);
            Clients.Group(debateId).broadcastTime(time);
        }

        public void Send(string name, string message, int debateId)
        {
            String debate = debateId.ToString();

            //Clients.All.broadcastMessage(name, message);
            Clients.Group(debate).broadcastMessage(name, message);
        }
    }

}