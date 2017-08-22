using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AxDependencyDemo;

namespace AxDemo
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("C1D8CFD2-1E3C-4253-8ED1-4A352D7FEAEC")]
    public interface IAxEmbeddedPanel
    {
        void GoAxEmbedded();
        string SayHello(); 
    }
    //VS_KEY_330FF200EE26C271
    [ClassInterface(ClassInterfaceType.None), Guid("DEDF3A2C-5D5F-411A-A7E0-589870C995B9"), ProgId("StillWaiting.AxEmbeddedPanel")]
    public partial class AxEmbeddedPanel : UserControl, IAxEmbeddedPanel
    {
        private string logPath;
       
        public AxEmbeddedPanel()
        {
            try
            {
                InitializeComponent();
                this.logPath = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), 
                    "logs",
                    DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(this.logPath))
                    Directory.CreateDirectory(this.logPath);

                Log("AxEmbeddedPanel created");
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.ToString());
            }
        }

        public void GoAxEmbedded()
        {
            this.textBox1.Text = "still waiting";
        }

        public string SayHello()
        {
            Log("Method 'SayHello' called");
            return "hey";
        }

        private void Log(string s)
        {
            File.AppendAllText(Path.Combine(this.logPath, "log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"),
                s + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = SayHello();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                var psi = new ProcessStartInfo(
                        Path.Combine(dir, @"AxCallExecutableDemo.exe"))
                {
                    WorkingDirectory = dir,
                };
                var p = Process.Start(psi);
                p.WaitForExit();
                this.textBox1.Text = "call external exe succ";
            }
            catch (Exception ex)
            {
                this.textBox1.Text = "call external exe fail\r\n" + ex.ToString();
            }
        }

        private void buttonLib_Click(object sender, EventArgs e)
        {
            try
            {
                new AxDependencyLib().LibMethod();
                this.textBox1.Text = "call dependency succ";
            }
            catch (Exception ex)
            {
                this.textBox1.Text = "call dependency fail\r\n" + ex.ToString();
            }
        }
    }
}
