using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:1986/";
            var connection = new HubConnection(url);
            var chatHub = connection.CreateHubProxy("ChatHub");
            connection.Start().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Console.WriteLine("Connection fault.");
                }
            });

            //客户端响应的动作
            var broadcastHandler = chatHub.On<string, string>("broadcast", (name, message) =>
            {
                Console.WriteLine("[{0}]{1}: {2}", DateTime.Now.ToString("HH:mm:ss"), name, message);
            });


            Console.WriteLine("Please input your name:");
            var _name = Console.ReadLine();
            Console.WriteLine("Start chat!");
            while (true)
            {
                //等待输入后通知服务端执行send方法。
                var _message = Console.ReadLine();
                chatHub.Invoke("Send", _name, _message).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine("Connection error!");
                    }
                });
            }
        }
    }
}
