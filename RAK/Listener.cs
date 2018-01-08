using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GodSharp.Sockets;
using Sockets.Plugin;

namespace RAK
{
    public class Listener
    {
        public Listener()
        {
            Console.WriteLine("Starting Server");
            var udpReceived = new UdpSocketReceiver();
            udpReceived.StartListeningAsync(8888);

            udpReceived.MessageReceived += (sender, args) =>
            {
                    System.Console.WriteLine($"Remote adrres: {args.RemoteAddress}");
                    System.Console.WriteLine($"Remote port: {args.RemotePort}");
                    
                    var str = System.Text.Encoding.UTF8.GetString(args.ByteData);
                    System.Console.WriteLine($"Messsage: {str}");
                    MainWindow._current.AddMessage(str, true);
                    MainWindow._current.SentenceAnalyzer.Analyze(str);
            };



        }
    }
}
