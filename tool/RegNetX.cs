using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;

namespace RegNetX
{
    class Program
    {
        static void Main(string[] args)
        {

	    string DLL = Environment.SystemDirectory + "\\MyActiveX.dll";

 	    Console.WriteLine("Usage: RegNetX [-u]");
 	    Console.WriteLine("    Will register " + DLL);
 	    Console.WriteLine("   -u unregisters it");

            // This is the location of the .Net Framework Registry Key
            string framworkRegPath = @"Software\Microsoft\.NetFramework";

            // Get a non-writable key from the registry
            RegistryKey netFramework = Registry.LocalMachine.OpenSubKey(framworkRegPath, false);

            // Retrieve the install root path for the framework
            string installRoot = netFramework.GetValue("InstallRoot").ToString();

            // Retrieve the version of the framework executing this program
            string version = string.Format(@"v{0}.{1}.{2}\",
              Environment.Version.Major,
              Environment.Version.Minor,
              Environment.Version.Build);

            // Return the path of the framework
            string path = System.IO.Path.Combine(installRoot, version);

            if (path == null)
                path = installRoot + version;

            try
            {
                Process regAsm = new Process();
                regAsm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                regAsm.StartInfo.CreateNoWindow = true;
                regAsm.StartInfo.WorkingDirectory = path;
                regAsm.StartInfo.FileName = "regasm.exe";
                if (args.Length == 0)
                  regAsm.StartInfo.Arguments = "/silent /codebase " + DLL;
                else
                  regAsm.StartInfo.Arguments = "/unregister " + DLL;
 		
		Console.WriteLine(path + "regasm.exe " + regAsm.StartInfo.Arguments );
                regAsm.Start();
            }
            catch
            {
                Console.WriteLine("Error running regasm.exe " + args[0]);
            }
        }
    }
}
