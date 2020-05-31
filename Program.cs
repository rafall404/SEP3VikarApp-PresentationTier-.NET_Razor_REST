using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEP3.Models;

namespace SEP3
{
    public class Program
    {

        public static void Main(string[] args)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");  
            IPAddress ipAddress = host.AddressList[0];  
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 9898);
            
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(remoteEP);
                Console.WriteLine("Connected to app tier #######");
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
