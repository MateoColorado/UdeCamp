using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(UdeCamp.Start_Up))]

namespace UdeCamp
{
    public class Start_Up
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
