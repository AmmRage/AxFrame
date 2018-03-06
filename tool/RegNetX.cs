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
            if (args.Length != 2)
                return;

            string option = args[0];
            string DLL = args[1];

            Console.WriteLine("Usage:");
            Console.WriteLine("RegNetX [install | uninstall] [DllFullname]");

            Console.WriteLine(DLL);

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

            Console.WriteLine("Work Dir: " + path);

            try
            {
                Process regAsm = new Process();
                //regAsm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                regAsm.StartInfo.CreateNoWindow = true;
                regAsm.StartInfo.WorkingDirectory = path;
                regAsm.StartInfo.FileName = "regasm.exe";
                if (option == "install")
                    regAsm.StartInfo.Arguments = "/codebase " + DLL;
                else if (option == "uninstall")
                    regAsm.StartInfo.Arguments = "/unregister " + DLL;
                else
                    return;
                Console.WriteLine(path + "regasm.exe " + regAsm.StartInfo.Arguments);
                regAsm.Start();
                regAsm.WaitForExit();
            }
            catch
            {
                Console.WriteLine("Error running regasm.exe " + args[0]);
            }
        }
    }
}