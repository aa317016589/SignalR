﻿using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SClient
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


            var broadcastHandler = chatHub.On<string, string>("broadcast", (name, message) =>
            {
                Console.WriteLine("[{0}]{1}: {2}", DateTime.Now.ToString("HH:mm:ss"), name, message);
            });


            Console.WriteLine("Please input your name:");
            var _name = Console.ReadLine();
            Console.WriteLine("Start chat!");
            while (true)
            {
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
