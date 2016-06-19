using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignaIRServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:1986/";
            WebApp.Start<Startup>(url);
            Console.WriteLine("Server started,url is {0}", url);
            Console.ReadLine();
        }
    }
}
