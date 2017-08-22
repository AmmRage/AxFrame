using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Nancy.Hosting.Self;

namespace NancyTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Nancy Demo";
            //var uri = "http://localhost:43967";
            var uri = "http://10.0.0.173:43967";

            //BasicDemo.EnableOptionalRoute();
            using (var host = new NancyHost(new Uri(uri)))
            {
                host.Start();                
                //
                //Process.Start(new ProcessStartInfo(uri + "/4396"));
                //Process.Start(new ProcessStartInfo(uri));
                
                Console.WriteLine("Running on " + uri + "\r\nPress any key to exit");
                Console.ReadKey();                
                host.Stop();
            }
        }
    }
}
