using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace UdeCamp
{
    public class ChatHub: Hub
    {
        public void Send(string usuario, string mensaje)
        {
            Clients.All.EnviarMensaje(usuario, mensaje);
        }
    }
}