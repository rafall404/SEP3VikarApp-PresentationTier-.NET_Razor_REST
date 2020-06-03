using System;
using System.Collections.Generic;
using System.IO;
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
            String input;

                TcpClient tcpClient = 
                    new TcpClient("localhost", 9898);

                NetworkStream networkStream =
                    tcpClient.GetStream();
                    
               
                StreamWriter streamWriter =
                    new StreamWriter(networkStream);
                
                    var passToServer = "Succesfully Connected to Client" + DateTime.Now;
                    streamWriter.WriteLine(passToServer);
                    streamWriter.Flush();
                
                    using (StreamReader streamReader = 
                        new StreamReader(networkStream))
                    {
                        input = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                    Console.WriteLine("Received data: " + input + "\n");
                    
                    streamWriter.Close();
                    networkStream.Close();
                    tcpClient.Close();
                

               
            
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
